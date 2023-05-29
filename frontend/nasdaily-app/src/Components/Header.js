import React from 'react';
import './Header.css'

const Header = ({ username, onLogout }) => {
    return (
      <div className="header">
        <div className="header-content">
          <div className="username">{username}</div>
          <button className="logout-button" onClick={onLogout}>
            Logout
          </button>
        </div>
        <div className="underline" />
      </div>
    );
  };

export default Header;
