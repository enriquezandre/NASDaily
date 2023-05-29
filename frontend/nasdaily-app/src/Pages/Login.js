import React from 'react'
import "./Login.css";
import bg from "../images/glebuilding.png";

export const Login = () => {
    return (
        <>
            <div className='center-container'>
                <div className='main-container'>
                    <div className='image-container'>
                        <img src={bg} alt='glebuilding' className='bg-container' />
                    </div>
                    <div className='text-container'>
                        <span className='text-login'>LOGIN</span>
                        <div className='input-container'>
                            <label htmlFor='username' className='input-label'>
                            Enter Username
                            </label>
                            <input type='text' id='username' className='text-input' />
                            <label htmlFor='password' className='input-label'>
                            Enter Password
                            </label>
                            <input type='password' id='password' className='text-input'/>
                            <input type='submit' className='button-submit'/>
                        </div>
                    </div>
                </div>
            </div>
        </>
    );
}
