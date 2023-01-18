import React, { lazy, Suspense } from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import { Provider } from 'react-redux';
import store from './store';

const HomePage = lazy(() => import('./views/HomePage'));
const SwapPage = lazy(() => import('./views/SwapPage'));
const SearchPage = lazy(() => import('./views/SearchPage'));
const PodcastShows = lazy(() => import('./views/PodcastPageShows'));
const MapsPage = lazy(() => import('./views/MapsPage'));
const CreatePoint = lazy(() => import('./views/CreatePoint'));
const RentedBooks = lazy(() => import('./views/RentedBooks'));
const ReservedBooks = lazy(() => import('./views/ReservedBooks'));

export default function Routes() {
  return (
    <Provider store={store}>
      <BrowserRouter>
        <Switch>
          <Suspense fallback={<div style={{ backgroundColor: '#03103B', width: '100vw', height: '100vh' }} />}>
            <Route path="/" exact component={() => <HomePage />} />
            <Route path="/trocar" exact component={() => <SwapPage />} />
            <Route path="/buscar" exact component={() => <SearchPage />} />
            <Route path="/escutar" exact component={() => <PodcastShows />} />
            <Route path="/maps" exact component={() => <MapsPage />} />
            <Route path="/criarPonto" exact component={() => <CreatePoint />} />
            <Route path="/livros-alugados" exact component={() => <RentedBooks />} />
            <Route path="/livros-reservados" exact component={() => <ReservedBooks />} />
          </Suspense>
        </Switch>
      </BrowserRouter>
    </Provider>
  );
}
