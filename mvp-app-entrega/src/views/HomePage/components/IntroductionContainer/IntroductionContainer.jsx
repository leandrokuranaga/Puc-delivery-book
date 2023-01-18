import React from 'react';
import { Grid, Typography } from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';
import blueBook from '../../imgs/book-image (3).png';

const useStyles = makeStyles(() => ({
  imagem: {
    width: '100%',
    height: 'auto',
  },
  container: {
    marginTop: '40px',
  },
  title: {
    color: '#FFF',
    fontSize: '38px',
    fontFamily: 'NexaRegular',
    marginBottom: '20px',
  },
  content: {
    color: 'rgb(73, 107, 150)',
    fontSize: '16px',
    lineHeight: '33px',
    fontWeight: '400',
    marginBottom: '35px',
  },
  textContainer: {
    display: 'flex',
    flexDirection: 'column',
    justifyContent: 'center',
  },
}));

function IntroductionContainer() {
  const classes = useStyles();

  return (
    <Grid className={classes.container} container>
      <Grid className={classes.textContainer} item xs={12} md={6}>
        <Typography className={classes.title}>
          Bem-vindo ao BOOK&apos;s APP!
        </Typography>
        <Typography className={classes.content}>
          O BOOK&apos;s App tem o objetivo de proporcionar uma experiência
          bastante interessante ao usuário envolvendo livros,
          onde este poderá interagir tanto com outro usuário para trocar livros
          quanto interagir em plataformas que possibilitem a compra deste.
          E se quiser saber o que mais esse interessante App pode proporcionar,
          arraste para baixo e confira!
        </Typography>
      </Grid>
      <Grid item xs={12} md={6}>
        <img className={classes.imagem} src={blueBook} alt="blueBook" />
      </Grid>
    </Grid>
  );
}

export default IntroductionContainer;
