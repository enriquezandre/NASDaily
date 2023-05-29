import React from 'react'
import '../Buttons/ButtonStyle.css'

const Button = ({ onClick, name }) => {
    return (
        <div>
            <button className="yellow-button" onClick={onClick}> {name} </button>
        </div>
    );
};

export default Button;