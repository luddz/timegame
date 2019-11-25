import React, { Component } from 'react';
import ludde from '../Assets/ludvig-kindberg-bw.png';
import nathan from '../Assets/Nathan-bw.jpg';
import tom from '../Assets/Tom-bw.jpeg';
import 'bootstrap/dist/css/bootstrap.css';
import './about.css'
import Image from 'react-bootstrap/Image'
// import '../App.css'

class About extends Component {
  render(){
    return (
      <div className="aboutUsContainer">
        <h1>The team behind the game</h1>
        <div className="theTeam">
          <div>
            <Image className="aboutImageCenter" src={ludde} roundedCircle />
            <p className="names"><b>Alvin Hager</b></p>
            <ul className="role">
              <li>Level designer</li>
              <li>Enviorment designer</li>
              <li>Project over of the GDD</li>
            </ul>
          </div>
          <div>
            <Image className="aboutImageCenter" src={ludde} roundedCircle />
            <p className="names"><b>Ludvig Kindberg</b></p>
            <ul className="role">
              <li>Project manager??</li>
              <li>Website</li>
              <li>Bussines plan</li>
              <li>Sound effects</li>
            </ul>
          </div>
          <div>
            <Image className="aboutImageCenter" src={nathan} roundedCircle/>
            <p className="names"><b>Nathan Bhat</b></p>
            <ul className="role">
              <li>Programmer</li>
              <li>Level designer</li>
            </ul>
          </div>
          <div>
            <Image className="aboutImageCenter" src={tom} roundedCircle />
            <p className="names"><b>Tom Axblad</b></p>
            <ul className="role">
              <li>Programmer</li>
              <li>Art designer</li>
            </ul>
          </div>
        </div>
      </div>
    );
  }
}

export default About;
