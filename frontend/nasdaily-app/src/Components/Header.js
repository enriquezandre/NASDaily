import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import './Header.css';

const Header = ({ username, onLogout }) => {
  const { nasId } = useParams();
  const [user, setUser] = useState(null);

  useEffect(() => {
    const fetchUserData = async () => {
      try {
        const response = await fetch(`https://localhost:7047/api/nas/${nasId}`);
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
  }, [nasId]);

  return (
    <div className="header">
      <div className="header-content">
      <a href={`/${nasId}/NASActivities`} className="no-underline">
        <div className="username">{user?.name}</div>
      </a>
      <button className="logout-button" onClick={onLogout}>
        Logout
      </button>
      </div>
      <div className="underline" />
    </div>
  );
};

export default Header;
