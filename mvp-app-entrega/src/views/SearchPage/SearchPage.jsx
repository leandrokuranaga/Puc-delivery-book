import React, { useState, useEffect } from 'react';
import SearchBar from 'material-ui-search-bar';
import {
  Grid,
  Paper,
  CircularProgress,
} from '@material-ui/core';
import Pagination from '@material-ui/lab/Pagination';
import { LazyLoadImage } from 'react-lazy-load-image-component';
import { makeStyles } from '@material-ui/core/styles';
import { useSelector } from 'react-redux';
import {
  DetailsModal,
  SnackbarComponent,
  NotFoundComponent,
  TopMenu,
} from '../../components';
import api from '../../services/api';

const useStyles = makeStyles(() => ({
  root: {
    backgroundColor: '#03103B',
    width: '100vw',
    height: '100vh',
    overflowY: 'auto',
    overflowX: 'hidden',
  },
  searchContainer: {
    display: 'flex',
    justifyContent: 'center',
    padding: '20px 12px',
  },
  searchInput: {
    width: '100%',
    maxWidth: '500px',
    borderRadius: '50px',
  },
  loadingDiv: {
    marginTop: '30vh',
  },
  bookCard: {
    display: 'flex',
    flexDirection: 'column',
    border: '1px solid grey',
    borderRadius: '5px',
    padding: '25px',
    cursor: 'pointer',
    backfaceVisibility: 'hidden',
    transform: 'translateZ(0)',
    transition: 'transform 0.25s ease-out',
    color: '#707072',
    textAlign: 'center',
    height: '-webkit-fill-available',
    width: '-webkit-fill-available',
    fontSize: '14px',
    fontFamily: 'NexaLight',
    '&:hover': {
      transform: 'scale(1.05)',
    },
  },
  bookContainer: {
    width: '100%',
    margin: '0px',
  },
  paginationContainer: {
    padding: '20px 12px',
    display: 'flex',
    justifyContent: 'center',
  },
  ul: {
    '& .MuiPaginationItem-root': {
      color: '#fff',
    },
  },
  placeholder: {
    fontFamily: 'NexaRegular',
    marginLeft: '10px',
  },
}));

function SearchPage() {
  const classes = useStyles();
  const token = useSelector((state) => state.Reducer.token);

  const [searchText, setSearchText] = useState('');
  const [books, setBooks] = useState([]);
  const [page, setPage] = useState(1);
  const [totalPages, setTotalPages] = useState(1);
  const [loading, setLoading] = useState(true);
  const [open, setOpen] = useState(false);
  const [loadingDetails, setLoadingDetails] = useState(false);
  const [bookToShow, setBookToShow] = useState({});

  // Snackbar states
  const [openSnackbar, setOpenSnackbar] = useState(false);
  const [messageSnackbar, setMessageSnackbar] = useState('');
  const [severity, setSeverity] = useState('');

  const handleCloseSnackbar = () => {
    setOpenSnackbar(false);
  };

  const handleOpenDetails = (id) => {
    setLoadingDetails(true);
    setOpen(true);
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
        setMessageSnackbar('Não foi possível abrir detalhes do livro');
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
        setTotalPages(1);
        setLoading(false);
      }).catch(() => {
        setMessageSnackbar('Não foi possível carregar os livros');
        setSeverity('error');
        setOpenSnackbar(true);
      });
  };

  const handleSearch = (query, pageQuery) => {
    if (query === '') {
      getAllBooks();
      return;
    }
    setLoading(true);
    api.get(`Livros/filtro?parametro=${query}&pagina=${pageQuery}`, {
      headers: {
        'Content-Type': 'application/json; charset=utf-8',
        Authorization: `Bearer ${token}`,
      },
    })
      .then((res) => {
        setBooks(res.data.livros);
        setTotalPages(Math.ceil(parseFloat(res.data.total) / 10));
        setLoading(false);
      }).catch(() => {
        setMessageSnackbar('Não foi possível buscar livros');
        setSeverity('error');
        setOpenSnackbar(true);
      });
  };

  const handleChangePage = (event, value) => {
    setPage(value);
    handleSearch(searchText, value);
  };

  useEffect(() => {
    getAllBooks();
  }, []);

  return (
    <div className={classes.root}>
      <TopMenu icon="buscar" />
      <div className={classes.searchContainer}>
        <SearchBar
          placeholder="Buscar"
          className={classes.searchInput}
          classes={{ input: classes.placeholder }}
          value={searchText}
          onChange={(newValue) => setSearchText(newValue)}
          onRequestSearch={() => {
            setPage(1);
            handleSearch(searchText, 1);
          }}
          onCancelSearch={() => {
            getAllBooks();
          }}
        />
      </div>
      {loading ? <center className={classes.loadingDiv}><CircularProgress size={80} style={{ color: '#FFF' }} /></center>
        : (
          <>
            <Grid className={classes.bookContainer} container spacing={3}>
              {books.map((book) => (
                <Grid style={{ display: 'flex' }} item xs={6} sm={4} md={3} lg={2}>
                  <Paper
                    onClick={
                      () => handleOpenDetails(book.isbn13)
                    }
                    className={classes.bookCard}
                    elevation={3}
                  >
                    <LazyLoadImage
                      alt="Imagem do livro"
                      effect="black-and-white"
                      visibleByDefault
                      src={book.urlImagem}
                      placeholderSrc={book.urlImagem}
                    />
                    {book.titulo}
                  </Paper>
                </Grid>
              ))}
            </Grid>
            {books.length === 0
            && <NotFoundComponent />}
            <Pagination className={classes.paginationContainer} classes={{ ul: classes.ul }} page={page} onChange={handleChangePage} count={totalPages} color="secondary" />
          </>
        )}
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

export default SearchPage;
