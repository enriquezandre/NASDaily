import React, { Component } from 'react';
import WeeklySummaryAttendance from './WeeklySummaryAttendance';
import './SummaryAttendanceOAS.css';

class SummaryAttendanceOAS extends Component {
  render() {
    const { check } = this.props;

    const attend = [
      {
        date: '05/30/2023',
        timein: '08:00 AM',
        timeout: '08:00 AM',
        actsDone: 'Dummy Text',
        skillsLearned: 'Dummy Text',
        valuesLearned: 'Dummy Text',
      },
      {
        date: '05/30/2023',
        timein: '08:00 AM',
        timeout: '08:00 AM',
        actsDone: 'Dummy Text',
        skillsLearned: 'Dummy Text',
        valuesLearned: 'Dummy Text',
      },
    ];

    return (
      <>
        {check ? (
          <div>
            <div className="weeklySummaryOfAttendance">
              <h4 className="title">WEEKLY ATTENDANCE</h4>
              <WeeklySummaryAttendance attend={attend} />
            </div>

            <br />
          </div>
        ) : (
          <p className="errorMessage">No information to display. Please click on the search bar to access information of a NAS.</p>
        )}
      </>
    );
  }
}

export default SummaryAttendanceOAS;