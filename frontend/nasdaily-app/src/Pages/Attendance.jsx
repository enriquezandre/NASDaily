import React, { useState } from 'react'
import Button from '../Components/Common/Buttons/Button.jsx'

export const Attendance = () => {
    return (
        <>
            <br />
            <div className='menuNav'>
                <Button
                    onClick={null}
                    name={"Offices"}
                />
                <Button
                    onClick={null}
                    name={"Attendance"}
                />
                <Button
                    onClick={null}
                    name={"Evaluation"}
                />
                <Button
                    onClick={null}
                    name={"Grades"}
                />
                <Button
                    onClick={null}
                    name={"Validation"}
                />
                <Button
                    onClick={null}
                    name={"NAS Master List"}
                />
            </div>
        </>
    );
};

export default Attendance;