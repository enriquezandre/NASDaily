import React from 'react';
import { Navbar} from 'react-bootstrap';
import logo from "../images/navbar-nasdaily.png";
import "./Navigationbar.css";
import 'bootstrap/dist/css/bootstrap.min.css';

export const Navigationbar = () => {
  return (
    <>
      <Navbar className='navbar-expand-xl color-nav '>
            <img src={logo} alt='logo' className='navbar-logo-image' />
      </Navbar>
    </>
  );
};
