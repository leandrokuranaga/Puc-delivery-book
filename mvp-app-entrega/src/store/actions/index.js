export default function SaveTokenRedux(token) {
  return {
    type: 'SET_TOKEN',
    token,
  };
}
