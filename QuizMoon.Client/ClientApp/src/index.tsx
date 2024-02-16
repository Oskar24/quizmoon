import React from 'react';
import { createRoot } from 'react-dom/client';
import App from './App';
// import * as serviceWorkerRegistration from './serviceWorkerRegistration';
// import reportWebVitals from './reportWebVitals';
import GlobalStyles from './globalStyles';
import axios from 'axios';


const rootElement = document.getElementById('root');
if (rootElement) {
  axios.defaults.withCredentials = true;
  createRoot(rootElement).render(
    <>
      <GlobalStyles />
      <App />
    </>
  );
} else {
  console.error("Root element not found");
}

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://cra.link/PWA
// serviceWorkerRegistration.unregister();

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
// reportWebVitals();