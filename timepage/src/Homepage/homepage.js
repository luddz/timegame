import React, { Component } from 'react';
// import 'bootstrap/dist/css/bootstrap.css';
import './homepage.css'
import Image from 'react-bootstrap/Image'
import helloWorld from '../Assets/DemoScreenShot.png'
import shortVideo from '../Assets/shortened.mp4'
import trailer from '../Assets/Final_trailer.mp4'
import asterBoi from '../Assets/AsterGuy.png'
import gitLogo from '../Assets/GitHub-Mark-Light-32px.png'
import Fade from 'react-reveal/Fade';

class Homepage extends Component {
  render() {
    return (
      <div className="App">
        <div className="App-header">
          <Fade bottom delay={250}>
            <h1>
              Asters Planetai
            </h1>
          </Fade>
        </div>
        <div className="App-content-container">
          <Fade bottom>
            <div className="About-content-container">
              <div className="about-header">
                <h2>About Asters Planetai</h2>
              </div>
              <div className="about-content">
                <Image className="imageLeft" src={asterBoi} rounded fluid/>
                <div className="about-text">
                  <p>
                  Ever dreamed about having the ability to control time, just to rewind it and let the past you play out what it just did. If you don't agree with it anymore just kill it off. Or maybe the dream have just been to be able to intreact with previous run of your self to do solve different puzzles.
                  </p>
                  <p>
                  In this puzzle game that is just what you have the oppertunity to do. You play as a humanoid with the ability to rewind time to a fixed point and let see the previous version preform the run they just did.
                  </p>
                  <p>
                  The game takes place in a 2D open-world setting, allowing for free roaming and explorative experince while solving puzzles in a non-deterministic manner.
                  </p>
                </div>
                <Image className="imageRight" src={helloWorld} rounded fluid/>
              </div>
            </div>
          </Fade>
          <div className="videoGitGrid">
            <Fade bottom>
              <div className="videoTutorialContainer">
                <h2>Trailer</h2>
                <div className="video">
                  <video width="640" height="480" controls>
                    <source src={trailer} type="video/mp4"/>
                    Your browser does not support the video tag.
                  </video>
                </div>
                <h2>Introduction level</h2>
                <iframe width="560" height="315" src="https://www.youtube.com/embed/8_oWECUWE0I" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
                <h2>Hello world video</h2>
                <div className="video">
                  <video width="640" height="480" controls>
                    <source src={shortVideo} type="video/mp4"/>
                    Your browser does not support the video tag.
                  </video>
                </div>
              </div>
              <div className="downloadContrainer">
                <h2>The code and download</h2>
                <p> All of the code, for both the game and this webpage can be found on </p>
                <a href='http://www.github.com/luddz/timegame' rel="noreferrer noopener" target='_blank'>
                  <div className="gitGrid">
                    <p>GitHub</p>
                    <Image className="githubImage" src={gitLogo} fluid/>
                  </div>
                </a>
                <p>
                The game can be downloaded throught the github page. </p>
                <a href='https://github.com/luddz/timegame/blob/master/Asters%20Planetai.zip' rel="noreferrer noopener" target='_blank'><p>LINK TO ZIP FOR WINDOW.</p> </a>
              </div>
            </Fade>
          </div>
        </div>
      </div>
    );
  }
}

export default Homepage
