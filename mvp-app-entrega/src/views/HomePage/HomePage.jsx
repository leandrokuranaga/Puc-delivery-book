import React, { createRef } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import smoothscroll from 'smoothscroll-polyfill';
import {
  TopMenu,
  IntroductionContainer,
  AboutContainer,
  FaqContainer,
  SwapMap,
} from './components';

smoothscroll.polyfill();

const useStyles = makeStyles(() => ({
  root: {
    backgroundColor: '#03103B',
    minHeight: '100vh',
    display: 'flex',
    justifyContent: 'center',
  },
  topMenuContainer: {
    padding: '25px 0px 26px',
    width: '100%',
    zIndex: '9999',
    display: 'flex',
    alignItems: 'center',
    flexDirection: 'column',
    maxWidth: '1170px',
  },
}));

function HomePage() {
  const classes = useStyles();

  // Scroll
  const refIntroduction = createRef();
  const handleClickIntroduction = (event) => {
    if (event) {
      event.preventDefault();
    }
    if (refIntroduction.current) {
      refIntroduction.current.scrollIntoView({
        behavior: 'smooth',
        block: 'start',
        inline: 'nearest',
      });
    }
  };

  const refAbout = createRef();
  const handleClickAbout = (event) => {
    if (event) {
      event.preventDefault();
    }
    if (refAbout.current) {
      refAbout.current.scrollIntoView({
        behavior: 'smooth',
        block: 'start',
        inline: 'nearest',
      });
    }
  };

  const refFaq = createRef();
  const handleClickFaq = (event) => {
    if (event) {
      event.preventDefault();
    }
    if (refFaq.current) {
      refFaq.current.scrollIntoView({
        behavior: 'smooth',
        block: 'start',
        inline: 'nearest',
      });
    }
  };

  return (
    <div className={classes.root}>
      <div className={classes.topMenuContainer}>
        <TopMenu
          clickIntroduction={handleClickIntroduction}
          clickAbout={handleClickAbout}
          clickFaq={handleClickFaq}
        />
        <div style={{ padding: '50px' }}>
          <div ref={(el) => { refIntroduction.current = el; }}>
            <IntroductionContainer />
          </div>
          <SwapMap />
          <div ref={(el) => { refAbout.current = el; }}>
            <AboutContainer />
          </div>
          <div ref={(el) => { refFaq.current = el; }}>
            <FaqContainer />
          </div>
        </div>
      </div>
    </div>
  );
}

export default HomePage;
