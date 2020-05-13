import React from 'react';
import './App.css';
import Header from '../Header/Header';
import Footer from '../Footer/Footer';
import ListaPesquisas from '../ListaPesquisas/ListaPesquisas';
import ListaPesquisasDestaque from '../ListaPesquisasDestaque/ListaPesquisasDestaque';

function App() {
  return (
    <div className="App">
      <Header />
      <div className="grid-container">
        <div className="item1"><ListaPesquisasDestaque /></div>  
        <div className="item2"><ListaPesquisas /></div>  
        <div className="item3"><Footer /></div>
      </div>
    </div>
  );
}

export default App;
