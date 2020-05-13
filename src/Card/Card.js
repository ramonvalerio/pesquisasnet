import React from 'react';
import './Card.css';
import imagem from '../rio-de-janeiro.jpg';

function Card() {
    return (
        <div className="card-item">
            <div className="card-title">
                <span>Rio de Janeiro</span>
            </div>
            <img src={imagem} alt="Rio de Janeiro" height={200}></img>
        </div>
    );
  }
  
  export default Card;