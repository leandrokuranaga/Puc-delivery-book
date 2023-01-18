import React from 'react';
import { Grid, Typography } from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';
import blueBook from '../../imgs/book-image (1).png';

const useStyles = makeStyles(() => ({
  imagem: {
    width: '100%',
    height: 'auto',
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

function AboutContainer() {
  const classes = useStyles();

  return (
    <Grid container>
      <Grid item xs={12} md={6}>
        <img className={classes.imagem} src={blueBook} alt="blueBook" />
      </Grid>
      <Grid className={classes.textContainer} item xs={12} md={6}>
        <Typography className={classes.title}>
          Não julgue um livro pela Capa...
        </Typography>
        <Typography className={classes.content}>
          Não pense somente que são essas as opções que o BOOK&apos;s App
          pode oferecer. Além de trocas de livros, o usuário tem a disponibilidade
          também de acessar plataformas de audiobooks para pesquisar e ouvir.
          Basta acessar a opção &quote;Podcasts&quote; após realizar o Login na página.
        </Typography>
      </Grid>
    </Grid>
  );
}

export default AboutContainer;
