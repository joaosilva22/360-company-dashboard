import axios from 'axios';

export default {
  details(idDoc) {
    return axios.get(`DocCompra/${idDoc}`);
  },
};
