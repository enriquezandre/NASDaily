import React, { useState } from 'react';
import './Timeinout.css';
import Header from '../Components/Header';
import GLE from '../images/glebuilding.png';
import TimeInModal from '../Components/TimeInModal.js';
import TimeOutModal from '../Components/TimeOutModal.js'
import Welcome from '../Components/Welcome.js';

function Timeinout() {
  const [buttonText, setButtonText] = useState('Time In');
  const [timeInModalVisible, setTimeInModalVisible] = useState(false);
  const [timeOutModalVisible, setTimeOutModalVisible] = useState(false);

  const handleClick = () => {
    if (buttonText === 'Time In') {
      setButtonText('Time Out');
      setTimeInModalVisible(true); // Show the modal
      setTimeOutModalVisible(false);
    } else {
      setButtonText('Time In');
      setTimeInModalVisible(false); // Hide the modal
      setTimeOutModalVisible(true);
    }
  };

  return (
    <div>
      <Header username="USERNAME" />
      <div className="timeinout-image-container">
        <img src={GLE} alt="GLE" className="image-size" />
        <Welcome className="welcome"/>
        <button className="button" onClick={handleClick}>
          {buttonText}
        </button>
      </div>
      {timeInModalVisible && (
        <TimeInModal
          show={timeInModalVisible}
          onHide={() => setTimeInModalVisible(false)}
        />
      )}
      {timeOutModalVisible && (
        <TimeOutModal
          show={timeOutModalVisible}
          onHide={() => setTimeOutModalVisible(false)}
        />
      )}
    </div>
  );
}

export default Timeinout;
