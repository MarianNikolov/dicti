import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { FetchData } from './components/FetchData';
import { TranslationsData } from './components/TranslationsData';
import AddTranslationComponent from './components/AddTranslationComponent';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route path='/add-translation' component={AddTranslationComponent} />
        <Route path='/fetch-data' component={FetchData} />
        <Route path='/translations-data' component={TranslationsData} />
      </Layout>
    );
  }
}
