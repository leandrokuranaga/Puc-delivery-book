import React, { useState, useEffect } from 'react';
import {
  Typography,
  Divider,
  CircularProgress,
  Button,
} from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';
import Avatar from '@material-ui/core/Avatar';
import { useSelector } from 'react-redux';
import CheckRoundedIcon from '@material-ui/icons/CheckRounded';
import blueBook from '../HomePage/imgs/book.png';
import { TopMenu, NotFoundComponent, SnackbarComponent } from '../../components';
import api from '../../services/api';

const useStyles = makeStyles(() => ({
  root: {
    backgroundColor: '#03103B',
    width: '100vw',
    height: '100vh',
    overflowY: 'auto',
    overflowX: 'hidden',
  },
  outlinedButton: {
    backgroundColor: 'none',
    border: '1px solid #FFF',
    color: '#FFF',
    textTransform: 'none',
    padding: '8px 12px',
    borderRadius: '8px',
    fontFamily: 'NexaRegular',
  },
  outlinedButtonRed: {
    backgroundColor: 'none',
    border: '1px solid red',
    color: 'red',
    textTransform: 'none',
    padding: '8px 12px',
    borderRadius: '8px',
    fontFamily: 'NexaRegular',
  },
  itemContainer: {
    '@media (min-width:350px)': {
      width: '95%',
    },
    '@media (min-width:780px)': {
      width: '800px',
    },
  },
}));

function ReservedBooks() {
  const classes = useStyles();
  const token = useSelector((state) => state.Reducer.token);

  const [reservedBooks, setReservedBooks] = useState([]);
  const [loading, setLoading] = useState(false);
  const [loadingCancel, setLoadingCancel] = useState(false);

  // Snackbar states
  const [openSnackbar, setOpenSnackbar] = useState(false);
  const [messageSnackbar, setMessageSnackbar] = useState('');
  const [severity, setSeverity] = useState('');

  const handleCloseSnackbar = () => {
    setOpenSnackbar(false);
  };

  const getReservedBooks = () => {
    setLoading(true);
    api.get('Localizacoes/Reservas',
      {
        headers: {
          'Content-Type': 'application/json; charset=utf-8',
          Authorization: `Bearer ${token}`,
        },
      })
      .then((res) => {
        setLoading(false);
        setReservedBooks(res.data);
      })
      .catch(() => {
        setMessageSnackbar('Não foi possível buscar seus livros reservados');
        setSeverity('error');
        setOpenSnackbar(true);
      });
  };

  const handleCancelReserve = (id) => {
    setLoadingCancel(true);
    api.put(`Localizacoes/CancelarReserva?id=${id}`, {},
      {
        headers: {
          'Content-Type': 'application/json; charset=utf-8',
          Authorization: `Bearer ${token}`,
        },
      })
      .then(() => {
        getReservedBooks();
        setLoadingCancel(false);
        setMessageSnackbar('Reserva cancelada com sucesso!');
        setSeverity('success');
        setOpenSnackbar(true);
      })
      .catch(() => {
        setMessageSnackbar('Não foi possível cancelar sua reserva!');
        setSeverity('error');
        setOpenSnackbar(true);
      });
  };

  useEffect(() => {
    getReservedBooks();
  }, []);

  return (
    <div className={classes.root}>
      <TopMenu icon="livros-reservados" />
      <div
        style={{
          display: 'flex',
          justifyContent: 'center',
          alignItems: 'center',
          width: '100%',
          marginTop: '30px',
          flexDirection: 'column',
        }}
      >
        <center
          style={{
            textAlign: 'center',
            color: '#FFF',
            fontFamily: 'NexaBold',
            fontSize: '18px',
            marginBottom: '30px',
          }}
        >
          Livros reservados
          <div
            style={{
              display: 'flex',
              alignItems: 'center',
              padding: '0px 12px',
            }}
          >
            <CheckRoundedIcon style={{ color: '#21de21', marginTop: '-5px', marginRight: '8px' }} />
            <p style={{ color: '#21de21', textAlign: 'center' }}>Estes livros se encontram disponíveis para serem retirados!</p>
          </div>
        </center>
        {(loading && !reservedBooks.length) && (
          <div
            style={{
              marginTop: '25vh',
              display: 'flex',
              alignItems: 'center',
              justifyContent: 'center',
            }}
          >
            <CircularProgress disableShrink style={{ color: '#FFF', alignItems: 'center' }} size={60} thickness={4} />
          </div>
        )}
        {reservedBooks.map((book, i) => (
          <div className={classes.itemContainer}>
            <div style={{ display: 'flex', alignItems: 'center', justifyContent: 'space-between' }}>
              <div style={{ display: 'flex', alignItems: 'center' }}>
                <Avatar
                  src={blueBook}
                  variant="rounded"
                  style={{
                    marginRight: '32px',
                    width: '64px',
                    height: '64px',
                    borderRadius: '8px',
                  }}
                />
                <div>
                  <Typography
                    style={{
                      fontSize: '16px',
                      color: '#FFF',
                      marginRight: '16px',
                      fontFamily: 'NexaRegular',
                    }}
                  >
                    {book.titulo}
                  </Typography>
                  <Typography
                    style={{
                      fontSize: '14px',
                      color: 'rgb(163 163 171)',
                      marginRight: '10px',
                      fontFamily: 'NexaRegular',
                      marginTop: '4px',
                    }}
                  >
                    Local:
                    {book.descricaoLocal}
                  </Typography>
                </div>
              </div>
              <div style={{ display: 'flex', alignItems: 'center' }}>
                <Button
                  onClick={() => handleCancelReserve(book.id)}
                  className={classes.outlinedButtonRed}
                >
                  {loadingCancel
                    ? <CircularProgress disableShrink style={{ color: 'red', alignItems: 'center' }} size={20} thickness={4} />
                    : 'Cancelar reserva'}
                </Button>
              </div>
            </div>
            {i !== reservedBooks.length - 1
              && (
                <Divider style={{ margin: '16px 0px 28px', backgroundColor: '#707072' }} variant="middle" />
              )}
          </div>
        ))}
        {(reservedBooks.length === 0 && !loading)
        && <NotFoundComponent />}
      </div>
      <SnackbarComponent
        openSnackbar={openSnackbar}
        handleCloseSnackbar={handleCloseSnackbar}
        severity={severity}
        messageSnackbar={messageSnackbar}
      />
    </div>
  );
}

export default ReservedBooks;
