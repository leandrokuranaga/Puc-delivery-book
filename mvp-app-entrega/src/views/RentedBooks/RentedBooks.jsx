import React, { useState, useEffect } from 'react';
import {
  Typography,
  Button,
  Divider,
  CircularProgress,
} from '@material-ui/core';
import { makeStyles } from '@material-ui/core/styles';
import Modal from '@material-ui/core/Modal';
import Backdrop from '@material-ui/core/Backdrop';
import Fade from '@material-ui/core/Fade';
import { useSelector } from 'react-redux';
import Avatar from '@material-ui/core/Avatar';
import CloseRoundedIcon from '@material-ui/icons/CloseRounded';
import PDFViewer from 'pdf-viewer-reactjs';
import moment from 'moment';
import blueBook from '../HomePage/imgs/book.png';
import api from '../../services/api';
import { TopMenu, NotFoundComponent } from '../../components';

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
  modal: {
    display: 'flex',
    justifyContent: 'center',
    alignItems: 'center',
  },
  paper: {
    backgroundColor: '#FFF',
    border: '2px solid #000',
    padding: '12px',
    width: '100%',
    height: '100%',
    borderRadius: '8px',
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'center',
    overflow: 'auto',
  },
  canvas: {
    height: 'calc(100vh - 130px)',
    display: 'flex',
    justifyContent: 'center',
  },
  itemContainer: {
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'space-between',
    '@media (min-width:350px)': {
      flexDirection: 'column',
    },
    '@media (min-width:780px)': {
      flexDirection: 'row',
    },
  },
  firstContainer: {
    '@media (min-width:350px)': {
      width: '90%',
    },
    '@media (min-width:780px)': {
      width: '800px',
    },
  },
}));

function RentedBooks() {
  const classes = useStyles();
  const token = useSelector((state) => state.Reducer.token);

  const [loading, setLoading] = useState(false);
  const [rentedBooks, setRentedBooks] = useState([]);
  const [open, setOpen] = useState(false);
  const [bookToRead, setBookToRead] = useState('');

  const getRentedBooks = () => {
    setLoading(true);
    api.get('Livros/alugueis',
      {
        headers: {
          'Content-Type': 'application/json; charset=utf-8',
          Authorization: `Bearer ${token}`,
        },
      })
      .then((res) => {
        setRentedBooks(res.data);
        setLoading(false);
      })
      .catch(() => {
      });
  };

  useEffect(() => {
    getRentedBooks();
  }, []);

  return (
    <div className={classes.root}>
      <TopMenu icon="livros-alugados" />
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
          Livros alugados
        </center>
        {(loading && !rentedBooks.length) && (
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
        {rentedBooks.map((book, i) => (
          <div className={classes.firstContainer}>
            <div className={classes.itemContainer}>
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
                    {moment(book.dataFim).diff(moment(), 'days') > 0
                      ? (
                        <>
                          {`${book.titulo} (Restam ${moment(book.dataFim).diff(moment(), 'days')} dias)`}
                        </>
                      )
                      : (
                        <>
                          {book.titulo}
                        </>
                      )}
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
                {moment().isAfter(moment(book.dataFim))
                  ? (
                    <Button
                      style={{ minWidth: '163px' }}
                      className={classes.outlinedButton}
                      disabled
                    >
                      Livro não está mais disponível!
                    </Button>
                  )
                  : (
                    <Button
                      style={{ minWidth: '163px', marginTop: '12px' }}
                      className={classes.outlinedButton}
                      onClick={() => {
                        setOpen(true);
                        setBookToRead(book.livroDigital);
                      }}
                    >
                      Ler agora
                    </Button>
                  )}
              </div>
            </div>
            {i !== rentedBooks.length - 1
              && (
                <Divider style={{ margin: '16px 0px 28px', backgroundColor: '#707072' }} variant="middle" />
              )}
          </div>
        ))}
        {(rentedBooks.length === 0 && !loading)
        && <NotFoundComponent />}
      </div>
      <Modal
        aria-labelledby="transition-modal-title"
        aria-describedby="transition-modal-description"
        className={classes.modal}
        open={open}
        onClose={() => setOpen(false)}
        closeAfterTransition
        BackdropComponent={Backdrop}
        BackdropProps={{
          timeout: 500,
        }}
      >
        <Fade in={open}>
          <div className={classes.paper}>
            <CloseRoundedIcon
              onClick={() => setOpen(false)}
              style={{
                position: 'absolute',
                top: '20px',
                right: '20px',
                color: '#707072',
                fontSize: '28px',
                cursor: 'pointer',
                zIndex: 100,
              }}
            />
            <PDFViewer
              document={{
                url: `https://aqueous-crag-21083.herokuapp.com/${bookToRead}`,
              }}
              scale={0.5}
              canvasCss={classes.canvas}
            />
          </div>
        </Fade>
      </Modal>
    </div>
  );
}

export default RentedBooks;
