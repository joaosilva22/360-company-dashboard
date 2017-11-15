import axios from 'axios';

export default {
  topSuppliers() {
    return axios.get('fornecedores');
  },
  inventoryValue() {
    return axios.get('inventario');
  },
};
