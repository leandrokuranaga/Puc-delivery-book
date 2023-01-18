import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import { Typography, Grid, Container } from '@material-ui/core';
import Accordion from '@material-ui/core/Accordion';
import AccordionSummary from '@material-ui/core/AccordionSummary';
import AccordionDetails from '@material-ui/core/AccordionDetails';
import ExpandMoreIcon from '@material-ui/icons/ExpandMore';

const useStyles = makeStyles(() => ({
  root: {},
  heading: {
    fontFamily: 'NexaLight',
    fontSize: '18px',
    color: '#FFF',
  },
  titulo: {
    color: '#FFF',
    fontSize: '23px',
    fontFamily: 'NexaBold',
  },
  container: {
    paddingTop: '120px',
    paddingBottom: '80px',
  },
  divider: {
    height: '6px',
    background: 'linear-gradient(to right, rgb(75, 161, 216), rgb(68, 100, 189) 95%)',
    width: '8%',
  },
  accordion: {
    boxShadow: 'none',
    border: 'none',
    backgroundColor: 'rgb(8, 21, 63)',
    marginBottom: '5px',
  },
  iconExpand: {
    color: '#FFF',
  },
  summary: {
    boxShadow: 'none',
    border: 'none',
    padding: '15px',
  },
  details: {
    border: 'none',
  },
  detailsText: {
    color: '#FFF',
  },
  answer: {
    fontFamily: 'NexaRegular',
  },
}));

function FaqContainer() {
  const classes = useStyles();

  const questions = [
    'Como realizar o Login na página?',
    'Como realizar a troca ou compra de livros?',
    'Como acessar os audiobooks?',
    'Posso trocar qualquer livro?',
  ];

  const answers = [
    <Typography className={classes.answer}>
      Basta clicar na opção &quot;Entrar&quot;, localizada no canto superior direito, e escolher
      a contaGoogle para acesso.
    </Typography>,
    <Typography className={classes.answer}>
      Após realizar o Login na página, basta escolher entre as opções &quot;Trocar&quot;,
      &quot;Buscar&quot; ou &quot;Pontos de troca&quot;,localizadas no canto superior esquerdo
      da página, para selecionar os livros que deseja trocar ou comprar.
    </Typography>,
    <Typography className={classes.answer}>
      Após realizar o Login na página, basta escolher a opção &quot;Podcasts&quot;,
      localizada no canto superior esquerdo da página, para selecionar o audiobook
      que deseja escutar.
      <br />
    </Typography>,
    <Typography className={classes.answer}>
      A resposta é SIM! Basta você encontrar o seu livro que deseja de preferência através das
      opções de troca.
      Lembrando que a possibilidade de comprar o livro também está disponível acessando as
      opções de compra.
    </Typography>,
  ];

  return (
    <div className={classes.root}>
      <Container className={classes.container}>
        <Grid container>
          <Grid md={12} xs={12}>
            <Typography className={classes.titulo}>Dúvidas frequentes</Typography>
            <br />
            <div className={classes.divider} />
          </Grid>
        </Grid>
        <br />
        <br />
        {(questions).map((questao, index) => (
          <>
            <Accordion className={classes.accordion}>
              <AccordionSummary
                expandIcon={<ExpandMoreIcon className={classes.iconExpand} />}
                aria-controls="panel1a-content"
                id="panel1a-header"
                className={classes.summary}
              >
                <Typography className={classes.heading}>{questao}</Typography>
              </AccordionSummary>
              <AccordionDetails className={classes.details}>
                <Typography className={classes.detailsText}>
                  {answers[index]}
                </Typography>
              </AccordionDetails>
            </Accordion>
          </>
        ))}
      </Container>
    </div>
  );
}

export default FaqContainer;
