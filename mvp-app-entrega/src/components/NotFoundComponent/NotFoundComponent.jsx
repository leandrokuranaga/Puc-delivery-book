import React from 'react';
import { Typography } from '@material-ui/core';
import NightsStayRoundedIcon from '@material-ui/icons/NightsStayRounded';
import { makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles((dark) => ({
  notFoundContainer: {
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'center',
    flexDirection: 'column',
    minHeight: '60vh',
    marginTop: dark ? '-40px' : '0px',
  },
  notFoundTitle: {
    color: dark ? '#707072' : '#FFF',
    fontFamily: 'NexaBold',
    fontSize: '20px',
  },
  moonIcon: {
    color: dark ? '#707072' : '#FFF',
    fontSize: '80px',
    marginBottom: '15px',
  },
}));

/* eslint-disable react/prop-types */
function NotFoundComponent({ dark }) {
  const classes = useStyles(dark);

  return (
    <div className={classes.notFoundContainer}>
      <NightsStayRoundedIcon className={classes.moonIcon} />
      <Typography className={classes.notFoundTitle}>Nenhum livro encontrado!</Typography>
    </div>
  );
}

export default NotFoundComponent;
