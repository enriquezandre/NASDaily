import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import Header from '../Components/Header'
import './NAS.css';

function NASActivities() {
  const { username } = useParams();
  const [user, setUser] = useState(null);
  const [logs, setLogs] = useState([]);

  useEffect(() => {
    const fetchUserData = async () => {
      try {
        const response = await fetch(`https://localhost:7047/api/nas/username/${username}`);
        if (response.ok) {
          const userData = await response.json();
          setUser(userData);
          setLogs(userData.logs);
        } else {
          throw new Error('Failed to fetch user data');
        }
      } catch (error) {
        console.error('Error:', error);
      }
    };

    fetchUserData();
  }, [username]);

    return (
      <>
        <Header username={username} />
        <div className='nasactivity-main-container'>
          <div className='nasmenu-button-container'>
            <button className='nasbtn-menu'>PERSONAL INFORMATION</button>
            <button className='nasbtn-menu'>ATTENDANCE SUMMARY</button>
            <button className='nasbtn-menu'>SCHEDULE OF DUTY</button>
            <button className='nasbtn-menu'>EVALUATION RESULT</button>
          </div>
          <div className='result-container'>
            <div className='nas-details'>
              <p>SCHOLAR NAME: {user?.name}</p>
                <div>
                  <label>
                      MONTH:
                      <select className='attendance-month-dropdown'>
                          <option value="month">January</option>
                          <option value="month">February</option>
                          <option value="month">March</option>
                          <option value="month">April</option>
                          <option value="month">May</option>
                      </select>
                  </label>
                </div>
            </div>
            <div className='attendance-summary'>
                <p>ACTIVITIES SUMMARY:</p>
                <br/>
                <table className='attendance-table'>
            <thead style={{ color: 'black', textTransform: 'uppercase' }}>
              <tr>
                <th>Date</th>
                <th>Time-in</th>
                <th>Time-out</th>
                <th>Activities Done</th>
                <th>Skills learned</th>
                <th>Values learned</th>
              </tr>
            </thead>
            <tbody>
              {logs.map((log) => {
                const timeIn = new Date(log.timeIn);
                const timeOut = new Date(log.timeOut);

                const formatDate = (date) => {
                  const year = date.getFullYear();
                  const month = String(date.getMonth() + 1).padStart(2, '0');
                  const day = String(date.getDate()).padStart(2, '0');
                  return `${year}-${month}-${day}`;
                };

                return (
                  <tr key={log.logId}>
                    <td>{formatDate(timeIn)}</td>
                    <td>{timeIn.toLocaleTimeString()}</td>
                    <td>{timeOut.toLocaleTimeString()}</td>
                    <td>{log.tasks.activitiesDone}</td>
                    <td>{log.tasks.skillsLearned}</td>
                    <td>{log.tasks.valuesLearned}</td>
                  </tr>
                );
              })}
            </tbody>
          </table>
            </div>
          </div>
        </div>
      </>
    );
  }
  
  export default NASActivities;
  