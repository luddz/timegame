import React, { Component } from 'react';
import ludde from './ludvig-kindberg-bw.png';
import 'bootstrap/dist/css/bootstrap.css';
import './about.css'
import Image from 'react-bootstrap/Image'
// import '../App.css'

class About extends Component {
  render(){
    return (
      <div className="aboutUsContainer">
        <h1>About us</h1>
        <div className="theTeam">
          <div>
            <Image className="imageCenter" src={ludde} height="200px" roundedCircle />
            <p className="names"><b>Ludvig Kindberg</b></p>
            <ul>
              <li>Placeholder</li>
              <li>Placeholder</li>
            </ul>
            <p><b>What I have learned:</b></p>
            <p>Placeholder text, Placeholder Placeholder placeholder</p>
          </div>
          <div>
            <Image className="imageCenter" src={ludde} height="200px" roundedCircle />
            <p className="names"><b>Tom Axblad</b></p>
            <ul>
              <li>Placeholder</li>
              <li>placeholder</li>
            </ul>
            <p><b>What I have learned:</b></p>
            <p>Placeholder text, Placeholder Placeholder placeholder </p>
          </div>
          <div>
            <Image className="imageCenter" src={ludde} height="200px" roundedCircle />
            <p className="names"><b>Nathan Bhat</b></p>
            <ul>
              <li>Placeholder</li>
              <li>Placeholder</li>
            </ul>
            <p><b>What I have learned:</b></p>
            <p>Placeholder text placeholder placeholder</p>
          </div>
          <div>
            <Image className="imageCenter" src={ludde} height="200px" roundedCircle />
            <p className="names"><b>Alvin Hager</b></p>
            <ul>
              <li>Placeholder</li>
              <li>Placeholder</li>
            </ul>
            <p><b>What I have learned:</b></p>
            <p>Placeholder text placeholder text placeholder</p>
          </div>
        </div>
      </div>
    );
  }
}

export default About;
