import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import Header from '../Components/Header';
import { Link } from 'react-router-dom';
import './NAS.css';

function NASActivities() {
  const { username } = useParams();
  const [user, setUser] = useState(null);
  const [logs, setLogs] = useState([]);
  const [selectedMonth, setSelectedMonth] = useState('');

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

  const handleMonthChange = (event) => {
    setSelectedMonth(event.target.value);
  };

  const filteredLogs = selectedMonth
    ? logs.filter((log) => {
        const logDate = new Date(log.timeIn);
        const logMonth = logDate.getMonth() + 1;
        return logMonth === parseInt(selectedMonth);
      })
    : logs;

  return (
    <>
      <Header username={username} />
      <div className='nasactivity-main-container'>
        <div className='nasmenu-button-container'>
          <button className='nasbtn-menu not-active'>PERSONAL INFORMATION</button>
          <button className='nasbtn-menu active'>ATTENDANCE SUMMARY</button>
          <button className='nasbtn-menu not-active'>SCHEDULE OF DUTY</button>
          <button className='nasbtn-menu not-active'>EVALUATION RESULT</button>
        </div>
        <div className='result-container'>
          <div className='back-button-container'>
            <Link to={`/${username}/timeinout`}>
              <button className='back-button'>{'<<'} Go back to time-in</button>
            </Link>
          </div>
          <div className='nas-details'>
            <p>SCHOLAR NAME: {user?.name}</p>
            <div>
              <label>
                MONTH:
                <select className='attendance-month-dropdown' onChange={handleMonthChange} value={selectedMonth}>
                  <option value="">All Months</option>
                  <option value="1">January</option>
                  <option value="2">February</option>
                  <option value="3">March</option>
                  <option value="4">April</option>
                  <option value="5">May</option>
                  <option value="6">June</option>
                  <option value="7">July</option>
                  <option value="8">August</option>
                  <option value="9">September</option>
                  <option value="10">October</option>
                  <option value="10">November</option>
                  <option value="10">December</option>
                </select>
              </label>
            </div>
          </div>
          <div className='attendance-summary'>
            <p>ACTIVITIES SUMMARY:</p>
            <br />
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
                {filteredLogs.map((log) => {
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
