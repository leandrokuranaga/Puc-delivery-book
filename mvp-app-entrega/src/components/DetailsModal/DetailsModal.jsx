import React, { useState } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Modal from '@material-ui/core/Modal';
import Backdrop from '@material-ui/core/Backdrop';
import Fade from '@material-ui/core/Fade';
import Button from '@material-ui/core/Button';
import ReactStars from 'react-stars';
import ArrowBackIosRoundedIcon from '@material-ui/icons/ArrowBackIosRounded';
import Skeleton from '@material-ui/lab/Skeleton';
import { LazyLoadImage } from 'react-lazy-load-image-component';
import CloseRoundedIcon from '@material-ui/icons/CloseRounded';
import CheckCircleRoundedIcon from '@material-ui/icons/CheckCircleRounded';
import CircularProgress from '@material-ui/core/CircularProgress';
import { TextField, withStyles } from '@material-ui/core';
import { Link } from 'react-router-dom';
import { useSelector } from 'react-redux';
import api from '../../services/api';
import { SnackbarComponent } from '..';

const CssTextField = withStyles({
  root: {
    '&.MuiTextField-root': {
      color: 'black !important',
      backgroundColor: '#FFF',
      borderRadius: '8px',
    },
  },
})(TextField);

const useStyles = makeStyles((theme) => ({
  modal: {
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'center',
  },
  paper: {
    backgroundColor: '#03103B',
    border: '2px solid #000',
    boxShadow: theme.shadows[5],
    color: 'white',
    width: '100%',
    height: '100%',
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'center',
  },
  swapButton: {
    backgroundColor: '#03103B',
    border: '1px solid rgb(75, 161, 216)',
    width: '100px',
    fontFamily: 'NexaRegular',
    color: 'rgb(75, 161, 216)',
    textTransform: 'none',
    height: 'fit-content',
    cursor: 'pointer',
  },
  buyButton: {
    background: 'linear-gradient(to right, rgb(75, 161, 216), rgb(68, 100, 189) 95%)',
    width: 'fit-content',
    fontFamily: 'NexaRegular',
    color: '#FFF',
    textTransform: 'none',
    height: 'fit-content',
    cursor: 'pointer',
    marginLeft: '20px',
    minHeight: '38.4px',
  },
  bookImgModal: {
    height: '50vh',
    backgroundColor: '#0003',
    margin: '10px',
    borderRadius: '30px',
    display: 'flex',
    justifyContent: 'center',
    alignItems: 'center',
    boxShadow: 'rgba(0, 0, 0, 0.15) 1.95px 1.95px 2.6px',
  },
  modalContent: {
    height: '43vh',
    margin: '25px',
    display: 'flex',
    flexDirection: 'column',
    justifyContent: 'space-between',
    overflowY: 'auto',
    alignItems: 'center',
  },
  backButton: {
    position: 'absolute',
    top: '5vh',
    left: '8vw',
    cursor: 'pointer',
  },
  image: {
    width: 'auto',
    height: '100%',
  },
  title: {
    fontfamily: 'NexaBold',
    fontSize: '20px',
    textAlign: 'center',
    fontWeight: 'bolder',
    margin: '0px',
  },
  author: {
    fontfamily: 'NexaLight',
    fontSize: '15px',
    textAlign: 'center',
    color: '#DCDCDC',
  },
  starsContainer: {
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'center',
  },
  stars: {
    width: 'fit-Content',
    marginTop: '-4px',
  },
  pontuation: {
    fontfamily: 'NexaLight',
    fontSize: '15px',
    textAlign: 'center',
    width: 'fit-Content',
    margin: '0px 0px 0px 10px',
  },
  description: {
    fontfamily: 'NexaLight',
    fontSize: '15px',
    textAlign: 'center',
    width: 'fit-Content',
  },
  modalContainer: {
    height: '100%',
    width: '100%',
    maxWidth: '1170px',
  },
  bookInfos: {
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'center',
    height: '30vh',
    overflowY: 'auto',
  },
}));

