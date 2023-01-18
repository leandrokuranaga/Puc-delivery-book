import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import FavoriteRoundedIcon from '@material-ui/icons/FavoriteRounded';
import CloseRoundedIcon from '@material-ui/icons/CloseRounded';
import ListRoundedIcon from '@material-ui/icons/ListRounded';
import { IconButton } from '@material-ui/core';

const useStyles = makeStyles(() => ({
  root: {
    position: 'absolute',
    bottom: '5vh',
    display: 'flex',
    width: '100%',
    justifyContent: 'space-evenly',
    '& .MuiIconButton-root': {
      backgroundColor: '#0c0a29',
      boxShadow: 'rgb(0 0 0 / 75%) 0px 5px 15px',
      maxWidth: '60px',
      maxHeight: '60px',
    },
  },
  likeButton: {
    padding: '2vw',
    color: '#76e2b3',
  },
  deslikeButton: {
    padding: '2vw',
    color: '#ec5e6f',
  },
  descriptionButton: {
    padding: '2vw',
    color: '#FFF',
  },
}));

/* eslint-disable react/prop-types */
function SwipeButtons(props) {
  const classes = useStyles();

  return (
    <div className={classes.root}>
      <IconButton onClick={() => props.swipeRef.current('left')} className={classes.likeButton}>
        <FavoriteRoundedIcon fontSize="large" />
      </IconButton>
      <IconButton onClick={() => props.detailsRef.current()} className={classes.descriptionButton}>
        <ListRoundedIcon fontSize="large" />
      </IconButton>
      <IconButton onClick={() => props.swipeRef.current('right')} className={classes.deslikeButton}>
        <CloseRoundedIcon fontSize="large" />
      </IconButton>
    </div>
  );
}

export default SwipeButtons;
