import axios from 'axios';

const api = axios.create({
  baseURL: 'https://deliverybook-api.azurewebsites.net/api/v1',
});

export default api;
