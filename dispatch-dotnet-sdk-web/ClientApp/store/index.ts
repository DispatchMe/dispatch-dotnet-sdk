import * as WeatherForecasts from './WeatherForecasts';
import * as Brands from './Brands';
import * as Counter from './Counter';
import * as Organizations from './Organizations';
import * as Users from './Users';

// The top-level state object
export interface ApplicationState {
    counter: Counter.CounterState;
    weatherForecasts: WeatherForecasts.WeatherForecastsState;
    brands: Brands.BrandState;
    organizations: Organizations.OrganizationState;
    users: Users.UserState;
}

// Whenever an action is dispatched, Redux will update each top-level application state property using
// the reducer with the matching name. It's important that the names match exactly, and that the reducer
// acts on the corresponding ApplicationState property type.
export const reducers = {
    counter: Counter.reducer,
    brands: Brands.reducer,
    organizations: Organizations.reducer,
    users: Users.reducer,
};

// This type can be used as a hint on action creators so that its 'dispatch' and 'getState' params are
// correctly typed to match your store.
export interface AppThunkAction<TAction> {
    (dispatch: (action: TAction) => void, getState: () => ApplicationState): void;
}
