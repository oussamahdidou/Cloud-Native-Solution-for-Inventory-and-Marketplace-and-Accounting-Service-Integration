import axios from 'axios';

const api = axios.create({
  baseURL: 'http://159.89.248.249:80/gateway/',
  headers: {
    'Content-Type': 'application/json',
  },
});

export default api;
