const apiKey = '8aebe29822cb8ac92cc26e3664eef0f9'


async function obtenerClimaProximasHoras(localidad) {
    const endpoint = `https://api.openweathermap.org/data/2.5/forecast?q=${localidad}&appid=${apiKey}`;


    const response = await fetch(endpoint)
        .then(response => response.json())
        .catch(error => console.error(error));

        console.log(response);
    return response;
}

async function obtenerClimaPorLocalidad(localidad) {
    const endpoint = `https://api.openweathermap.org/data/2.5/weather?q=${localidad}&appid=${apiKey}`;

    const response = await fetch(endpoint)
        .then(response => response.json())
        .catch(error => console.error(error));
    return response;
}

const MetaWeatherRequest = {
    obtenerClimaPorLocalidad,
    obtenerClimaProximasHoras
};




export default MetaWeatherRequest;