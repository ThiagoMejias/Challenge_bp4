import './DatosProximasHoras.css'



function DatosProximasHoras({datos}) {

  return (
    <>
      <div className='container-datos'>
        <label className='label-datos'>{datos.fecha.toLocaleDateString()}</label>
        <img className='icon-clima' src={`https://openweathermap.org/img/wn/${datos.icon}@2x.png`} alt="" />
        <label className='label-datos'>{datos.temperatura}° </label>
      </div>
    </>
 )
}

export default DatosProximasHoras