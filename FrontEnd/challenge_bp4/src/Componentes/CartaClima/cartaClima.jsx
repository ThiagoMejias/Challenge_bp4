import './CartaClima.css'
import MetaWeatherRequest from '../../Services/MetaWeather';
import Clima from '../Clima/clima';
import { ciudadesImportantes } from '../../Datos/ciudades';
function CartaClima() {
  return (
    <>
      <div className='card-clima'>
        <h4 className='titulo'>Consulte el clima!</h4>
        <Clima></Clima>
      </div>
    </>
 )
}

export default CartaClima