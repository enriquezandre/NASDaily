import React from 'react'
import MonthlySummaryAbsent from './MonthlySummaryAbsent';
import WeeklySummaryAttendance from './WeeklySummaryAttendance';
import './SummaryAttendanceOAS.css'

const SummaryAttendanceOAS = ({ totalLates, unexcusedAbsent, excusedAbsent, tenMinLate, fortyFiveMinLate, ftp }) => {
    const attend = [
        { 
            date: "05/30/2023",
            timein: "08:00 AM",
            timeout: "08:00 AM",
            actsDone: "Dummy Text",
            skillsLearned: "Dummy Text",
            valuesLearned: "Dummy Text"
        },
        { 
            date: "05/30/2023",
            timein: "08:00 AM",
            timeout: "08:00 AM",
            actsDone: "Dummy Text",
            skillsLearned: "Dummy Text",
            valuesLearned: "Dummy Text"
        }
    ]
    return (
        <>
            <div>
                <div className='monthlySummaryOfAbsences'>
                    <h4 className='title'>MONTHLY SUMMARY OF ABSENCES/LATE</h4>
                    <MonthlySummaryAbsent
                            totalLates={2}
                            unexcusedAbsent={1}
                            excusedAbsent={1}
                            tenMinLate={1}
                            fortyFiveMinLate={1}
                            ftp={1} 
                    />
                </div>

                <br/>

                <div className='weeklySummaryOfAttendance'>
                    <h4 className='title'>WEEKLY ATTENDANCE</h4>
                    <WeeklySummaryAttendance attend={attend}/>
                </div>

                <br/>
            </div>
        </>
    )
};

export default SummaryAttendanceOAS;