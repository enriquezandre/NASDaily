import React, { useState } from 'react'
import Button from '../Components/Common/Buttons/Button.jsx'
import '../Pages/Attendance.css'
import Header from '../Components/Header.js'
import SummaryAttendanceOAS from '../Components/Common/Tables/SummaryAttendanceOAS.jsx'

export const Attendance = () => {
    const [searchTerm, setSearchTerm] = useState('');
    const [fullName, setFullName] = useState('');
    const [check, setCheck] = useState(false);

    const handleSearch = (e) => {
        e.preventDefault();
        
        setFullName("BELDEROL, KAYE CASSANDRA");
        setCheck(true)
    }

    return (
        <>
            <div>
                <Header username={"OAS"} onLogout={null}/>

                <div className='menuNav'>
                    <Button
                        style={"yellow-button"}
                        onClick={null}
                        name={"Offices"}
                    />
                    <Button
                        style={"red-button"}
                        onClick={null}
                        name={"Attendance"}
                    />
                    <Button
                        style={"yellow-button"}
                        onClick={null}
                        name={"Evaluation"}
                    />
                    <Button
                        style={"yellow-button"}
                        onClick={null}
                        name={"Grades"}
                    />
                    <Button
                        style={"yellow-button"}
                        onClick={null}
                        name={"Validation"}
                    />
                    <Button
                        style={"yellow-button"}
                        onClick={null}
                        name={"NAS Master List"}
                    />
                </div>
                
                <div className='row'>
                    <div className='heading'>
                        <p className='name'>{fullName}</p>
                        <form className='searchBar' onSubmit={handleSearch}>
                            <input
                                className='searchBarInput'
                                type='text'
                                placeholder='Search...'
                                value={searchTerm}
                                onChange={(e) => setSearchTerm(e.target.value)}
                            />
                            <button type='submit'>
                                <i className='material-icons search-icon'>search</i>
                            </button>
                        </form>
                    </div>

                    <div className='dropDownButtons'>
                        <label className='labelDropDown'>
                            SEMESTER:
                            <select>
                                <option value="semester">2nd Semester 2022-2023</option>
                            </select>
                        </label>
                        <label className='labelDropDown'>
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
                    
                    <div className='data'>
                        <SummaryAttendanceOAS
                            check={check}
                            totalLates={2}
                            unexcusedAbsent={1}
                            excusedAbsent={1}
                            tenMinLate={1}
                            fortyFiveMinLate={1}
                            ftp={1} 
                        />
                    </div>
                </div>
            </div>
        </>
    )
}