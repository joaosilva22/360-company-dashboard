import axios from 'axios';

export default {
  details(idDoc) {
    console.log('dentro');
    return axios.get(`DocCompra/${idDoc}`);
  },
};
