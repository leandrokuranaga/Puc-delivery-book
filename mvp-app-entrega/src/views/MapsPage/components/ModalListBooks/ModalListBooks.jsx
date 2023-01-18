import React, { useState } from 'react';
import {
  Grid,
  Typography,
  Button,
  Divider,
  TextField,
  CircularProgress,
} from '@material-ui/core';
import Modal from '@material-ui/core/Modal';
import Backdrop from '@material-ui/core/Backdrop';
import Fade from '@material-ui/core/Fade';
import Avatar from '@material-ui/core/Avatar';
import { makeStyles } from '@material-ui/core/styles';
import { useSelector } from 'react-redux';
import CheckCircleRoundedIcon from '@material-ui/icons/CheckCircleRounded';
import { Link } from 'react-router-dom';
import {
  NotFoundComponent,
  SnackbarComponent,
} from '../../../../components';
import api from '../../../../services/api';
import blueBook from '../../../HomePage/imgs/book.png';

const useStyles = makeStyles((theme) => ({
  paperModalAlterar: {
    backgroundColor: theme.palette.background.paper,
    padding: '38px',
    borderRadius: '8px',
    border: 'none',
    display: 'flex',
    position: 'absolute',
    flexDirection: 'column',
    '@media (min-width:350px)': {
      width: '100vw',
      height: '80vh',
      bottom: '0px',
    },
    '@media (min-width:780px)': {
      width: '65vw',
      height: '70vh',
      bottom: 'auto',
    },
  },
  modalSm: {
    display: 'flex',
    justifyContent: 'center',
    alignItems: 'center',
  },
  filledButton: {
    background: 'linear-gradient(90deg, rgb(20, 55, 196), rgb(55, 112, 212))',
    borderRadius: '8px',
    color: '#FFF',
    textTransform: 'none',
    padding: '8px 12px',
    fontFamily: 'NexaRegular',
    '&:hover': {
      background: 'linear-gradient(90deg, rgb(20, 55, 196), rgb(55, 112, 212))',
      borderRadius: '8px',
    },
  },
  outlinedButton: {
    backgroundColor: 'none',
    border: '1px solid #1335c6',
    color: '#1335c6',
    textTransform: 'none',
    padding: '8px 12px',
    borderRadius: '8px',
    fontFamily: 'NexaRegular',
    minWidth: '163px',
    '@media (min-width:350px)': {
      marginTop: '12px',
    },
    '@media (min-width:780px)': {
      marginTop: '0px',
    },
  },
  outlinedButtonRed: {
    backgroundColor: 'none',
    border: '1px solid #ff0000',
    color: '#ff0000',
    textTransform: 'none',
    padding: '8px 12px',
    borderRadius: '8px',
    fontFamily: 'NexaRegular',
  },
  title: {
    fontfamily: 'NexaBold',
    fontSize: '20px',
    textAlign: 'center',
    fontWeight: 'bolder',
    margin: '0px',
    color: '#101010',
  },
  description: {
    fontfamily: 'NexaLight',
    fontSize: '15px',
    textAlign: 'center',
    width: 'fit-Content',
    color: '#707072',
  },
  swapButton: {
    border: '1px solid #1335c6',
    fontFamily: 'NexaRegular',
    color: '#1335c6',
    textTransform: 'none',
    height: 'fit-content',
    cursor: 'pointer',
    padding: '6px 12px',
  },
  buyButton: {
    background: '#1335c6',
    fontFamily: 'NexaRegular',
    color: '#FFF',
    textTransform: 'none',
    height: 'fit-content',
    cursor: 'pointer',
    marginLeft: '20px',
    padding: '6px 12px',
    '&:hover': {
      background: '#1335c6',
    },
  },
  itemContainer: {
    display: 'flex',
    justifyContent: 'space-between',
    alignItems: 'center',
    '@media (min-width:350px)': {
      flexDirection: 'column',
    },
    '@media (min-width:780px)': {
      flexDirection: 'row',
    },
  },
  newBookContainer: {
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'center',
    '@media (min-width:350px)': {
      maxWidth: '90%',
    },
    '@media (min-width:780px)': {
      maxWidth: '50%',
    },
  },
}));

