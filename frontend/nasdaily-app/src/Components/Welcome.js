import React, { useState, useEffect } from 'react';
import './Welcome.css';

function Welcome() {
  const [currentDate, setCurrentDate] = useState('');
  const [currentTime, setCurrentTime] = useState('');
  const [user, setUser] = useState(null);

  useEffect(() => {
    const updateDateTime = () => {
      const now = new Date();
      const options = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' };
      setCurrentDate(now.toLocaleDateString(undefined, options));
      setCurrentTime(now.toLocaleTimeString([], { hour: '2-digit', minute: '2-digit' }));
    };

    const fetchUserData = async () => {
      try {
        const response = await fetch('https://localhost:7047/api/nas');
        if (response.ok) {
          const userData = await response.json();
          setUser(userData[0]);
        } else {
          throw new Error('Failed to fetch user data');
        }
      } catch (error) {
        console.error('Error:', error);
      }
    };

    updateDateTime();
    fetchUserData();

    const timer = setInterval(updateDateTime, 1000);
    return () => {
      clearInterval(timer);
    };
  }, []);

  const getFirstName = (fullName) => {
    const names = fullName.split(' ');
    if (names.length > 0) {
      return names[0];
    }
    return '';
  };

  const firstName = user ? getFirstName(user.name) : '';

  return (
    <div className="welcome-container">
      <p className="welcome-text">HELLO, {firstName}!</p>
      <div className="date-time">
        <p className="date">{currentDate}</p>
        <p className="time">{currentTime}</p>
      </div>
    </div>
  );
}

export default Welcome;
