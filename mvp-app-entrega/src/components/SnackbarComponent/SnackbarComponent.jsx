import React from 'react';
import { Snackbar } from '@material-ui/core';
import Alert from '@material-ui/lab/Alert';

/* eslint-disable react/prop-types */
function SnackbarComponent({
  openSnackbar,
  handleCloseSnackbar,
  severity,
  messageSnackbar,
  autoHide,
}) {
  return (
    <Snackbar
      open={openSnackbar}
      autoHideDuration={autoHide ? 4000 : null}
      onClose={handleCloseSnackbar}
    >
      <Alert onClose={handleCloseSnackbar} variant="filled" severity={severity}>
        {messageSnackbar}
      </Alert>
    </Snackbar>
  );
}

export default SnackbarComponent;
