import React from 'react'
import './MonthlySummaryAbsent.css'

const MonthlySummaryAbsent = ({ totalLates, unexcusedAbsent, excusedAbsent, tenMinLate, fortyFiveMinLate, ftp }) => {
    return (
        <>
            <div className='tableData'>
                <table>
                    <tr>
                        <td className='monthly'>Number of lates</td>
                        <td className='monthly'>{totalLates}</td>
                        <td className='monthly'>Late {">"} 10 Minutes</td>
                        <td className='monthly'> {tenMinLate}</td>
                    </tr>
                    <tr>
                        <td className='monthly'>Number of Unexcused Absences</td>
                        <td className='monthly'>{unexcusedAbsent}</td>
                        <td className='monthly'>Late {">"} 45 Minutes</td>
                        <td className='monthly'>{fortyFiveMinLate}</td>
                    </tr>
                    <tr>
                        <td className='monthly'>Number of Excused Absences</td>
                        <td className='monthly'>{excusedAbsent}</td>
                        <td className='monthly'>FTP - Failure to Punch In/Out</td>
                        <td className='monthly'>{ftp}</td>
                    </tr>
                </table>
            </div>
        </>
    )
};

export default MonthlySummaryAbsent;