/* eslint-disable import/prefer-default-export */
/* eslint-disable react/prop-types */
function ModalListBooks(props) {
  const classes = useStyles();
  const token = useSelector((state) => state.Reducer.token);

  const {
    openModalListBooks,
    setOpenModalListBooks,
    books,
    actualPosition,
    getBooksById,
  } = props;
  const [loadingReserveBook, setLoadingReserveBook] = useState();
  const [stepBook, setStepBook] = useState('list');
  const [loadingAdd, setLoadingAdd] = useState();
  const [titleNewBook, setTitleNewBook] = useState();
  const [authorsNewBook, setAuthorsNewBook] = useState();
  const [descriptionNewBook, setDescriptionNewBook] = useState();

  // Snackbar states
  const [openSnackbar, setOpenSnackbar] = useState(false);
  const [messageSnackbar, setMessageSnackbar] = useState('');
  const [severity, setSeverity] = useState('');

  const [bookToReserve, setBookToReserve] = useState();

  const handleCloseSnackbar = () => {
    setOpenSnackbar(false);
  };

  const handleReserveBook = () => {
    setLoadingReserveBook(true);

    api.post(`Localizacoes/ReservarLivro?produtoId=${bookToReserve.id}&localId=${actualPosition.id}`, {},
      {
        headers: {
          'Content-Type': 'application/json; charset=utf-8',
          Authorization: `Bearer ${token}`,
        },
      })
      .then((res) => {
        if (res.data) {
          getBooksById(actualPosition.id, actualPosition);
          setStepBook('success');
          setLoadingReserveBook(false);
        } else {
          setMessageSnackbar('Não foi possível alugar o livro!');
          setSeverity('error');
          setOpenSnackbar(true);
        }
      })
      .catch(() => {
        setMessageSnackbar('Não foi possível alugar o livro!');
        setSeverity('error');
        setOpenSnackbar(true);
      });
  };

  const submitBook = () => {
    setLoadingAdd(true);

    api.post('Localizacoes/DeixarLivro', {
      titulo: titleNewBook,
      descricao: descriptionNewBook,
      autores: authorsNewBook,
      localLivros: [{
        localId: actualPosition.id,
        disponivel: true,
      }],
    },
    {
      headers: {
        'Content-Type': 'application/json; charset=utf-8',
        Authorization: `Bearer ${token}`,
      },
    })
      .then(() => {
        setLoadingAdd(false);
        setStepBook('list');
        setTitleNewBook('');
        setAuthorsNewBook('');
        setDescriptionNewBook('');
        setMessageSnackbar('Livro adicionado com sucesso!');
        setSeverity('success');
        setOpenSnackbar(true);
        getBooksById(actualPosition.id, actualPosition);
      })
      .catch(() => {
      });
  };

  return (
    <Modal
      aria-labelledby="transition-modal-title"
      aria-describedby="transition-modal-description"
      className={classes.modalSm}
      open={openModalListBooks}
      onClose={() => setOpenModalListBooks(false)}
      closeAfterTransition
      BackdropComponent={Backdrop}
      BackdropProps={{
        timeout: 500,
      }}
    >
      <Fade in={openModalListBooks} style={{ border: 'none' }}>
        <div className={classes.paperModalAlterar}>
          <Grid spacing={3} container>
            <Grid className={classes.itemContainer} item xs={12} md={12}>
              <Typography
                style={{
                  fontSize: '20px',
                  color: '#464F5B',
                  marginBottom: '16px',
                  fontFamily: 'NexaRegular',
                }}
              >
                <b>
                  Ponto de troca:
                  {' '}
                  {actualPosition?.descricao}
                </b>
              </Typography>
              <Button
                onClick={() => {
                  if (stepBook === 'add') {
                    setStepBook('list');
                    setTitleNewBook('');
                    setAuthorsNewBook('');
                    setDescriptionNewBook('');
                  } else {
                    setStepBook('add');
                  }
                }}
                className={stepBook === 'add' ? classes.outlinedButtonRed : classes.outlinedButton}
              >
                {stepBook === 'add' ? 'Cancelar'
                  : 'Adicionar livro' }
              </Button>
            </Grid>
          </Grid>
          <Divider style={{ margin: '16px 0px 28px' }} variant="middle" />
          <Grid style={{ height: '-webkit-fill-available', overflowY: 'auto' }} xs={12} md={12}>
            {stepBook === 'add' && (
              <center style={{ marginTop: '30px' }}>
                <div
                  className={classes.newBookContainer}
                >
                  <Typography
                    style={{
                      fontSize: '18px',
                      color: '#1335c6',
                      marginBottom: '20px',
                      fontFamily: 'NexaBold',
                    }}
                  >
                    Adicionar livro ao ponto de troca
                  </Typography>
                  <TextField
                    style={{ marginBottom: '18px', width: '100%' }}
                    variant="outlined"
                    label="Título"
                    value={titleNewBook}
                    onChange={(e) => setTitleNewBook(e.target.value)}
                  />
                  <TextField
                    style={{ marginBottom: '18px', width: '100%' }}
                    variant="outlined"
                    label="Autores"
                    value={authorsNewBook}
                    onChange={(e) => setAuthorsNewBook(e.target.value)}
                  />
                  <TextField
                    style={{ marginBottom: '18px', width: '100%' }}
                    variant="outlined"
                    label="Descrição"
                    multiline
                    rows={6}
                    value={descriptionNewBook}
                    onChange={(e) => setDescriptionNewBook(e.target.value)}
                  />
                  <Button
                    style={{ width: '100%' }}
                    className={classes.filledButton}
                    onClick={submitBook}
                    disabled={!titleNewBook || !descriptionNewBook || !authorsNewBook}
                  >
                    {loadingAdd ? <CircularProgress size={20} style={{ color: '#FFF' }} />
                      : 'Adicionar'}
                  </Button>
                </div>
              </center>
            )}
            {stepBook === 'list' && (
              <div
                style={{
                  display: 'flex',
                  flexDirection: 'column',
                  height: '-webkit-fill-available',
                  padding: '0px 16px',
                }}
              >
                {books.length === 0
                  ? <NotFoundComponent dark />
                  : (
                    <>
                      {books.map((book) => (
                        <>
                          <div className={classes.itemContainer}>
                            <div style={{ display: 'flex', alignItems: 'center' }}>
                              <Avatar
                                src={blueBook}
                                variant="rounded"
                                style={{
                                  marginRight: '16px',
                                  width: '64px',
                                  height: '64px',
                                  borderRadius: '8px',
                                }}
                              />
                              <div>
                                <Typography
                                  style={{
                                    fontSize: '16px',
                                    color: '#1335c6',
                                    marginRight: '10px',
                                    fontFamily: 'NexaRegular',
                                  }}
                                >
                                  {book.titulo}
                                </Typography>
                                <Typography
                                  style={{
                                    fontSize: '14px',
                                    color: '#707072',
                                    marginRight: '10px',
                                    fontFamily: 'NexaRegular',
                                    marginTop: '4px',
                                  }}
                                >
                                  {book.autores}
                                </Typography>
                              </div>
                            </div>
                            <div>
                              <Button
                                className={classes.outlinedButton}
                                onClick={() => {
                                  setStepBook('confirmation');
                                  setBookToReserve(book);
                                }}
                              >
                                Reservar livro
                              </Button>
                            </div>
                          </div>
                          <Divider style={{ margin: '16px 0px 28px' }} variant="middle" />
                        </>
                      ))}
                    </>
                  )}
              </div>
            )}
            {stepBook === 'confirmation' && (
              <div style={{ marginTop: '64px' }}>
                <center>
                  <p className={classes.title}>
                    Tem certeza que deseja reservar este livro?
                  </p>
                  <p className={classes.description}>
                    Este livro só poderá ser retirado por você, tenha certeza antes de confirmar!
                  </p>
                  <div style={{ marginTop: '32px' }}>
                    <Button
                      className={classes.buyButton}
                      onClick={() => handleReserveBook()}
                      style={{ marginRight: '16px', width: 'fit-content' }}
                    >
                      {loadingReserveBook ? <CircularProgress disableShrink style={{ color: '#FFF' }} size={20} thickness={4} />
                        : 'Reservar'}
                    </Button>
                    <Button
                      className={classes.swapButton}
                      onClick={() => setStepBook('list')}
                    >
                      Cancelar
                    </Button>
                  </div>
                </center>
              </div>
            )}
            {stepBook === 'success' && (
              <div>
                <div style={{ flexDirection: 'column', alignItems: 'center', display: 'flex' }}>
                  <CheckCircleRoundedIcon style={{ color: 'green', fontSize: '160px' }} />
                  <p className={classes.title} style={{ marginTop: '16px' }}>
                    Livro reservado com sucesso!
                  </p>
                  <p className={classes.description}>
                    Seu livro já está disponível na pagina de livros reservados!
                  </p>
                  <div style={{ marginTop: '32px', display: 'flex', justifyContent: 'center' }}>
                    <Link to="/livros-reservados">
                      <Button
                        className={classes.buyButton}
                        style={{ marginRight: '16px', width: 'fit-content' }}
                        // onClick={() => setRenting('sucess')}
                      >
                        Visualizar seus livros
                      </Button>
                    </Link>
                    <Button
                      onClick={() => {
                        setOpenModalListBooks(false);
                        setStepBook('list');
                      }}
                      className={classes.swapButton}
                    >
                      Fechar
                    </Button>
                  </div>
                </div>
              </div>
            )}
          </Grid>
          <SnackbarComponent
            openSnackbar={openSnackbar}
            handleCloseSnackbar={handleCloseSnackbar}
            severity={severity}
            messageSnackbar={messageSnackbar}
          />
        </div>
      </Fade>
    </Modal>
  );
}

export default ModalListBooks;
