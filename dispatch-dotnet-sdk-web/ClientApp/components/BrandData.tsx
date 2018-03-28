import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import { connect } from 'react-redux';
import { ApplicationState }  from '../store';
import * as BrandState from '../store/Brands';

// At runtime, Redux will merge together...
type BrandProps =
    BrandState.BrandState        // ... state we've requested from the Redux store
    & typeof BrandState.actionCreators      // ... plus action creators we've requested
    & RouteComponentProps<{ }>; // ... plus incoming routing parameters

class BrandData extends React.Component<BrandProps, {}> {
    componentWillMount() {
        // This method runs when the component is first added to the page
        this.props.requestBrands();
    }

    componentWillReceiveProps(nextProps: BrandProps) {
        // This method runs when incoming props (e.g., route params) change
        this.props.requestBrands();
    }

    public render() {
        return <div>
            <h1>Brands</h1>
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
            {this.props.brands.map(brand =>
                <tr key={ brand.id }>
                    <td>{ brand.name }</td>
                </tr>
            )}
            </tbody>
        </table>;
    }
}

export default connect(
    (state: ApplicationState) => state.brands, // Selects which state properties are merged into the component's props
    BrandState.actionCreators                 // Selects which action creators are merged into the component's props
)(BrandData) as typeof BrandData;
