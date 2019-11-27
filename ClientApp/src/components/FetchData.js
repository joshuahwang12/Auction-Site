import React, { Component } from 'react';
import Card from 'react-bootstrap/Card';
import { ListGroup, ListGroupItem } from 'reactstrap';

export class FetchData extends Component {
    static displayName = FetchData.name;

    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true };
    }

    componentDidMount() {
        this.populateWeatherData();
    }

    static renderForecastsTable(forecasts) {
        return (
            //<table className='table table-striped' aria-labelledby="tabelLabel">
            //  <thead>
            //    <tr>
            //      <th>Date</th>
            //      <th>Temp. (C)</th>
            //      <th>Temp. (F)</th>
            //      <th>Summary</th>
            //    </tr>
            //  </thead>
            //  <tbody>
            //    {forecasts.map(forecast =>
            //      <tr key={forecast.date}>
            //        <td>{forecast.date}</td>
            //        <td>{forecast.temperatureC}</td>
            //        <td>{forecast.temperatureF}</td>
            //        <td>{forecast.summary}</td>
            //      </tr>
            //    )}
            //  </tbody>
            //</table>
            <Card style={{ width: '18rem' }}>
                <Card.Img variant="top" src="holder.js/100px180?text=Image cap" />
                <Card.Body>
                    <Card.Title>Card Title</Card.Title>
                    <Card.Text>
                        Some quick example text to build on the card title and make up the bulk of
                        the card's content.
                    </Card.Text>
                </Card.Body>
                <ListGroup className="list-group-flush">
                    <ListGroupItem>Cras justo odio</ListGroupItem>
                    <ListGroupItem>Dapibus ac facilisis in</ListGroupItem>
                    <ListGroupItem>Vestibulum at eros</ListGroupItem>
                </ListGroup>
                <Card.Body>
                    <Card.Link href="#">Card Link</Card.Link>
                    <Card.Link href="#">Another Link</Card.Link>
                </Card.Body>
            </Card>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchData.renderForecastsTable(this.state.forecasts);

        return (
            <div>
                <h1 id="tabelLabel" >Weather forecast</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async populateWeatherData() {
        const response = await fetch('weatherforecast');
        const data = await response.json();
        this.setState({ forecasts: data, loading: false });
    }
}
