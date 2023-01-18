import {
  Button,
  makeStyles,
  TextField,
  withStyles,
  CircularProgress,
} from '@material-ui/core';
import { useSelector } from 'react-redux';
import React, {
  useState,
  useRef,
  useMemo,
} from 'react';
import {
  MapContainer,
  TileLayer,
  Marker,
  Popup,
} from 'react-leaflet';
import { useHistory } from 'react-router-dom';
import { TopMenu } from '../../components';
import './styles.css';
import api from '../../services/api';

const CssTextField = withStyles({
  root: {
    '&.MuiTextField-root': {
      color: 'black',
      backgroundColor: '#FFF',
      borderRadius: '8px',
    },
  },
})(TextField);

function CreatePoint() {
  const useStyles = makeStyles(() => ({
    root: {
      backgroundColor: '#03103B',
      width: '100vw',
      height: '100vh',
      overflowY: 'auto',
      overflowX: 'hidden',
    },
    title: {
      color: '#FFF',
      fontSize: '24px',
      fontFamily: 'NexaBold',
      marginBottom: '20px',
      display: 'flex',
      padding: '20px',
      justifyContent: 'center',
    },
    linkItem: {
      color: '#FFF',
      fontFamily: 'NexaRegular',
      cursor: 'pointer',
    },
    searchInput: {
      width: '100%',
      maxWidth: '500px',
      borderRadius: '50px',
      backgroundColor: '#FFF',
    },
    containerInput: {
      '@media (min-width:350px)': {
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center',
        flexDirection: 'column',
      },
      '@media (min-width:780px)': {
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center',
        flexDirection: 'row',
      },
    },
    createButton: {
      '@media (min-width:350px)': {
        color: '#FFF',
        background: 'linear-gradient(to right, rgb(75, 161, 216), rgb(68, 100, 189) 95%)',
        fontFamily: 'NexaRegular',
        marginLeft: '0px',
        textTransform: 'none',
        minWidth: '215px',
        marginTop: '12px',
        width: '80%',
      },
      '@media (min-width:780px)': {
        color: '#FFF',
        background: 'linear-gradient(to right, rgb(75, 161, 216), rgb(68, 100, 189) 95%)',
        fontFamily: 'NexaRegular',
        marginLeft: '40px',
        textTransform: 'none',
        minWidth: '215px',
        marginTop: '0px',
        width: 'fit-content',
      },
    },
    inputName: {
      '@media (min-width:350px)': {
        width: '80%',
      },
      '@media (min-width:780px)': {
        width: '40%',
      },
    },
  }));

  const token = useSelector((state) => state.Reducer.token);
  const history = useHistory();
  const classes = useStyles();
  const troca = ['-13.6632305', '-69.6410913'];
  const center = ['-13.6632305', '-50.6410913'];
  const [data, setData] = useState({
    descricao: '',
    latitude: '',
    longitude: '',
  });

  const [position, setPosition] = useState(center);
  const [loadingAdd, setLoadingAdd] = useState(false);
  const markerRef = useRef(null);
  const eventHandlers = useMemo(
    () => ({
      dragend() {
        const marker = markerRef.current;
        if (marker != null) {
          setPosition([marker.getLatLng().lat, marker.getLatLng().lng]);
        }
      },
    }),
    [],
  );

  async function handleSubmit(e) {
    const newdata = { ...data };
    newdata[e.target.id] = e.target.value;
    setData(newdata);
  }

  function submit(e) {
    e.preventDefault();
    setLoadingAdd(true);

    api.post('Localizacoes/AdicionarReferencia', {
      descricao: data.descricao,
      latitude: position[0],
      longitude: position[1],
    },
    {
      headers: {
        'Content-Type': 'application/json; charset=utf-8',
        Authorization: `Bearer ${token}`,
      },
    })
      .then(() => {
        history.push('/maps');
        setLoadingAdd(false);
      })
      .catch(() => {
      });
  }

  return (
    <div className={classes.root}>
      <center>
        <TopMenu icon="point" />
        <h1 className={classes.title}>
          Cadastro do ponto de troca
        </h1>
        <div>
          <div className={classes.containerInput}>
            <CssTextField
              onChange={(e) => handleSubmit(e)}
              id="descricao"
              value={data.descricao}
              type="text"
              placeholder="Nome do ponto de troca"
              variant="outlined"
              color="primary"
              className={classes.inputName}
              size="small"
            />
            <Button
              onClick={(e) => submit(e)}
              color="primary"
              variant="contained"
              disabled={!data.descricao}
              type="submit"
              className={classes.createButton}
            >
              {loadingAdd ? <CircularProgress size={20} style={{ color: '#FFF' }} />
                : 'Cadastrar ponto de troca'}
            </Button>
            <br />
          </div>
          <br />
          <span
            className={classes.linkItem}
          >
            Selecione um endereço no mapa (Basta arrastar para o local desejado)
          </span>
        </div>
      </center>
      <br />
      <center>
        <MapContainer
          center={troca}
          zoom={4}
          style={{ borderRadius: '18px', width: '70%' }}
        >
          <TileLayer
            attribution='&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
            url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
          />
          <Marker ref={markerRef} eventHandlers={eventHandlers} draggable position={position}>
            <Popup>
              Novo Ponto
            </Popup>
          </Marker>
        </MapContainer>
        <br />
      </center>
    </div>
  );
}

export default CreatePoint;