/* eslint-disable react/prop-types */
function DetailsModal(props) {
  const token = useSelector((state) => state.Reducer.token);
  const classes = useStyles();
  const {
    open,
    setOpen,
    bookToShow,
    loadingDetails,
  } = props;

  const [renting, setRenting] = useState('');
  const [rentingDays, setRentingDays] = useState('');
  const [loadingRenting, setLoadingRenting] = useState(false);

  // Snackbar states
  const [openSnackbar, setOpenSnackbar] = useState(false);
  const [messageSnackbar, setMessageSnackbar] = useState('');
  const [severity, setSeverity] = useState('');

  const handleCloseSnackbar = () => {
    setOpenSnackbar(false);
  };

  const sendMessage = () => {
    window.open('https://t.me/joinchat/f81NN3Lp4BJkMDc5&text=Teste', '__blank');
  };

  const handleRentBook = () => {
    setLoadingRenting(true);

    api.post(`Livros/alugarLivro?isbn=${bookToShow.isbn13}&dias=${rentingDays}`, {},
      {
        headers: {
          'Content-Type': 'application/json; charset=utf-8',
          Authorization: `Bearer ${token}`,
        },
      })
      .then((res) => {
        if (res.data) {
          setLoadingRenting(false);
          setRenting('sucess');
        } else {
          setMessageSnackbar('Não foi possível alugar este livro!');
          setSeverity('error');
          setOpenSnackbar(true);
        }
      })
      .catch(() => {
        setMessageSnackbar('Não foi possível alugar este livro!');
        setSeverity('error');
        setOpenSnackbar(true);
      });
  };

  return (
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
        {renting ? (
          <div className={classes.paper}>
            {renting === 'confirmation' && (
            <div style={{ flexDirection: 'column' }}>
              <CloseRoundedIcon
                onClick={() => setRenting('')}
                style={{
                  color: '#FFF',
                  position: 'absolute',
                  cursor: 'pointer',
                  top: '20px',
                  right: '20px',
                  fontSize: '42px',
                }}
              />
              <p className={classes.title}>
                Tem certeza que deseja alugar este livro?
              </p>
              <p className={classes.description}>
                Este livro digital ficará disponível na sua conta pelo periodo que desejar alugar!
              </p>
              <div
                style={{
                  display: 'flex',
                  justifyContent: 'center',
                  marginTop: '32px',
                  alignItems: 'center',
                }}
              >
                <p className={classes.description}>
                  Por
                </p>
                <CssTextField
                  onChange={(e) => setRentingDays(e.target.value)}
                  id="descricao"
                  value={rentingDays}
                  type="number"
                  // placeholder="Por"
                  variant="outlined"
                  color="primary"
                  style={{
                    width: '80px',
                    marginRight: '16px',
                    height: '100%',
                    marginLeft: '16px',
                  }}
                  size="small"
                />
                <p className={classes.description}>
                  dias
                </p>
              </div>
              <div style={{ marginTop: '32px', display: 'flex', justifyContent: 'center' }}>
                <Button
                  className={classes.buyButton}
                  style={{ marginRight: '16px' }}
                  onClick={() => handleRentBook()}
                  disabled={!rentingDays}
                >
                  {loadingRenting
                    ? <CircularProgress size={20} style={{ color: '#FFF' }} />
                    : 'Alugar'}
                </Button>
                <Button
                  onClick={() => setRenting('')}
                  className={classes.swapButton}
                >
                  Cancelar
                </Button>
              </div>
              <SnackbarComponent
                openSnackbar={openSnackbar}
                handleCloseSnackbar={handleCloseSnackbar}
                severity={severity}
                messageSnackbar={messageSnackbar}
              />
            </div>
            )}
            {renting === 'sucess' && (
            <div style={{ flexDirection: 'column', alignItems: 'center', display: 'flex' }}>
              <CloseRoundedIcon
                onClick={() => {
                  setRenting('');
                  setOpen(false);
                }}
                style={{
                  color: '#FFF',
                  position: 'absolute',
                  cursor: 'pointer',
                  top: '20px',
                  right: '20px',
                  fontSize: '42px',
                }}
              />
              <CheckCircleRoundedIcon style={{ color: 'green', fontSize: '160px' }} />
              <p className={classes.title} style={{ marginTop: '16px' }}>
                Livro alugado com sucesso!
              </p>
              <p className={classes.description}>
                Seu livro já está disponível na pagina de livros alugados!
              </p>
              <div style={{ marginTop: '32px', display: 'flex', justifyContent: 'center' }}>
                <Link to="/livros-alugados">
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
                    setRenting('');
                    setOpen(false);
                  }}
                  className={classes.swapButton}
                >
                  Fechar
                </Button>
              </div>
            </div>
            )}
          </div>
        )
          : (
            <div className={classes.paper}>
              <div className={classes.modalContainer}>
                <div className={classes.bookImgModal}>
                  <ArrowBackIosRoundedIcon
                    className={classes.backButton}
                    onClick={() => setOpen(false)}
                  />
                  {!loadingDetails ? (
                    <LazyLoadImage
                      alt="Imagem do livro"
                      className={classes.image}
                      effect="black-and-white"
                      visibleByDefault
                      src={bookToShow.urlImagem}
                      placeholderSrc={bookToShow.urlImagem}
                    />
                  )
                    : <CircularProgress style={{ color: '#FFF' }} />}
                </div>
                <div className={classes.modalContent}>
                  <div className={classes.bookInfos}>
                    <p className={classes.title}>
                      {!loadingDetails ? bookToShow.titulo : <Skeleton variant="rect" width={200} height={25} />}
                    </p>
                    <p className={classes.author}>
                      {!loadingDetails ? bookToShow.autores : <Skeleton variant="rect" width={200} height={25} />}
                    </p>
                    {!loadingDetails ? (
                      <div className={classes.starsContainer}>
                        <ReactStars
                          className={classes.stars}
                          count={5}
                          edit={false}
                          value={bookToShow.avaliacao}
                          size={20}
                          color2="#ffd700"
                        />
                        <p className={classes.pontuation}>
                          {!loadingDetails ? bookToShow.avaliacao : <Skeleton variant="rect" width={200} height={25} />}
                          /5.0
                        </p>
                      </div>
                    )
                      : <Skeleton variant="rect" width={200} height={25} />}
                    <p className={classes.description}>
                      {!loadingDetails ? bookToShow.descricao : <Skeleton variant="rect" width={250} height={114} />}
                    </p>
                  </div>
                  {!loadingDetails ? (
                    <center
                      style={{
                        position: 'absolute',
                        paddingBottom: '24px',
                        paddingTop: '8px',
                        bottom: '0px',
                        backgroundColor: '#03103B',
                        width: '100vw',
                      }}
                    >
                      <Button
                        onClick={() => sendMessage()}
                        className={classes.swapButton}
                      >
                        Trocar
                      </Button>
                      <Button
                        className={classes.buyButton}
                        onClick={() => setRenting('confirmation')}
                        disabled={!bookToShow.alugavel}
                      >
                        {bookToShow.alugavel
                          ? 'Alugar'
                          : 'Aluguel indisponível'}
                      </Button>
                    </center>
                  )
                    : <Skeleton variant="rect" width={200} height={25} />}
                </div>
              </div>
            </div>
          )}
      </Fade>
    </Modal>
  );
}

export default DetailsModal;
