import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink, Form, Button, Row, Col, Label, Input } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor (props) {
    super(props);

      this.toggleNavbar = this.toggleNavbar.bind(this);
      this.handleSubmit = this.handleSubmit.bind(this);
    this.state = {
      collapsed: true
    };
  }

  toggleNavbar () {
    this.setState({
      collapsed: !this.state.collapsed
    });
    }

    async handleSubmit(username, password) {
        console.log(username + " " + password);
    //...
    // Make the login API call
        const response = await fetch(`/api/Users/BearerToken`, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                // 'Content-type': 'application/json'
                'Content-Type': 'application/json; charset=utf-8'
            },
        body: JSON.stringify({ username, password })
    })
    //...
    // Extract the JWT from the response
        const { token } = await response.json()
        console.log({ token });
        sessionStorage.setItem("jwt", token);
    //...
    // Do something the token in the login method
    //await login({ jwt_token })  

  render () {
    return (
      <header>
        <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
          <Container>
            <NavbarBrand tag={Link} to="/">Chirper</NavbarBrand>
            <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
            <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
              <ul className="navbar-nav flex-grow">
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/">Hem</NavLink>
                </NavItem>                
                        </ul>
                        
                    </Collapse>
                    <Form>
                        <Row className="row-cols-lg-auto g-3 align-items-center">
                            <Col>                                
                                <Input
                                    id="exampleEmail"
                                    name="email"
                                    placeholder="Anv&auml;ndarnamn"
                                    type="email"
                                />
                            </Col>
                            <Col>                                
                                <Input
                                    id="examplePassword"
                                    name="password"
                                    placeholder="L&ouml;senord"
                                    type="password"
                                />
                            </Col>
                            <Col>
                                <Button onClick={() => this.handleSubmit(document.getElementById('exampleEmail').value, document.getElementById('examplePassword').value)}>
                                    Logga in
                                </Button>
                            </Col>
                        </Row>
                    </Form>
          </Container>
        </Navbar>
      </header>
    );
  }
}
