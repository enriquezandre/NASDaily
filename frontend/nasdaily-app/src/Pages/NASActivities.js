import React from 'react'
import Header from '../Components/Header'
import './NAS.css';

function NASActivities() {
    return (
      <>
        <Header username="USERNAME" />
        <div className='nasactivity-main-container'>
          <div className='nasmenu-button-container'>
            <button className='nasbtn-menu'>PERSONAL INFORMATION</button>
            <button className='nasbtn-menu'>ATTENDANCE SUMMARY</button>
            <button className='nasbtn-menu'>SCHEDULE OF DUTY</button>
            <button className='nasbtn-menu'>EVALUATION RESULT</button>
          </div>
          <div className='result-container'>
            <div className='nas-details'>
              <p>SCHOLAR NAME: {'BELDEROL, KAYE CASSANDRA'}, {'20-2615-260'}</p>
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
                <thead style={{color: 'black', textTransform: 'uppercase'}}>
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
                  <td>{'Dummy Text'}</td>
                  <td>{'Dummy Text'}</td>
                  <td>{'Dummy Text'}</td>
                  <td>{'Dummy Text'}</td>
                  <td>{'Dummy Text'}</td>
                  <td>{'Dummy Text'}</td>
                </tbody>
                <tbody>
                  <td>{'Dummy Text'}</td>
                  <td>{'Dummy Text'}</td>
                  <td>{'Dummy Text'}</td>
                  <td>{'Dummy Text'}</td>
                  <td>{'Dummy Text'}</td>
                  <td>{'Dummy Text'}</td>
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </>
    );
  }
  
  export default NASActivities;
  