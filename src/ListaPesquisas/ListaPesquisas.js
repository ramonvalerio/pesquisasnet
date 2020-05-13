import React from 'react';
import './ListaPesquisas.css';
import Card from '../Card/Card'

function ListaPesquisas() {
    return (
        <div>
            <div className="card-container">
                <Card />
                <Card />
                <Card />
                <Card />
                <Card />
                <Card />
            </div>
        </div>
    );
  }
  
  export default ListaPesquisas;