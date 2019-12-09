import React, { Component } from 'react';
import { Document, Page } from 'react-pdf';
import './gdd.css'
import gddPDf from './gdd.pdf'

class Gdd extends Component {
   state = {
    numPages: null,
    pageNumber: 1,
  }

  onDocumentLoadSuccess = ({ numPages }) => {
    this.setState({ numPages });
  }

  render(){
    const { pageNumber, numPages } = this.state;
    return(
      <div className="gddContainer">
        <h1> The GDD</h1>
        <p> The GDD can either be accessed, here on the webpage. But if does not load correctly it can be accessed on or download from the
        <a href='https://github.com/luddz/timegame/blob/webpage/GDD.pdf' rel="noreferrer noopener" target='_blank'> GitHub repository. </a>
        </p>
        <Document
          file={gddPDf}
          onLoadSuccess={this.onDocumentLoadSuccess}>
          <Page pageNumber={pageNumber} />
        </Document>
        <p>Page {pageNumber} of {numPages}</p>
      </div>
    );
  }
}


export default Gdd
