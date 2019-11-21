import React, { Component } from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import './homepage.css'
import Image from 'react-bootstrap/Image'
import helloWorld from '../Assets/DemoScreenShot.png'
import shortVideo from '../Assets/shortened.mp4'

class Homepage extends Component {
  render() {
    return (
      <div className="App">
        <header className="App-header">
          <h1>
            Asters Planetai
          </h1>
        </header>
        <div className="App-content-container">
          <div className="About-content">
            <h2>About Timegame</h2>
            <div>
              The game is a 2D puzzle platformer in which the player controls a humanoid character in an open-world setting. The gameplay is centered around the use of a time mechanic that allows the character to interact with past versions of itself to solve puzzles in a creative, non-deterministic manner.
            </div>
            <Image className="imageCenter" src={helloWorld} rounded fluid/>
          </div>
          <div className="videoTutorialContainer">
            <h2>A short video demo</h2>
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

export default Homepage
