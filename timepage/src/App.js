import React, { Component } from 'react';
import { withRouter, Switch, Route, NavLink } from "react-router-dom";
import 'bootstrap/dist/css/bootstrap.css';
import './App.css';
import About from './About/about'
import Homepage from './Homepage/homepage'
// This site has 3 pages, all of which are rendered
// dynamically in the browser (not server rendered).
//
// Although the page does not ever refresh, notice how
// React Router keeps the URL up to date as you navigate
// through the site. This preserves the browser history,
// making sure things like the back button and bookmarks
// work properly.

class App extends Component {
  render() {
    return (
      <div className="App">
        <header className="app-header">
          <NavLink className="navBtn" to="/"><button className="navBtn">Home</button></NavLink>
          <NavLink className="navBtn" to="/about"><button className="navBtn">About</button></NavLink>
        </header>
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
