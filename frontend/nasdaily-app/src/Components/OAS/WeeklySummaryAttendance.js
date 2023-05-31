import React, { Component } from 'react';
import './WeeklySummaryAttendance.css';

class WeeklySummaryAttendance extends Component {
  render() {
    const { attend } = this.props;

    return (
      <>
        <div className="tableData">
          <table>
            <tr>
              <th className="weekly">DATE</th>
              <th className="weekly">TIME-IN</th>
              <th className="weekly">TIME-OUT</th>
              <th className="weekly">ACTIVITIES DONE</th>
              <th className="weekly">SKILLS LEARNED</th>
              <th className="weekly">VALUES LEARNED</th>
            </tr>
            <tr>
              <td className="weekly">Dummy Text</td>
              <td className="weekly">Dummy Text</td>
              <td className="weekly">Dummy Text</td>
              <td className="weekly">Dummy Text</td>
              <td className="weekly">Dummy Text</td>
              <td className="weekly">Dummy Text</td>
            </tr>
          </table>
        </div>
      </>
    );
  }
}

export default WeeklySummaryAttendance;