import React, { useState } from 'react';
import "./Login.css";
import bg from "../images/glebuilding.png";

export const Login = () => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [loginError, setLoginError] = useState(false);

  const handleSubmit = async (e) => {
    e.preventDefault();
  
    try {
      const response = await fetch('https://localhost:7047/api/nas', {
        method: 'GET',
        headers: {
          'Content-Type': 'application/json',
        },
      });
  
      console.log('Response:', response);
  
      if (response.ok) {
        const nasList = await response.json();
        console.log('NAS List:', nasList);
  
        const nas = nasList.find((n) => n.nasId === username && n.password === password);
        console.log('Matching NAS:', nas);
  
        if (nas) {
          // Successful login, redirect user to dashboard or another page
          // e.g., window.location.href = '/dashboard';
          console.log('Login successful');
        } else {
          // Invalid credentials, display error message
          setLoginError(true);
          console.log('Invalid credentials');
        }
      } else {
        // Handle failed API request, display error message
        setLoginError(true);
        console.log('API request failed');
      }
    } catch (error) {
      // Handle any errors that occur during the API request
      console.error('Error:', error);
    }
  };  

  return (
    <>
      <div className='center-container'>
        <div className='main-container'>
          <div className='login-image-container'>
            <img src={bg} alt='glebuilding' className='bg-container' />
          </div>
          <div className='text-container'>
            <span className='text-login'>LOGIN</span>
            <form onSubmit={handleSubmit}>
              <div className='input-container'>
                <label htmlFor='username' className='input-label'>
                  Enter Username
                </label>
                <input
                  type='text'
                  id='username'
                  className='text-input'
                  value={username}
                  onChange={(e) => setUsername(e.target.value)}
                />
                <label htmlFor='password' className='input-label'>
                  Enter Password
                </label>
                <input
                  type='password'
                  id='password'
                  className='text-input'
                  value={password}
                  onChange={(e) => setPassword(e.target.value)}
                />
                <input type='submit' className='button-submit' value='Login' />
              </div>
            </form>
            {loginError && <p className='error-message'>Invalid username or password</p>}
          </div>
        </div>
      </div>
    </>
  );
};
