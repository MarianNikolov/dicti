import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import App from './App';
import registerServiceWorker from './registerServiceWorker';
import RestService from './RestServices/restService';
import dev_config from './config/development.config.json';
import prod_config from './config/production.config.json';

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');

console.log(process.env)
if (process.env.NODE_ENV === "development") {
	RestService.setDomainUrl(dev_config)
}

if (process.env.NODE_ENV === "production") {
	RestService.setDomainUrl(prod_config)
}

ReactDOM.render(
  <BrowserRouter basename={baseUrl}>
    <App />
  </BrowserRouter>,
  rootElement);

registerServiceWorker();

