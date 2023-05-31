import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import './Timeinout.css';
import Header from '../Components/Header';
import GLE from '../images/glebuilding-edited.png';
import TimeInModal from '../Components/TimeInModal';
import TimeOutModal from '../Components/TimeOutModal';
import Welcome from '../Components/Welcome';

const Timeinout = () => {
  const { username } = useParams();
  const [user, setUser] = useState(null);
  const [buttonText, setButtonText] = useState('Time In');
  const [timeInModalVisible, setTimeInModalVisible] = useState(false);
  const [timeOutModalVisible, setTimeOutModalVisible] = useState(false);

  useEffect(() => {
    const fetchUserData = async () => {
      try {
        const response = await fetch(`https://localhost:7047/api/nas/username/${username}`);
        if (response.ok) {
          const userData = await response.json();
          setUser(userData);
        } else {
          throw new Error('Failed to fetch user data');
        }
      } catch (error) {
        console.error('Error:', error);
      }
    };

    fetchUserData();
  }, [username]);

  const handleClick = () => {
    if (buttonText === 'Time In') {
      setButtonText('Time Out');
      setTimeInModalVisible(true);
      setTimeOutModalVisible(false);
    } else {
      setButtonText('Time In');
      setTimeInModalVisible(false);
      setTimeOutModalVisible(true);
    }
  };

  return (
    <div>
      {user && (
        <Header username={username} /> 
      )}
      <div className="timeinout-image-container">
        <img src={GLE} alt="GLE" className="image-size" />
        <Welcome className="welcome" />
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
};

export default Timeinout;
