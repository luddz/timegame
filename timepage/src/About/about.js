import React, { Component } from 'react';
import ludde from './ludvig-kindberg-bw.png';
import 'bootstrap/dist/css/bootstrap.css';
import './about.css'
import shortVideo from '../Assets/shortened.mp4'
// import '../App.css'

class About extends Component {
  render(){
    return (
      <div className="aboutPageContainer">
        <div className="aboutAppContainer">
          <h2>About Timegame</h2>
          <div className="aboutApp">
            <div>
              The game is a 2D puzzle platformer in which the player controls a humanoid character in an open-world setting. The gameplay is centered around the use of a time mechanic that allows the character to interact with past versions of itself to solve puzzles in a creative, non-deterministic manner. 
            </div>
          </div>
        </div>
        <div className="aboutUsContainer">
        <h2>About us</h2>
          <div className="theTeam">
            <div>
              <img className="imageCenter" src={ludde} height="200px" roundedCircle />
              <p className="names"><b>Ludvig Kindberg</b></p>
              <ul>
                <li>Placeholder</li>
                <li>Placeholder</li>
              </ul>
              <p><b>What I have learned:</b></p>
              <p>Placeholder text, Placeholder Placeholder placeholder</p>
            </div>
          <div>
            <img className="imageCenter" src={ludde} height="200px" roundedCircle />
            <p className="names"><b>Tom Axblad</b></p>
            <ul>
              <li>Placeholder</li>
              <li>placeholder</li>
            </ul>
            <p><b>What I have learned:</b></p>
            <p>Placeholder text, Placeholder Placeholder placeholder </p>
          </div>
          <div>
            <img className="imageCenter" src={ludde} height="200px" roundedCircle />
            <p className="names"><b>Nathan Bhat</b></p>
            <ul>
              <li>Placeholder</li>
              <li>Placeholder</li>
            </ul>
            <p><b>What I have learned:</b></p>
            <p>Placeholder text placeholder placeholder</p>
          </div>
          <div>
            <img className="imageCenter" src={ludde} height="200px" roundedCircle />
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
            <video width="640" height="480" controls>
              <source src={shortVideo} type="video/mp4"/>
              Your browser does not support the video tag.
            </video>
          </div>
        </div>
      </div>
      </div>
    );
  }
}

export default About;
