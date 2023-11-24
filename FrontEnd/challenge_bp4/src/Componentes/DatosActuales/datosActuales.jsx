import './datosActuales.css'

function DatosActuales({datos}) {
 
 
  return (
    <>
      <div className='container-datos'>
        <h3>{datos.temperatura}°</h3>
        <img src={`https://openweathermap.org/img/wn/${datos.icon}@2x.png`} alt="" />
        <label htmlFor="">Mínimo: {datos.temperaturaMinima}°</label>
        <label htmlFor="">Máximo: {datos.temperaturaMaxima}° </label>
        <label htmlFor="">Humedad: {datos.humedad}% </label>
      </div>
    </>
 )
}

export default DatosActuales