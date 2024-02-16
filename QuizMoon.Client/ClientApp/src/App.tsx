import React, { Component } from 'react';
import AppRoutes from './AppRoutes';
import Layout from './components/layout/Layout';
import store from './redux/store';
import { Provider } from 'react-redux';
import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import { fetchUserData } from './redux/actions/app.actions';

const router = createBrowserRouter(AppRoutes);

export default class App extends Component {

  componentDidMount(): void {
      store.dispatch(fetchUserData());
  }

  render() {
    return (
      <Provider store={store}>
        <Layout>
          <RouterProvider router={router} />
        </Layout>
      </Provider>
    );
  }
}

