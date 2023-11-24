import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import CartaClima from './Componentes/CartaClima/cartaClima'
import MetaWeatherRequest from './Services/MetaWeather'

function App() {
  
  return (
    <div className='container-card-clima'>
      <CartaClima></CartaClima>
    </div>
  )
} 

export default App
