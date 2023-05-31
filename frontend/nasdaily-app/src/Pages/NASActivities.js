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
              <p>SCHOLAR NAME:</p>
                <div className='dropDownButtons'>
                  <label>
                      MONTH:
                      <select>
                          <option value="month">January</option>
                          <option value="month">February</option>
                          <option value="month">March</option>
                          <option value="month">April</option>
                          <option value="month">May</option>
                      </select>
                  </label>
                </div>
            </div>
            <div className='activities-summary'>
                <p>ACTIVITIES SUMMARY</p>
              <table>
                <thead>
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
                  <td>asdasd</td>
                  <td>asdasd</td>
                  <td>asdasd</td>
                  <td>asdasd</td>
                  <td>asdasd</td>
                  <td>asdasd</td>
                </tbody>
                <tbody>
                  <td>asdasd</td>
                  <td>asdasd</td>
                  <td>asdasd</td>
                  <td>asdasd</td>
                  <td>asdasd</td>
                  <td>asdasd</td>
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </>
    );
  }
  
  export default NASActivities;
  