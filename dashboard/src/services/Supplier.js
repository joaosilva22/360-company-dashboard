import axios from 'axios';

export default {
  topSuppliers(start, end) {
    return axios.get(`fornecedores/${start}/${end}`);
  },
  inventoryValue() {
    return axios.get('inventario');
  },
};
