import axios from 'axios';

export const api = axios.create({
  baseURL: 'http://159.89.248.249:80/gateway/',
  headers: {
    'Content-Type': 'application/json',
  },
});
export const filesapi = axios.create({
  baseURL: 'http://159.89.248.249:80/gateway/',
  headers: {
    'Content-Type': 'multipart/form-data',
  },
});
