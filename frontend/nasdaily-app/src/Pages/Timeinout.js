import React from 'react'
import './Timeinout.css'
import Header from '../Components/Header'
import GLE from '../images/glebuilding.png'

function Timeinout() {
  return (
    <div>
        <Header username="Kaye Cassandra Belderol" />
        <div className="image-container">
            <img src={GLE} alt='GLE' className="image-size"/>
        </div>
    </div>
  )
}

export default Timeinout