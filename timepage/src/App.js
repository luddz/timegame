import React, { Component } from 'react';
import { withRouter, Switch, Route} from "react-router-dom";
import 'bootstrap/dist/css/bootstrap.css';
import './App.css';
import About from './About/about'
import Homepage from './Homepage/homepage'
import Navbar from 'react-bootstrap/Navbar'
import Nav from 'react-bootstrap/Nav'


// <header className="app-header" fixed="top">
//
//   <NavLink className="navBtn" to="/"><button className="navBtn">Home</button></NavLink>
//   <NavLink className="navBtn" to="/about"><button className="navBtn">About</button></NavLink>
// </header>
class App extends Component {
  render() {
    return (
      <div className="App">
        <Navbar bg="dark" variant="dark" fixed="top">
            <Navbar.Brand href="#">Asters Planetai</Navbar.Brand>
            <Navbar.Toggle aria-controls="basic-navbar-nav" />
            <Navbar.Collapse id="basic-navbar-nav">
              <Nav className="mr-auto">
                <Nav.Link href="#/">Home</Nav.Link>
                <Nav.Link href="#/about">The team</Nav.Link>
              </Nav>
            </Navbar.Collapse>
          </Navbar>
        <Switch>
          <Route exact path="/">
            <Homepage />
          </Route>
          <Route exact path="/about">
            <About />
          </Route>
        </Switch>
      </div>
    );
  }
}

export default withRouter(App)
