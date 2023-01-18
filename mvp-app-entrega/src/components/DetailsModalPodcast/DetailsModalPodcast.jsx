import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Modal from '@material-ui/core/Modal';
import Backdrop from '@material-ui/core/Backdrop';
import Fade from '@material-ui/core/Fade';
import Button from '@material-ui/core/Button';
import ArrowBackIosRoundedIcon from '@material-ui/icons/ArrowBackIosRounded';
import Skeleton from '@material-ui/lab/Skeleton';
import { LazyLoadImage } from 'react-lazy-load-image-component';
import CircularProgress from '@material-ui/core/CircularProgress';

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
    background: 'linear-gradient(to right, rgb(104, 222, 100), rgb(46, 158, 43) 95%)',
    width: '150px',
    fontFamily: 'NexaRegular',
    color: '#FFF',
    textTransform: 'none',
    height: 'fit-content',
    cursor: 'pointer',
    marginLeft: '20px',
  },
  podcastImgModal: {
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
    height: '38vh',
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
  audioInfos: {
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'center',
  },
}));

/* eslint-disable react/prop-types */
function DetailsModalPodcast(props) {
  const classes = useStyles();
  const {
    open,
    setOpen,
    podcastToShow,
    loadingDetails,
  } = props;

  const sendMessage = () => {
    window.open(podcastToShow.linkExterno);
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
        <div className={classes.paper}>
          <div className={classes.modalContainer}>
            <div className={classes.podcastImgModal}>
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
                  src={podcastToShow.imagem?.link}
                  placeholderSrc={podcastToShow.imagem?.link}
                />
              )
                : <CircularProgress style={{ color: '#FFF' }} />}
            </div>
            <div className={classes.modalContent}>
              <div className={classes.audioInfos}>
                <p className={classes.title}>
                  {!loadingDetails ? podcastToShow.titulo : <Skeleton variant="rect" width={200} height={25} />}
                </p>
                <p className={classes.author}>
                  {!loadingDetails ? podcastToShow.autores : <Skeleton variant="rect" width={200} height={25} />}
                </p>
                <p className={classes.description}>
                  {!loadingDetails ? podcastToShow.descricao : <Skeleton variant="rect" width={250} height={114} />}
                </p>
              </div>
              {!loadingDetails ? (
                <center>
                  <Button
                    onClick={() => sendMessage()}
                    className={classes.buyButton}
                  >
                    Acessar Spotify
                  </Button>
                </center>
              )
                : <Skeleton variant="rect" width={200} height={25} />}
            </div>
          </div>
        </div>
      </Fade>
    </Modal>
  );
}

export default DetailsModalPodcast;
