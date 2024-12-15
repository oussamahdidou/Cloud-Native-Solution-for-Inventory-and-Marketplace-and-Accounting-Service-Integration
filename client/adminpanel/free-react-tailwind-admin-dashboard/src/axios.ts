import axios from 'axios';

export const api = axios.create({
  baseURL: 'http://localhost:5000/gateway/',
  headers: {
    'Content-Type': 'application/json',
  },
});
export const filesapi = axios.create({
  baseURL: 'http://localhost:5000/gateway/',
  headers: {
    'Content-Type': 'multipart/form-data',
  },
});
