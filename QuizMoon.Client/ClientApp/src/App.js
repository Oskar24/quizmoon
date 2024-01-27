import React, { Component } from 'react';
import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import Layout from './components/layout/Layout';

const router = createBrowserRouter(AppRoutes);

export default class App extends Component {

  render() {
    return (
      <Layout>
        <RouterProvider router={router} />
      </Layout>
    );
  }
}
