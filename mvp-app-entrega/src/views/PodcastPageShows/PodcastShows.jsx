import React, { useState, useEffect } from 'react';
import Grid from '@material-ui/core/Grid';
import Paper from '@material-ui/core/Paper';
import Pagination from '@material-ui/lab/Pagination';
import CircularProgress from '@material-ui/core/CircularProgress';
import { LazyLoadImage } from 'react-lazy-load-image-component';
import { useSelector } from 'react-redux';
import { makeStyles } from '@material-ui/core/styles';
import { DetailsModalPodcast, SnackbarComponent, TopMenu } from '../../components';
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
  podcastCard: {
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

function PodcastShows() {
  const classes = useStyles();
  const token = useSelector((state) => state.Reducer.token);

  const [page, setPage] = useState(1);
  const [totalPages, setTotalPages] = useState(100);
  const [loading, setLoading] = useState(true);
  const [open, setOpen] = useState(false);
  const [loadingDetails, setLoadingDetails] = useState(false);
  const [podcastToShow, setPodcastToShow] = useState({});
  const [podcasts, setPodcasts] = useState([]);

  // Snackbar states
  const [openSnackbar, setOpenSnackbar] = useState(false);
  const [messageSnackbar, setMessageSnackbar] = useState('');
  const [severity, setSeverity] = useState('');

  const handleCloseSnackbar = () => {
    setOpenSnackbar(false);
  };

  const handleOpenDetails = (podcast) => {
    setOpen(true);
    setLoadingDetails(false);
    setPodcastToShow(podcast);
  };

  const getAllPodcasts = (pageQuery) => {
    setLoading(true);
    api.get(`Audios?pagina=${pageQuery}`, {
      headers: {
        'Content-Type': 'application/json; charset=utf-8',
        Authorization: `Bearer ${token}`,
      },
    })
      .then((res) => {
        setPodcasts(res.data.itens);
        setTotalPages(100);
        setLoading(false);
      }).catch(() => {
        setMessageSnackbar('Não foi possível carregar os podscasts');
        setSeverity('error');
        setOpenSnackbar(true);
      });
  };

  const handleSearch = (pageQuery) => {
    getAllPodcasts(pageQuery);
  };

  const handleChangePage = (event, value) => {
    setPage(value);
    handleSearch(value);
  };

  useEffect(() => {
    getAllPodcasts(page);
  }, []);

  return (
    <div className={classes.root}>
      <TopMenu icon="podcast" />
      {loading ? <center className={classes.loadingDiv}><CircularProgress size={80} style={{ color: '#FFF' }} /></center>
        : (
          <>
            <Grid className={classes.bookContainer} container spacing={3}>
              {podcasts.map((podcast) => (
                <Grid key={podcast.id} style={{ display: 'flex' }} item xs={6} sm={4} md={3} lg={2}>
                  <Paper
                    onClick={
                      () => handleOpenDetails(podcast)
                    }
                    className={classes.podcastCard}
                    elevation={3}
                  >
                    <LazyLoadImage
                      alt="Imagem do livro"
                      effect="black-and-white"
                      visibleByDefault
                      style={{ marginBottom: '10px' }}
                      src={podcast.imagem.link}
                    />
                    {podcast.nome}
                  </Paper>
                </Grid>
              ))}
            </Grid>
            <Pagination className={classes.paginationContainer} classes={{ ul: classes.ul }} page={page} onChange={handleChangePage} count={totalPages} color="secondary" />
          </>
        )}
      <DetailsModalPodcast
        loadingDetails={loadingDetails}
        open={open}
        setOpen={setOpen}
        podcastToShow={podcastToShow}
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

export default PodcastShows;
