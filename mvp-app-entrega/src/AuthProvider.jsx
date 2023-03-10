import React, { useEffect, useState } from 'react';
import { app } from './Firebase';

export const AuthContext = React.createContext();

/* eslint-disable react/prop-types */
export const AuthProvider = ({ children }) => {
  const [currentUser, setCurrentUser] = useState(null);

  useEffect(() => {
    app.auth().onAuthStateChanged(setCurrentUser);
  }, []);

  return (
    <AuthContext.Provider
      value={{
        currentUser,
      }}
    >
      {children}
    </AuthContext.Provider>
  );
};
