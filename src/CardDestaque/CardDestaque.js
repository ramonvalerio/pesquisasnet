import React from 'react';
import './CardDestaque.css';
import imagem from '../sky-tower.jpg';

function CardDestaque() {
    return (
        <div className="CardDestaque-item">
            <div className="CardDestaque-title">
                <span>Sky Tower</span>
            </div>
            <img src={imagem} alt="Sky Tower" height={200}></img>
            <div className="CardDestaque-info">
                <p>
                    A Sky Tower é uma torre de comunicação e observação erguida na cidade de Auckland, na Nova Zelândia durante da década de 1990. Com 328 metros de altura constitui a estrutura mais alta do Hemisfério Sul e uma das torres mais altas da atualidade. Tornou-se o ícone de Auckland, atraindo milhares de turistas anualmente.
                </p>
            </div>
            <div className="CardDestaque-panel">
                <span>R$ 120,00</span>
            </div>
        </div>
    );
  }
  
  export default CardDestaque;