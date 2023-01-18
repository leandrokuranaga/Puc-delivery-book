import React from 'react';
import { IconButton } from '@material-ui/core';
import ImportContactsRoundedIcon from '@material-ui/icons/ImportContactsRounded';
import MenuBookRoundedIcon from '@material-ui/icons/MenuBookRounded';
import SwapHorizRoundedIcon from '@material-ui/icons/SwapHorizRounded';
import ExitToAppRoundedIcon from '@material-ui/icons/ExitToAppRounded';
import LibraryMusicRoundedIcon from '@material-ui/icons/LibraryMusicRounded';
import EditLocationRoundedIcon from '@material-ui/icons/EditLocationRounded';
import MapRoundedIcon from '@material-ui/icons/MapRounded';
import Menu from '@material-ui/core/Menu';
import MenuItem from '@material-ui/core/MenuItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import SearchRoundedIcon from '@material-ui/icons/SearchRounded';
import MenuRoundedIcon from '@material-ui/icons/MenuRounded';
import FindInPageRoundedIcon from '@material-ui/icons/FindInPageRounded';
import BookmarkRoundedIcon from '@material-ui/icons/BookmarkRounded';
import { Link } from 'react-router-dom';
import { makeStyles, withStyles } from '@material-ui/core/styles';

/* eslint-disable react/jsx-props-no-spreading */
const StyledMenu = withStyles({
  paper: {
    border: '1px solid #d3d4d5',
  },
})((props) => (
  <Menu
    elevation={0}
    getContentAnchorEl={null}
    anchorOrigin={{
      vertical: 'top',
      horizontal: 'center',
    }}
    transformOrigin={{
      vertical: 'top',
      horizontal: 'center',
    }}
    {...props}
  />
));

const StyledMenuItem = withStyles((theme) => ({
  root: {
    '&:focus': {
      backgroundColor: '#f50057',
      '& .MuiListItemIcon-root, & .MuiListItemText-primary': {
        color: theme.palette.common.white,
      },
    },
  },
}))(MenuItem);

const useStyles = makeStyles(() => ({
  bookButton: {
    color: '#f50057',
    fontSize: '50px',
  },
  lateralButton: {
    color: '#FFF',
    margin: '20px',
    fontSize: '30px',
  },
  topDiv: {
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'space-between',
    zIndex: '100',
  },
  listIcon: {
    width: '30px',
    minWidth: '30px',
  },
  selected: {
    backgroundColor: '#f50057 !important',
    color: 'white',
  },
}));

/* eslint-disable react/prop-types */
function TopMenu({ icon }) {
  const classes = useStyles();

  const [anchorEl, setAnchorEl] = React.useState(null);

  const handleClick = (event) => {
    setAnchorEl(event.currentTarget);
  };

  const handleClose = () => {
    setAnchorEl(null);
  };

  return (
    <div className={classes.topDiv}>
      <IconButton onClick={handleClick}>
        <MenuRoundedIcon className={classes.lateralButton} />
      </IconButton>
      <StyledMenu
        id="customized-menu"
        anchorEl={anchorEl}
        keepMounted
        open={Boolean(anchorEl)}
        onClose={handleClose}
      >
        <Link to="/trocar">
          <StyledMenuItem classes={{ selected: classes.selected }} selected={icon === 'trocar'}>
            <ListItemIcon className={classes.listIcon}>
              <SwapHorizRoundedIcon style={{ color: icon === 'trocar' && '#FFF' }} fontSize="small" />
            </ListItemIcon>
            <ListItemText primary="Trocar" />
          </StyledMenuItem>
        </Link>
        <Link to="/buscar">
          <StyledMenuItem classes={{ selected: classes.selected }} selected={icon === 'buscar'}>
            <ListItemIcon className={classes.listIcon}>
              <SearchRoundedIcon style={{ color: icon === 'buscar' && '#FFF' }} fontSize="small" />
            </ListItemIcon>
            <ListItemText primary="Buscar" />
          </StyledMenuItem>
        </Link>
        <Link to="/escutar">
          <StyledMenuItem classes={{ selected: classes.selected }} selected={icon === 'podcast'}>
            <ListItemIcon className={classes.listIcon}>
              <LibraryMusicRoundedIcon style={{ color: icon === 'podcast' && '#FFF' }} fontSize="small" />
            </ListItemIcon>
            <ListItemText primary="Podcasts" />
          </StyledMenuItem>
        </Link>
        <Link to="/maps">
          <StyledMenuItem classes={{ selected: classes.selected }} selected={(icon === 'map') || (icon === 'point')}>
            <ListItemIcon className={classes.listIcon}>
              <MapRoundedIcon style={{ color: ((icon === 'map') || (icon === 'point')) && '#FFF' }} fontSize="small" />
            </ListItemIcon>
            <ListItemText primary="Pontos de troca" />
          </StyledMenuItem>
        </Link>
        <Link to="/livros-alugados">
          <StyledMenuItem classes={{ selected: classes.selected }} selected={(icon === 'livros-alugados')}>
            <ListItemIcon className={classes.listIcon}>
              <ImportContactsRoundedIcon style={{ color: (icon === 'livros-alugados') && '#FFF' }} fontSize="small" />
            </ListItemIcon>
            <ListItemText primary="Livros alugados" />
          </StyledMenuItem>
        </Link>
        <Link to="/livros-reservados">
          <StyledMenuItem classes={{ selected: classes.selected }} selected={(icon === 'livros-reservados')}>
            <ListItemIcon className={classes.listIcon}>
              <BookmarkRoundedIcon style={{ color: (icon === 'livros-reservados') && '#FFF' }} fontSize="small" />
            </ListItemIcon>
            <ListItemText primary="Livros reservados" />
          </StyledMenuItem>
        </Link>
      </StyledMenu>
      <IconButton>
        {icon === 'trocar'
        && <MenuBookRoundedIcon className={classes.bookButton} />}
        {icon === 'buscar'
        && <FindInPageRoundedIcon className={classes.bookButton} />}
        {icon === 'podcast'
        && <LibraryMusicRoundedIcon className={classes.bookButton} />}
        {icon === 'map'
        && <MapRoundedIcon className={classes.bookButton} />}
        {icon === 'point'
        && <EditLocationRoundedIcon className={classes.bookButton} />}
        {icon === 'livros-alugados'
        && <ImportContactsRoundedIcon className={classes.bookButton} />}
        {icon === 'livros-reservados'
        && <BookmarkRoundedIcon className={classes.bookButton} />}
      </IconButton>
      <Link onClick={() => localStorage.removeItem('reduxStore')} to="/">
        <IconButton>
          <ExitToAppRoundedIcon className={classes.lateralButton} />
        </IconButton>
      </Link>
    </div>
  );
}

export default TopMenu;
