import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import ImportContactsOutlinedIcon from '@material-ui/icons/ImportContactsOutlined';
import Hidden from '@material-ui/core/Hidden';
import { Button, Typography } from '@material-ui/core';
import { signInWithGoogle } from '../../../../Firebase';

const useStyles = makeStyles(() => ({
  root: {
    width: '100%',
    display: 'flex',
    justifyContent: 'space-between',
  },
  topLogo: {
    color: '#FFF',
    fontSize: '50px',
    marginLeft: '50px',
  },
  rightItems: {
    display: 'flex',
    alignItems: 'center',
    color: '#FFF',
    marginRight: '50px',
  },
  linkItem: {
    marginLeft: '40px',
    fontFamily: 'NexaRegular',
    cursor: 'pointer',
  },
  loginButton: {
    marginLeft: '40px',
    background: 'linear-gradient(to right, rgb(75, 161, 216), rgb(68, 100, 189) 95%)',
    width: '100px',
    fontFamily: 'NexaRegular',
    color: '#FFF',
    textTransform: 'none',
    height: 'fit-content',
    cursor: 'pointer',
  },
}));

/* eslint-disable react/prop-types */
function TopMenu({ clickIntroduction, clickAbout, clickFaq }) {
  const classes = useStyles();

  return (
    <div className={classes.root}>
      <ImportContactsOutlinedIcon className={classes.topLogo} />
      <div className={classes.rightItems}>
        <Hidden xsDown>
          <Typography
            onClick={clickIntroduction}
            className={classes.linkItem}
          >
            Features chave
          </Typography>
          <Typography onClick={clickAbout} className={classes.linkItem}>Conheça</Typography>
          <Typography onClick={clickFaq} className={classes.linkItem}>FAQ</Typography>
        </Hidden>
        <Button
          onClick={() => signInWithGoogle()}
          className={classes.loginButton}
        >
          Entrar
        </Button>
      </div>
    </div>
  );
}

export default TopMenu;
