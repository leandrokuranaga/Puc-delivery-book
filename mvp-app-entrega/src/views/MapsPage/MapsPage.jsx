import React, { useEffect, useState } from 'react';
import {
  MapContainer,
  TileLayer,
  Marker,
  Tooltip,
} from 'react-leaflet';
import L from 'leaflet';
import { makeStyles, Typography } from '@material-ui/core';
import { useSelector } from 'react-redux';
import AddIcon from '@material-ui/icons/Add';
import { Link } from 'react-router-dom';
import { TopMenu } from '../../components';
import api from '../../services/api';
import blueBook from '../HomePage/imgs/book.png';
import { ModalListBooks } from './components';

const Newicon = new L.Icon({
  iconUrl: blueBook,
  iconSize: [40, 40],
});

function MapsPage() {
  const useStyles = makeStyles(() => ({
    root: {
      backgroundColor: '#03103B',
      width: '100vw',
      height: '100vh',
      overflowY: 'auto',
      overflowX: 'hidden',
    },
    loadingDiv: {
      marginTop: '30vh',
    },
    bookContainer: {
      width: '100%',
      margin: '0px',
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
    title: {
      color: '#FFF',
      fontSize: '38px',
      fontFamily: 'NexaRegular',
      marginBottom: '20px',
      display: 'flex',
      padding: '20px',
    },
  }));

  const token = useSelector((state) => state.Reducer.token);
  const classes = useStyles();
  const troca = [-13.6632305, -69.6410913];
  const [posicoes, setPosicoes] = useState([]);
  const [books, setBooks] = useState([]);
  const [openModalListBooks, setOpenModalListBooks] = useState(false);
  const [actualPosition, setActualPosition] = useState();

  async function getAllPoints() {
    api.get('Localizacoes/', {
      headers: {
        'Content-Type': 'application/json; charset=utf-8',
        Authorization: `Bearer ${token}`,
      },
    })
      .then((res) => {
        setPosicoes(res.data);
      })
      .catch(() => {
      });
  }

  const getBooksById = (id, position) => {
    setActualPosition(position);
    api.get(`Localizacoes/${id}`, {
      headers: {
        'Content-Type': 'application/json; charset=utf-8',
        Authorization: `Bearer ${token}`,
      },
    })
      .then((res) => {
        setBooks(res.data);
        setOpenModalListBooks(true);
      })
      .catch(() => {
      });
  };

  useEffect(() => {
    getAllPoints();
  }, []);

  return (
    <div className={classes.root}>
      <TopMenu icon="map" />
      <Typography
        style={{
          textAlign: 'center',
          color: '#FFF',
          fontFamily: 'NexaBold',
          fontSize: '18px',
        }}
      >
        Pontos de troca
      </Typography>
      <div
        style={{
          display: 'flex',
          height: '100%',
          marginTop: '18px',
          flexDirection: 'column',
          alignItems: 'center',
        }}
      >
        <MapContainer
          style={{
            height: '80%',
            width: '90%',
            borderRadius: '18px',
          }}
          center={troca}
          zoom={4}
        >
          <TileLayer
            attribution='&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
            url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
          />
          {posicoes.map((pos) => (
            <Marker
              position={[pos.latitude, pos.longitude]}
              key={pos.id}
              eventHandlers={{
                click: () => {
                  getBooksById(pos.id, pos);
                },
              }}
              icon={Newicon}
            >
              <Tooltip>{pos.descricao}</Tooltip>
            </Marker>
          ))}
          <Link to="/criarPonto">
            <AddIcon
              style={{
                zIndex: 1000,
                position: 'absolute',
                bottom: '30px',
                right: '20px',
                fontSize: '50px',
                color: '#FFF',
                borderRadius: '50%',
                cursor: 'pointer',
                backgroundColor: '#f50057',
              }}
            />
          </Link>
        </MapContainer>
      </div>
      <ModalListBooks
        openModalListBooks={openModalListBooks}
        setOpenModalListBooks={setOpenModalListBooks}
        books={books}
        actualPosition={actualPosition}
        getBooksById={getBooksById}
      />
    </div>
  );
}

export default MapsPage;
