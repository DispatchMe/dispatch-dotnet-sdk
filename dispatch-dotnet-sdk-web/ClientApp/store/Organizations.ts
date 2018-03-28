import { fetch, addTask } from 'domain-task';
import { Action, Reducer, ActionCreator } from 'redux';
import { AppThunkAction } from './';

// -----------------
// STATE - This defines the type of data maintained in the Redux store.

export interface OrganizationState {
    isLoading: boolean;
    organizations: Organization[];
}

export interface Organization {
    id: number;
    name: string;
    email: string;
}

// -----------------
// ACTIONS - These are serializable (hence replayable) descriptions of state transitions.
// They do not themselves have any side-effects; they just describe something that is going to happen.

interface RequestOrganizationsAction {
    type: 'REQUEST_ORGANIZATIONS';
}

interface ReceiveOrganizationsAction {
    type: 'RECEIVE_ORGANIZATIONS';
    organizations: Organization[];
}

// Declare a 'discriminated union' type. This guarantees that all references to 'type' properties contain one of the
// declared type strings (and not any other arbitrary string).
type KnownAction = RequestOrganizationsAction | ReceiveOrganizationsAction;

// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).

export const actionCreators = {
    requestOrganizations: (): AppThunkAction<KnownAction> => (dispatch, getState) => {
        // Only load data if it's something we don't already have (and are not already loading)
        if (getState().organizations.organizations.length == 0) {
            let fetchTask = fetch(`api/Organizations/Organizations`)
                .then(response => response.json() as Promise<Organization[]>)
                .then(data => {
                    dispatch({ type: 'RECEIVE_ORGANIZATIONS', organizations: data });
                });

            addTask(fetchTask); // Ensure server-side prerendering waits for this to complete
            dispatch({ type: 'REQUEST_ORGANIZATIONS'});
        }

    }
};

// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.

const unloadedState: OrganizationState = { organizations: [], isLoading: false };

export const reducer: Reducer<OrganizationState> = (state: OrganizationState, incomingAction: Action) => {
    const action = incomingAction as KnownAction;
    switch (action.type) {
        case 'REQUEST_ORGANIZATIONS':
            return {
                organizations: state.organizations,
                isLoading: true
            };
        case 'RECEIVE_ORGANIZATIONS':
            // Only accept the incoming data if it matches the most recent request. This ensures we correctly
            // handle out-of-order responses.
            return {
                organizations: action.organizations,
                isLoading: false
            };
        default:
            // The following line guarantees that every action in the KnownAction union has been covered by a case above
            const exhaustiveCheck: never = action;
    }

    return state || unloadedState;
};
