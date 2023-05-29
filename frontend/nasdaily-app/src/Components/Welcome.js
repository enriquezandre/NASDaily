import React, { useState, useEffect } from 'react';
import './Welcome.css';

function Welcome() {
  const [currentDate, setCurrentDate] = useState('');
  const [currentTime, setCurrentTime] = useState('');

  useEffect(() => {
    const updateDateTime = () => {
      const now = new Date();
      const options = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' };
      setCurrentDate(now.toLocaleDateString(undefined, options));
      setCurrentTime(now.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' }));
    };

    const timer = setInterval(updateDateTime, 1000);
    return () => {
      clearInterval(timer);
    };
  }, []);

  return (
    <div className="welcome-container">
      <p className="welcome-text">HELLO, User!</p>
      <div className="date-time">
        <p className="date">{currentDate}</p>
        <p className="time">{currentTime}</p>
      </div>
    </div>
  );
}

export default Welcome;
