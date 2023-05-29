import React from 'react';
import { Navbar} from 'react-bootstrap';
import logo from "../images/CIT.png";
import "./Navigationbar.css";
import 'bootstrap/dist/css/bootstrap.min.css';

export const Navigationbar = () => {
  return (
    <>
      <Navbar className='color-nav'>
        <div className='navbar-content'>
          {/* <div className='oval'></div> */}
          <div className='navbar-logo-container'>
            <img src={logo} alt='logo' className='navbar-logo-image' />
          </div>
          <div className='brand-name'>
            <span className='citu-title'>CEBU INSTITUTE OF TECHNOLOGY - UNIVERSITY</span><br/><span className='nas-title'>Non-Academic Scholars' Daily</span>
          </div>
        </div>
      </Navbar>
    </>
  );
};
