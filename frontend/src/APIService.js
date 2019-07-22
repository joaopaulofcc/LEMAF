import axios from 'axios';
const API_URL = 'https://localhost:5001';

export class APIService
{
    constructor()
    {
    }

    getAllTrips()
    {
        const url = `${API_URL}/trips/`;
        return axios.get(url).then(response => response);
    }

    getTripsByCity(cityId)
    {
        const url = `${API_URL}/trips/city/${cityId}`;
        return axios.get(url).then(response => response);
    }

}