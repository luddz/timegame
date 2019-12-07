import React, { Component } from 'react';
import Fade from 'react-reveal/Fade';
import ludde from '../Assets/ludvig-kindberg-bw.png';
import nathan from '../Assets/Nathan-bw.jpg';
import tom from '../Assets/Tom-bw.jpeg';
import 'bootstrap/dist/css/bootstrap.css';
import './about.css'
import Image from 'react-bootstrap/Image'
import gitLogo from '../Assets/GitHub-Mark-Light-32px.png'
import linkedIn from '../Assets/LI-Logo.png'
// import '../App.css'

class About extends Component {
  render(){
    return (
      <Fade>
      <div className="aboutUsContainer">
          <h1>The team behind the game</h1>
        <Fade Bottom delay={500}>
          <div className="theTeam">
            <div>
              <Image className="aboutImageCenter" src={ludde} roundedCircle />
              <p className="names"><b>Alvin Hager</b></p>
              <ul className="role">
                <li>Level designer</li>
                <li>Enviorment designer</li>
                <li>Project owner of the GDD</li>
              </ul>
              <div className="contactDiv">
                <a href='https://github.com/alvinhager' rel="noreferrer noopener" target='_blank'>
                  <div className="gitGrid">
                    <p>alvinhager</p>
                    <Image className="githubImage" src={gitLogo} fluid/>
                    </div>
                  </a>
              </div>
            </div>
            <div>
              <Image className="aboutImageCenter" src={ludde} roundedCircle />
              <p className="names"><b>Ludvig Kindberg</b></p>
              <ul className="role">
                <li>Project manager</li>
                <li>Website</li>
                <li>Bussines plan</li>
                <li>Sound effects</li>
              </ul>
              <div className="contactDiv">
                <a href='http://www.github.com/luddz' rel="noreferrer noopener" target='_blank'>
                  <div className="gitGrid">
                    <p>luddz</p>
                    <Image className="githubImage" src={gitLogo} fluid/>
                    </div>
                  </a>
                <a href='https://www.linkedin.com/in/ludvig-kindberg/' target='_blank' rel="noreferrer noopener">
                    <Image className="linkedInImg" src={linkedIn}/>
                </a>
              </div>
            </div>
            <div>
              <Image className="aboutImageCenter" src={nathan} roundedCircle/>
              <p className="names"><b>Nathan Bhat</b></p>
              <ul className="role">
                <li>Programmer</li>
                <li>Level designer</li>
                <li>Enviorment designer</li>
                <li>Music and SFX creater</li>
              </ul>
              <div className="contactDiv">
                <a href='https://github.com/bhatnathan' rel="noreferrer noopener" target='_blank'>
                  <div className="gitGrid">
                    <p>bhatnathan</p>
                    <Image className="githubImage" src={gitLogo} fluid/>
                    </div>
                  </a>
                <a href='https://www.linkedin.com/in/nathan-bhat-055152152/' target='_blank' rel="noreferrer noopener">
                    <Image className="linkedInImg" src={linkedIn}/>
                </a>
              </div>
            </div>
            <div>
              <Image className="aboutImageCenter" src={tom} roundedCircle />
              <p className="names"><b>Tom Axblad</b></p>
              <ul className="role">
                <li>Programmer</li>
                <li>Art designer</li>
              </ul>
              <div className="contactDiv">
                <a href='https://github.com/mangoglass' rel="noreferrer noopener" target='_blank'>
                  <div className="gitGrid">
                    <p>mangoglass</p>
                    <Image className="githubImage" src={gitLogo} fluid/>
                    </div>
                  </a>
                <a href='https://www.linkedin.com/in/tom-axblad-73243410b/' target='_blank' rel="noreferrer noopener">
                    <Image className="linkedInImg" src={linkedIn}/>
                </a>
              </div>
            </div>
          </div>
        </Fade>
      </div>
      </Fade>

    );
  }
}

export default About;
