import React, { useState } from 'react';
import './Timeinout.css';
import Header from '../Components/Header';
import GLE from '../images/glebuilding.png';

function Timeinout() {
  const [buttonText, setButtonText] = useState('Time In');

  const handleClick = () => {
    if (buttonText === 'Time In') {
      setButtonText('Time Out');
    } else {
      setButtonText('Time In');
    }
  };

  return (
    <div>
      <Header username="USERNAME" />
      <div className="timeinout-image-container">
        <img src={GLE} alt="GLE" className="image-size" />
        <button className="button" onClick={handleClick}>
          {buttonText}
        </button>
      </div>
    </div>
  );
}

export default Timeinout;
