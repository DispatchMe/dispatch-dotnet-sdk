import { fetch, addTask } from 'domain-task';
import { Action, Reducer, ActionCreator } from 'redux';
import { AppThunkAction } from './';

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface BrandState {
    isLoading: boolean;
    brands: Brand[];
}

export interface Brand {
    id: number;
    name: string;
}

// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.

interface RequestBrandsAction {
    type: 'REQUEST_BRANDS';
}

interface ReceiveBrandsAction {
    type: 'RECEIVE_BRANDS';
    brands: Brand[];
}

// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction = RequestBrandsAction | ReceiveBrandsAction;

// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
    requestBrands: (): AppThunkAction<KnownAction> => (dispatch, getState) => {
        // Only load data if it's something we don't already have (and are not already loading)
        if (getState().brands.brands.length == 0) {
            let fetchTask = fetch(`api/Brands/Brands`)
                .then(response => response.json() as Promise<Brand[]>)
                .then(data => {
                    dispatch({ type: 'RECEIVE_BRANDS', brands: data });
                });

            addTask(fetchTask); // Ensure server-side prerendering waits for this to complete
            dispatch({ type: 'REQUEST_BRANDS'});
        }

    }
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

const unloadedState: BrandState = { brands: [], isLoading: false };

export const reducer: Reducer<BrandState> = (state: BrandState, incomingAction: Action) => {
    const action = incomingAction as KnownAction;
    switch (action.type) {
        case 'REQUEST_BRANDS':
            return {
                brands: state.brands,
                isLoading: true
            };
        case 'RECEIVE_BRANDS':
            // Only accept the incoming data if it matches the most recent request. This ensures we correctly
            // handle out-of-order responses.
            return {
                brands: action.brands,
                isLoading: false
            };
        default:
            // The following line guarantees that every action in the KnownAction union has been covered by a case above
            const exhaustiveCheck: never = action;
    }

    return state || unloadedState;
};
