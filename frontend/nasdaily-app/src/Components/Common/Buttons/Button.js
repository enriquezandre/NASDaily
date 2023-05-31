import React from 'react'
import '../Buttons/ButtonStyle.css'

const Button = ({ style, onClick, name }) => {
    return (
        <div>
            <button className={style} onClick={onClick}> {name} </button>
        </div>
    );
};

export default Button;