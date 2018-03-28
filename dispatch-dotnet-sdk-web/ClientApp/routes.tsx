import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import Home from './components/Home';
import Counter from './components/Counter';
import BrandData from './components/BrandData';
import OrganizationData from './components/OrganizationData';
import UserData from './components/UserData';

export const routes = <Layout>
    <Route exact path='/' component={ Home } />
    <Route path='/brands/' component={ BrandData } />
    <Route path='/organizations/' component={ OrganizationData } />
    <Route path='/users/' component={ UserData } />
</Layout>;
