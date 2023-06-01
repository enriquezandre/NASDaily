import React, { Component } from 'react';
import './WeeklySummaryAttendance.css';

class WeeklySummaryAttendance extends Component {
  render() {
    const { attend, selectedMonth } = this.props;

    const filteredLogs = selectedMonth
    ? attend.filter((log) => {
        const logDate = new Date(log.timeIn);
        const logMonth = logDate.getMonth() + 1;
        return logMonth === parseInt(selectedMonth);
      })
    : attend;

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
                    <td className="weekly">{formatDate(timeIn)}</td>
                    <td className="weekly">{timeIn.toLocaleTimeString()}</td>
                    <td className="weekly">{timeOut.toLocaleTimeString()}</td>
                    <td className="weekly">{log.tasks.activitiesDone}</td>
                    <td className="weekly">{log.tasks.skillsLearned}</td>
                    <td className="weekly">{log.tasks.valuesLearned}</td>
                  </tr>
                );
              })}
            </tbody>
          </table>
        </div>
      </>
    );
  }
}

export default WeeklySummaryAttendance;