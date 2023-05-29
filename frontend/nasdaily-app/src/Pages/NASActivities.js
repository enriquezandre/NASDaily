import React from 'react'
import Header from '../Components/Header'
import './NAS.css';
import Dropdown from 'react-bootstrap/Dropdown';

function NASActivities() {
    return (
      <>
        <Header username="USERNAME" />
        <div className='nasactivity-main-container'>
          <div className='nasmenu-button-container'>
            <button className='nasbtn-menu'>PERSONAL INFORMATION</button>
            <button className='nasbtn-menu'>ATTENDANCE SUMMARY</button>
            <button className='nasbtn-menu'>ACTIVITIES SUMMARY</button>
            <button className='nasbtn-menu'>SCHEDULE OF DUTY</button>
            <button className='nasbtn-menu'>EVALUATION RESULT</button>
          </div>
          <div className='activities-container'>
            <div className='nas-details'>
              <p>SCHOLAR NAME:</p>
              <Dropdown>
                <Dropdown.Toggle variant="primary" id="month-dropdown" className="dropdown-toggle">
                  MONTH
                </Dropdown.Toggle>
                <Dropdown.Menu>
                  <Dropdown.Item href="#january">January</Dropdown.Item>
                  <Dropdown.Item href="#february">February</Dropdown.Item>
                  <Dropdown.Item href="#march">March</Dropdown.Item>
                  {/* Add more dropdown items for other months */}
                </Dropdown.Menu>
              </Dropdown>
            </div>
            <div className='activities-summary'>
                <p>ACTIVITIES SUMMARY</p>
              <table>
                <thead>
                  <tr>
                    <th>Date</th>
                    <th>Time-in</th>
                    <th>Time-out</th>
                  </tr>
                </thead>
                <tbody>
                  {/* Add table rows with data */}
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </>
    );
  }
  
  export default NASActivities;
  