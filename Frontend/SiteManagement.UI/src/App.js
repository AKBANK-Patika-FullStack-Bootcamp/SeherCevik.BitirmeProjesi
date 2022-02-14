// import logo from './logo.svg';
import './App.css';
import Login from './components/Login.js';
// import AdminPanel from './components/AdminPanel.js';
import React, { useState, Component } from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';




class App extends Component {
  render() {
      return (
        <div>

          {(<Login/>)}
        {/* <Router>
        <Route exact path="/" component={Login} />
        <Route exact path="/users" component={AdminPanel} />
      </Router> */}
        </div>
      );
  }
}

 export default App;





