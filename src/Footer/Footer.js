import React from 'react';
import './Footer.css';

function Footer() {
    var dateNow = new Date;
    var currentYear = dateNow.getFullYear();
    return (
        <div className="Footer">
            <p>© PesquisasNet {currentYear} PesquisasNet.com - All Rights Reserved - Legal</p>
        </div>
    );
  }
  
  export default Footer;