import React, { useState } from 'react'
import Button from '../Components/Common/Buttons/Button.jsx'
import '../Pages/Attendance.css'

export const Attendance = () => {
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
                    
                </div>
            </div>
        </>
    )
}