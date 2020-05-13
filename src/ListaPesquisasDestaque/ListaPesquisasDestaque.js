import React from 'react';
import './ListaPesquisasDestaque.css';
import CardDestaque from '../CardDestaque/CardDestaque'

function ListaPesquisasDestaque() {
    return (
        <div>
            <div className="CardDestaque-container">
                <CardDestaque />
                <CardDestaque />
                <CardDestaque />
            </div>
        </div>
    );
  }
  
  export default ListaPesquisasDestaque;