import React from 'react';
import { Grid, Typography } from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';
import BrazilMap from '../../imgs/brazil-map.png';
import BlueDot from '../../imgs/dotIcon.png';

const useStyles = makeStyles(() => ({
  title: {
    color: '#FFF',
    fontSize: '38px',
    fontFamily: 'NexaRegular',
    marginBottom: '20px',
    marginTop: '120px',
  },
  content: {
    color: 'rgb(73, 107, 150)',
    fontSize: '16px',
    lineHeight: '33px',
    fontWeight: '400',
    marginBottom: '20px',
    maxWidth: '900px',
  },
  whiteText: {
    color: '#FFF',
    fontSize: '16px',
    lineHeight: '33px',
    fontWeight: '400',
    marginBottom: '20px',
    maxWidth: '400px',
  },
  textContainer: {
    display: 'flex',
    flexDirection: 'column',
    justifyContent: 'center',
    alignItems: 'center',
    textAlign: 'center',
  },
  mapImage: {
    width: '100%',
    height: 'auto',
    marginTop: '-100px',
  },
  dotIcon: {
    boxShadow: '0px 0px 1px 1px #0000001a',
    animation: '$pulse-animation .8s infinite ease-out',
  },
  '@keyframes pulse-animation': {
    '0%': {
      boxShadow: '0 0 0 0px rgba(56, 195, 200, 0.2)',
      borderRadius: '50%',
    },
    '100%': {
      boxShadow: '0 0 0 20px rgba(56, 195, 200, 0)',
      borderRadius: '50%',
    },
  },
}));

function SwapMap() {
  const classes = useStyles();

  return (
    <Grid container>
      <Grid className={classes.textContainer} item xs={12} md={12}>
        <Typography className={classes.title}>
          Escolhendo seus pontos de troca!
        </Typography>
        <Typography className={classes.content}>
          Aqui no BOOK&apos;s App você pode consultar e criar pontos específicos no mapa
          para realizar a troca de Livros com outro usuário.
          Basta acessar a opção &quot;Pontos de troca&quot; disponível ao realizar o Login
          na página e interagir.
        </Typography>
        <div style={{ position: 'relative' }}>
          <img className={classes.mapImage} src={BrazilMap} alt="brazilMap" />
          <img className={classes.dotIcon} style={{ position: 'absolute', top: '20%', left: '60%' }} src={BlueDot} alt="blueDot" />
          <img className={classes.dotIcon} style={{ position: 'absolute', top: '30%', left: '30%' }} src={BlueDot} alt="blueDot" />
          <img className={classes.dotIcon} style={{ position: 'absolute', top: '45%', left: '70%' }} src={BlueDot} alt="blueDot" />
          <img className={classes.dotIcon} style={{ position: 'absolute', top: '70%', left: '55%' }} src={BlueDot} alt="blueDot" />
          <img className={classes.dotIcon} style={{ position: 'absolute', top: '40%', left: '45%' }} src={BlueDot} alt="blueDot" />

        </div>
      </Grid>
    </Grid>
  );
}

export default SwapMap;
