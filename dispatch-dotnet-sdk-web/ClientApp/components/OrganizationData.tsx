import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { ApplicationState }  from '../store';
import * as OrganizationState from '../store/Organizations';

// At runtime, Redux will merge together...
type OrganizationProps =
OrganizationState.OrganizationState        // ... state we've requested from the Redux store
    & typeof OrganizationState.actionCreators      // ... plus action creators we've requested
    & RouteComponentProps<{ }>; // ... plus incoming routing parameters

class OrganizationData extends React.Component<OrganizationProps, {}> {
    componentWillMount() {
        // This method runs when the component is first added to the page
        this.props.requestOrganizations();
    }

    componentWillReceiveProps(nextProps: OrganizationProps) {
        // This method runs when incoming props (e.g., route params) change
        this.props.requestOrganizations();
    }

    public render() {
        return <div>
            <h1>Organizations</h1>
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
            {this.props.organizations.map(organization =>
                <tr key={ organization.id }>
                    <td>{ organization.name }</td>
                    <td>{ organization.email }</td>
                </tr>
            )}
            </tbody>
        </table>;
    }
}

export default connect(
    (state: ApplicationState) => state.organizations, // Selects which state properties are merged into the component's props
    OrganizationState.actionCreators                 // Selects which action creators are merged into the component's props
)(OrganizationData) as typeof OrganizationData;
