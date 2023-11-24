import './Clima.css'
import { ciudadesImportantes } from '../../Datos/ciudades';
import { useState } from 'react';
import MetaWeatherRequest from '../../Services/MetaWeather';
import DatosActuales from '../DatosActuales/datosActuales';
import DatosProximasHoras from '../DatosProximasHoras/DatosProximasHoras';


function Clima() {
  const [ciudadSeleccionada, setCiudadSeleccionada] = useState('');
  const [clima, setClima] = useState();
  const [ciudadBuscada, setCiudadBuscada] = useState()
  const [climaProximasHoras, setClimaProximasHoras] = useState();
  const handleChangeCiudad = (event) => {
    setCiudadSeleccionada(event.target.value);
  };

  function armarArrayTresRegistros(registros) {
    const cantidadDeRegistros = 4;
    let posicion = 7;
    const arrayObjetosClima = [];
    for (let index = 0; index < cantidadDeRegistros; index++) {
      
      const element = registros[posicion];
      let fechaEnMs = element.dt * 1000;
      let fechaCasteada = new Date(fechaEnMs);

      let objClima = {
        temperatura: kelvinACelsius(element.main.temp),
        humedad: element.main.humidity,
        icon: element.weather[0].icon,
        fecha: fechaCasteada,
      }

      arrayObjetosClima.push(objClima);
      posicion += 8;
    }
    return arrayObjetosClima
  }

  function kelvinACelsius(kelvin) {
    const celsius = kelvin - 273.15;

    return celsius.toFixed(1);
  }

  const obtenerClima = async () => {

    if (ciudadSeleccionada != "") {
      const response = await MetaWeatherRequest.obtenerClimaPorLocalidad(ciudadSeleccionada);
      const responseProximasHoras = await MetaWeatherRequest.obtenerClimaProximasHoras(ciudadSeleccionada);
      const arrayDeProximosRegistros = armarArrayTresRegistros(responseProximasHoras.list);
      console.log(arrayDeProximosRegistros);
      setClimaProximasHoras(arrayDeProximosRegistros);
      const clima = {
        temperaturaMinima: kelvinACelsius(response.main.temp_min),
        temperaturaMaxima: kelvinACelsius(response.main.temp_max),
        temperatura: kelvinACelsius(response.main.temp),
        humedad: response.main.humidity,
        icon: response.weather[0].icon
      }
      setClima(clima);
      setCiudadBuscada(ciudadSeleccionada)

    }

  }



  return (
    <>
      <div className='container-datos'>
        {ciudadBuscada ? (
          <h5>Clima en {ciudadBuscada}</h5>
        ) : <h4>Seleccione una ciudad</h4>}

        {clima && (
          <DatosActuales datos={clima} />
        )}

        <div className='container-proximas-horas' >
          {climaProximasHoras && (
            climaProximasHoras.map((registro, index) => (
              <DatosProximasHoras key={index} datos={registro}></DatosProximasHoras>
            )
            ))}
        </div>
        <div className='container-busqueda'>
          <select
            id='selectCiudades'
            name='ciudades'
            value={ciudadSeleccionada}
            onChange={handleChangeCiudad}
            className='form-control  w-75'
          >

            <option value="">Seleccione una ciudad</option>
            {ciudadesImportantes.map((ciudad, index) => (
              <option key={index} value={ciudad}>
                {ciudad}
              </option>
            ))}
          </select>

          <button className='btn btn-primary w-50' onClick={obtenerClima}>Ver clima</button>
        </div>
      </div>

    </>
  )
}

export default Clima