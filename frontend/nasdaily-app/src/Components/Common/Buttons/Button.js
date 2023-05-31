import React, { Component } from 'react';
import '../Buttons/ButtonStyle.css';

class Button extends Component {
  render() {
    const { style, onClick, name } = this.props;

    return (
      <div>
        <button className={style} onClick={onClick}>{name}</button>
      </div>
    );
  }
}

export default Button;