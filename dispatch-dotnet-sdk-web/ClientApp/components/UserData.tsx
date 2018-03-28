import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { ApplicationState }  from '../store';
import * as UserState from '../store/Users';

// At runtime, Redux will merge together...
type UserProps =
    UserState.UserState        // ... state we've requested from the Redux store
    & typeof UserState.actionCreators      // ... plus action creators we've requested
    & RouteComponentProps<{ }>; // ... plus incoming routing parameters

class UserData extends React.Component<UserProps, {}> {
    componentWillMount() {
        // This method runs when the component is first added to the page
        this.props.requestUsers();
    }

    componentWillReceiveProps(nextProps: UserProps) {
        // This method runs when incoming props (e.g., route params) change
        this.props.requestUsers();
    }

    public render() {
        return <div>
            <h1>Users</h1>
            <p>This component demonstrates fetching data from the server and working with URL parameters.</p>
            { this.renderTable() }
        </div>;
    }

    private renderTable() {
        console.log(this.props);
        return <table className='table'>
            <thead>
                <tr>
                    <th>Name</th>
                </tr>
            </thead>
            <tbody>
            {this.props.users.map(user =>
                <tr key={ user.id }>
                    <td>{ user.first_name } { user.last_name }</td>
                    <td>{ user.email }</td>
                </tr>
            )}
            </tbody>
        </table>;
    }
}

export default connect(
    (state: ApplicationState) => state.users, // Selects which state properties are merged into the component's props
    UserState.actionCreators                 // Selects which action creators are merged into the component's props
)(UserData) as typeof UserData;
