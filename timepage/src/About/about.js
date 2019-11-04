import React, { Component } from 'react';
import ludd from './ludvig-kindberg-bw.png';
// import Image from 'react-bootstrap/Image'
import './about.css'
// import '../App.css'

class About extends Component {
  render(){
    return (
      <div className="aboutPageContainer">
        <div className="aboutAppContainer">
          <h2>About Timegame</h2>
          <div className="aboutApp">
            <div>
              placeholder text placeholder text placeholder text placeholder text placeholder text placeholder text placeholder text placeholder text placeholder text placeholder text placeholder text placeholder text placeholder text placeholder text placeholder text placeholder text
              placeholder text placeholder text placeholder text placeholder text placeholder text placeholder text placeholder text placeholder text placeholder text placeholder text placeholder text placeholder text placeholder text placeholder text placeholder text placeholder text
            </div>
          </div>
        </div>
        <div className="aboutUsContainer">
        <h2>About us</h2>
          <div className="theTeam">
            <div>
              <img className="imageCenter" src={ludd} height="200px" roundedCircle />
              <p className="names"><b>Ludvig Kindberg</b></p>
              <ul>
                <li>Placeholder</li>
                <li>Placeholder</li>
              </ul>
              <p><b>What I have learned:</b></p>
              <p>Placeholder text, Placeholder Placeholder placeholder</p>
            </div>
          <div>
            <img className="imageCenter" src={ludd} height="200px" roundedCircle />
            <p className="names"><b>Tom Axblad</b></p>
            <ul>
              <li>Placeholder</li>
              <li>placeholder</li>
            </ul>
            <p><b>What I have learned:</b></p>
            <p>Placeholder text, Placeholder Placeholder placeholder </p>
          </div>
          <div>
            <img className="imageCenter" src={ludd} height="200px" roundedCircle />
            <p className="names"><b>Nathan Bhat</b></p>
            <ul>
              <li>Placeholder</li>
              <li>Placeholder</li>
            </ul>
            <p><b>What I have learned:</b></p>
            <p>Placeholder text placeholder placeholder</p>
          </div>
          <div>
            <img className="imageCenter" src={ludd} height="200px" roundedCircle />
            <p className="names"><b>Alvin Hager</b></p>
            <ul>
              <li>Placeholder</li>
              <li>Placeholder</li>
            </ul>
            <p><b>What I have learned:</b></p>
            <p>Placeholder text placeholder text placeholder</p>
          </div>
        </div>
        <div className="videoTutorialContainer">
          <h2>Video tutorial</h2>
          <div className="video">
            <iframe class="video" src="" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
          </div>
        </div>
      </div>
      </div>
    );
  }
}

export default About;
