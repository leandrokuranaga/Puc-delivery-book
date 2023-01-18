import React, { useState, useEffect, useRef } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import TinderCard from 'react-tinder-card';
import CircularProgress from '@material-ui/core/CircularProgress';
import { useSelector } from 'react-redux';
import { DetailsModal, SnackbarComponent, NotFoundComponent } from '../../../../components';
import api from '../../../../services/api';

const useStyles = makeStyles(() => ({
  root: {
  },
  cardsContainer: {
    display: 'flex',
    justifyContent: 'center',
    marginTop: '10vh',
  },
  swipe: {
    position: 'absolute',
  },
  card: {
    position: 'relative',
    backgroundColor: '#03103B',
    width: '400px',
    padding: '20px',
    maxWidth: '85vw',
    height: '50vh',
    boxShadow: '0px 12px 40px 0px rgba(0, 0, 0, 0.3)',
    borderRadius: '20px',
    backgroundSize: 'cover',
    backgroundPosition: 'center',
  },
  cardContent: {
    width: '100%',
    height: '100%',
  },
  cardName: {
    position: 'absolute',
    bottom: '0',
    margin: '10px',
    color: '#FFF',
    fontFamily: 'NexaBold',
  },
  loadingDiv: {
    marginTop: '20vh',
  },
}));

/* eslint-disable react/prop-types */
/* eslint no-param-reassign: "error" */
function SwapCard(props) {
  const classes = useStyles();
  const token = useSelector((state) => state.Reducer.token);

  const { swipeRef, detailsRef } = props;
  const [books, setBooks] = useState([]);
  const [alreadyRemoved] = useState([]);
  const [swipedRight] = useState([]);
  const [swipedLeft] = useState([]);
  const [open, setOpen] = useState(false);
  const [bookToShow, setBookToShow] = useState({});
  const [loading, setLoading] = useState(true);
  const [loadingDetails, setLoadingDetails] = useState(false);

  // Snackbar states
  const [openSnackbar, setOpenSnackbar] = useState(false);
  const [messageSnackbar, setMessageSnackbar] = useState('');
  const [severity, setSeverity] = useState('');

  const handleCloseSnackbar = () => {
    setOpenSnackbar(false);
  };

  const childRefs = useRef([]);
  const descRef = useRef([]);

  const getBookById = (id) => {
    setLoadingDetails(true);
    api.get(`Livros/${id}`, {
      headers: {
        'Content-Type': 'application/json; charset=utf-8',
        Authorization: `Bearer ${token}`,
      },
    })
      .then((res) => {
        setBookToShow(res.data);
        setLoadingDetails(false);
      }).catch(() => {
        setMessageSnackbar('Não foi possível carregar detalhes do livro');
        setSeverity('error');
        setOpenSnackbar(true);
      });
  };

  const getAllBooks = () => {
    setLoading(true);
    api.get('Livros', {
      headers: {
        'Content-Type': 'application/json; charset=utf-8',
        Authorization: `Bearer ${token}`,
      },
    })
      .then((res) => {
        setBooks(res.data.livros);
        setLoading(false);
      }).catch(() => {
        setMessageSnackbar('Não foi possível carregar os livros');
        setSeverity('error');
        setOpenSnackbar(true);
      });
  };

  const showActualBookDetails = React.useCallback((id) => {
    if (id) {
      setOpen(true);
      getBookById(id);
    } else {
      setOpen(false);
      if (alreadyRemoved.length >= 0) {
        if (descRef.current[19 - alreadyRemoved.length]) {
          setOpen(true);
          getBookById(descRef.current[19 - alreadyRemoved.length].id);
        }
      }
    }
  }, []);

  const swiped = (direction, id) => {
    if (direction === ('up' || 'down')) {
      showActualBookDetails(id);
    }
    if (direction === 'left') {
      swipedLeft.push(id);
      alreadyRemoved.push(id);
    }
    if (direction === 'right') {
      swipedRight.push(id);
      alreadyRemoved.push(id);
    }
  };

  const swipe = React.useCallback((dir) => {
    if (19 - alreadyRemoved.length >= 0) {
      childRefs.current[19 - alreadyRemoved.length].swipe(dir);
    }
  }, []);

  useEffect(() => {
    swipeRef.current = swipe;
    detailsRef.current = showActualBookDetails;

    getAllBooks();
  }, []);

  return (
    <div className={classes.root}>
      <div className={classes.cardsContainer}>
        {loading
          ? <center className={classes.loadingDiv}><CircularProgress size={80} style={{ color: '#FFF' }} /></center>
          : (
            <>
              {books.filter((book) => !alreadyRemoved.includes(book.isbn13)).map((book) => (
                <TinderCard
                  ref={(ref) => { childRefs.current = [...childRefs.current, ref]; }}
                  key={book.isbn13}
                  className={classes.swipe}
                  preventSwipe={['up', 'down']}
                  onSwipe={(dir) => swiped(dir, book.isbn13)}
                >
                  <div ref={(ref) => { descRef.current = [...descRef.current, ref]; }} id={book.isbn13} style={{ backgroundImage: `url(${book.urlImagem})` }} className={classes.card}>
                    <h1 className={classes.cardName}>{book.titulo}</h1>
                  </div>
                </TinderCard>
              ))}
              <NotFoundComponent />
            </>
          )}
      </div>
      <DetailsModal
        loadingDetails={loadingDetails}
        open={open}
        setOpen={setOpen}
        bookToShow={bookToShow}
      />
      <SnackbarComponent
        openSnackbar={openSnackbar}
        handleCloseSnackbar={handleCloseSnackbar}
        severity={severity}
        messageSnackbar={messageSnackbar}
      />
    </div>
  );
}

export default SwapCard;
