import React, { Component } from 'react';
import WeeklySummaryAttendance from './WeeklySummaryAttendance';
import './SummaryAttendanceOAS.css';

class SummaryAttendanceOAS extends Component {

  render() {
    const { check, logTable, selectedMonth } = this.props;

    return (
      <>
        {check ? (
          <div>
            <div className="weeklySummaryOfAttendance">
              <h4 className="title">WEEKLY ATTENDANCE</h4>
              <WeeklySummaryAttendance attend={logTable} selectedMonth={selectedMonth} />
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