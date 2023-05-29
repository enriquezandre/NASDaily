import React, { useState } from 'react'
import Button from '../Components/Common/Buttons/Button.jsx'
import '../Pages/Attendance.css'

export const Attendance = () => {
    const [searchTerm, setSearchTerm] = useState('');
    return (
        <>
            <div>
                <br />
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
                        <p className='name'>Belderol, Kaye Cassandra</p>
                        <form className='searchBar' onSubmit={null}>
                            <input
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
                    <div className='data'>
                        <p>Test Here!</p>
                    </div>
                </div>
            </div>
        </>
    )
}