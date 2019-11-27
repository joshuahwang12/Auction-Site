import React, { Component } from 'react';
import Card from 'react-bootstrap/Card';
import { ListGroup, ListGroupItem } from 'reactstrap';

export class Home extends Component {
    static displayName = "Auction Website";

    constructor(props) {
        super(props);
        this.state = { auctions: [], loading: true };
    }

    componentDidMount() {
        this.populateAuctionItems();
    }

    static renderAuctionItems(auctions) {
        return (
            <Card style={{ width: '18rem' }}>
                <Card.Img variant="top" src="holder.js/100px180?text=Image cap" />
                <Card.Body>
                    <Card.Title>Used Car</Card.Title>
                    <Card.Text>Description of Car</Card.Text>
                </Card.Body>
                <ListGroup className="list-group-flush">
                    <ListGroupItem>Name: Bob Smith</ListGroupItem>
                    <ListGroupItem>Current Bid: $10000</ListGroupItem>
                    <ListGroupItem>Bid Closes on: 12/10/19 5:30pm</ListGroupItem>
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
            : Home.renderAuctionItems(this.state.auctions);

        return (
            <div>
                <h1 id="tabelLabel" >Auction Items</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async populateAuctionItems() {
        const response = await fetch('auction');
        const data = await response.json();
        this.setState({ auctions: data, loading: false });
    }
}
