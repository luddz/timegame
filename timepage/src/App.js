import React, { Component } from 'react';
import Image from 'react-bootstrap/Image'
import { withRouter, Switch, Route} from "react-router-dom";
import 'bootstrap/dist/css/bootstrap.css';
import './App.css';
import About from './About/about'
import Homepage from './Homepage/homepage'
import Navbar from 'react-bootstrap/Navbar'
import Nav from 'react-bootstrap/Nav'
import gitLogo from './Assets/GitHub-Mark-Light-32px.png'

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
                <a href='http://www.github.com/luddz/timegame' rel="noreferrer noopener" target='_blank'>
                <div className="gitGrid">
                  <Image className="githubImage" src={gitLogo} fluid/>
                </div>
                </a>
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
