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
  const [, setActivitiesDone] = useState('');
  const [, setSkillsLearned] = useState('');
  const [, setValuesLearned] = useState('');
  const [timeIn, setTimeIn] = useState(null);
  

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

  const handleTimeIn = () => {
    if (!timeIn) {
      const currentTime = new Date().toISOString();
      console.log('Recording Time In:', currentTime);
      setTimeIn(currentTime);
      const logData = {
        id: "6477d90c07381264addfe4c4",
        logId: "log1",
        timeIn: currentTime,
        tasks: {
          taskId: "task1",
          activitiesDone: "",
          skillsLearned: "",
          valuesLearned: ""
        }
      };
  
      fetch(`https://localhost:7047/api/logs/nas/${username}/logs`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(logData)
      })
        .then(response => {
          if (response.ok) {
            console.log('Time In recorded successfully');
            setButtonText('Time Out');
            setTimeInModalVisible(true);
          } else {
            console.error('Failed to record Time In');
          }
        })
        .catch(error => {
          console.error('Error:', error);
        });
    } else {
      console.log('Time In already recorded:', timeIn);
      setTimeInModalVisible(true); // Show the modal even if a Time In has already been recorded.
    }
  };
  

  const handleTimeOut = (activities, skills, values) => {
    setActivitiesDone(activities);
    setSkillsLearned(skills);
    setValuesLearned(values);

    const currentTime = new Date().toISOString();
    console.log('Recording Time Out:', currentTime);
    const logData = {
      id: "6477d90c07381264addfe4c4",
      logId: "log1",
      timeIn: timeIn,
      timeOut: currentTime,
      tasks: {
        taskId: "task1",
        activitiesDone: activities,
        skillsLearned: skills,
        valuesLearned: values
      }
    };

    fetch(`https://localhost:7047/api/logs/nas/${username}/logs`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(logData)
    })
      .then(response => {
        if (response.ok) {
          console.log('Log entry added successfully');
        } else {
          console.error('Failed to add log entry');
        }
      })
      .catch(error => {
        console.error('Error:', error);
      });

    setButtonText('Time In');
    setTimeOutModalVisible(false);
    setTimeInModalVisible(false);
    setTimeIn(null);
  };

  const handleClick = () => {
    if (buttonText === 'Time In') {
      handleTimeIn();
    } else {
      setTimeOutModalVisible(true);
    }
  };

  return (
    <div>
      <Header username={username} />
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
          onDone={handleTimeOut}
        />
      )}
    </div>
  );
};

export default Timeinout;
