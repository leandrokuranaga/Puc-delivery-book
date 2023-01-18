import firebase from 'firebase/app';
import 'firebase/auth';
import store from './store';
import AuthAction from './store/actions';

export const app = firebase.initializeApp({
  apiKey: 'AIzaSyBGdp6IO0-IFF1HJyhPD-dhxMX70qjdk_8',
  authDomain: 'poc-app-entrega.firebaseapp.com',
  projectId: 'poc-app-entrega',
  storageBucket: 'poc-app-entrega.appspot.com',
  messagingSenderId: '129930617333',
  appId: '1:129930617333:web:62f5c4b346d54b37bb00bc',
});

export const auth = firebase.auth();
const googleProvider = new firebase.auth.GoogleAuthProvider();
export const signInWithGoogle = () => {
  auth.signInWithPopup(googleProvider).then(() => {
    auth
      .currentUser
      .getIdToken()
      .then((idToken) => {
        store.dispatch(AuthAction(idToken));
        window.location.href = '/buscar';
      }).catch(() => {
      });
  }).catch(() => {
  });
};
