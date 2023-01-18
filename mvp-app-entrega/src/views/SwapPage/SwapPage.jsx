import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import { SwapCard, SwipeButtons } from './components';
import { TopMenu } from '../../components';

const useStyles = makeStyles(() => ({
  root: {
    backgroundColor: '#03103B',
    width: '100vw',
    height: '100vh',
    overflow: 'hidden',
  },
}));

function SwapPage() {
  const classes = useStyles();
  const swipeRef = React.useRef(null);
  const detailsRef = React.useRef(null);

  return (
    <div className={classes.root}>
      <TopMenu icon="trocar" />
      <SwapCard swipeRef={swipeRef} detailsRef={detailsRef} />
      <SwipeButtons swipeRef={swipeRef} detailsRef={detailsRef} />
    </div>
  );
}

export default SwapPage;
