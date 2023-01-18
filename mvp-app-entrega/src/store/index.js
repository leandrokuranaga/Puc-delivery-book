import { createStore, combineReducers } from 'redux';
import storeSynchronize, { defineState } from 'redux-localstore';

const INICIAL_STATE = {
  token: null,
};

const initialState = defineState(INICIAL_STATE)('Reducer');

function Reducer(state = initialState, action) {
  switch (action.type) {
    case 'SET_TOKEN':
      return { ...state, token: action.token };
    default:
      return state;
  }
}

const combineReducer = combineReducers({
  Reducer,
});

const store = createStore(combineReducer);
storeSynchronize(store);

export default store;
