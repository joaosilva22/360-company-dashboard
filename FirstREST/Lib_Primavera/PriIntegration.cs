using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Interop.ErpBS900;
using Interop.StdPlatBS900;
using Interop.StdBE900;
using Interop.GcpBE900;
using ADODB;

namespace FirstREST.Lib_Primavera
{
    public class PriIntegration
    {
        # region Cliente

        public static List<Model.Cliente> ListaClientes()
        {


            StdBELista objList;

            List<Model.Cliente> listClientes = new List<Model.Cliente>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {

                //objList = PriEngine.Engine.Comercial.Clientes.LstClientes();

                objList = PriEngine.Engine.Consulta("SELECT Cliente, Nome FROM  CLIENTES");


                while (!objList.NoFim())
                {
                    listClientes.Add(new Model.Cliente
                    {
                        CodCliente = objList.Valor("Cliente"),
                        NomeCliente = objList.Valor("Nome"),
                    });
                    objList.Seguinte();

                }

                return listClientes;
            }
            else
                return null;
        }


        public static Lib_Primavera.Model.Cliente GetCliente(string codCliente)
        {


            GcpBECliente objCli = new GcpBECliente();


            Model.Cliente myCli = new Model.Cliente();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {

                if (PriEngine.Engine.Comercial.Clientes.Existe(codCliente) == true)
                {

                    objCli = PriEngine.Engine.Comercial.Clientes.Edita(codCliente);
                    myCli.CodCliente = objCli.get_Cliente();
                    myCli.NomeCliente = objCli.get_Nome();
                    myCli.Moeda = objCli.get_Moeda();
                    myCli.NumContribuinte = objCli.get_NumContribuinte();
                    myCli.Morada = objCli.get_Morada();
                    myCli.Email = PriEngine.Engine.Comercial.Clientes.DaValorAtributo(codCliente, "CDU_Email");


                    return myCli;
                }
                else
                {
                    return null;
                }
            }
            else
                return null;
        }

        public static Lib_Primavera.Model.RespostaErro UpdCliente(Lib_Primavera.Model.Cliente cliente)
        {
            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();


            GcpBECliente objCli = new GcpBECliente();

            try
            {

                if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
                {

                    if (PriEngine.Engine.Comercial.Clientes.Existe(cliente.CodCliente) == false)
                    {
                        erro.Erro = 1;
                        erro.Descricao = "O cliente não existe";
                        return erro;
                    }
                    else
                    {

                        objCli = PriEngine.Engine.Comercial.Clientes.Edita(cliente.CodCliente);
                        objCli.set_EmModoEdicao(true);

                        objCli.set_Nome(cliente.NomeCliente);
                        objCli.set_NumContribuinte(cliente.NumContribuinte);
                        objCli.set_Moeda(cliente.Moeda);
                        objCli.set_Morada(cliente.Morada);

                        PriEngine.Engine.Comercial.Clientes.Actualiza(objCli);

                        erro.Erro = 0;
                        erro.Descricao = "Sucesso";
                        return erro;
                    }
                }
                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir a empresa";
                    return erro;

                }

            }

            catch (Exception ex)
            {
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }

        }

        public static Lib_Primavera.Model.RespostaErro DelCliente(string codCliente)
        {

            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();
            GcpBECliente objCli = new GcpBECliente();


            try
            {

                if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
                {
                    if (PriEngine.Engine.Comercial.Clientes.Existe(codCliente) == false)
                    {
                        erro.Erro = 1;
                        erro.Descricao = "O cliente não existe";
                        return erro;
                    }
                    else
                    {

                        PriEngine.Engine.Comercial.Clientes.Remove(codCliente);
                        erro.Erro = 0;
                        erro.Descricao = "Sucesso";
                        return erro;
                    }
                }

                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir a empresa";
                    return erro;
                }
            }

            catch (Exception ex)
            {
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }

        }

        public static Lib_Primavera.Model.RespostaErro InsereClienteObj(Model.Cliente cli)
        {

            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();


            GcpBECliente myCli = new GcpBECliente();

            try
            {
                if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
                {

                    myCli.set_Cliente(cli.CodCliente);
                    myCli.set_Nome(cli.NomeCliente);
                    myCli.set_NumContribuinte(cli.NumContribuinte);
                    myCli.set_Moeda(cli.Moeda);
                    myCli.set_Morada(cli.Morada);

                    PriEngine.Engine.Comercial.Clientes.Actualiza(myCli);

                    erro.Erro = 0;
                    erro.Descricao = "Sucesso";
                    return erro;
                }
                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir empresa";
                    return erro;
                }
            }

            catch (Exception ex)
            {
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }


        }



        #endregion Cliente;   // -----------------------------  END   CLIENTE    -----------------------


        #region Artigo

        public static Lib_Primavera.Model.Artigo GetArtigo(string codArtigo)
        {
            StdBELista objList;


            Model.Artigo art = new Model.Artigo();
            List<Model.Artigo> listArts = new List<Model.Artigo>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {

                objList = PriEngine.Engine.Consulta("SELECT Artigo, Descricao, STKActual, PCMedio,Iva,   DataUltimaActualizacao, Desconto, QtReservadaGPR FROM ARTIGO");



                if (objList.Vazia())
                {
                    return null;

                }
                else
                {
                    art.CodArtigo = objList.Valor("Artigo");
                    art.DescArtigo = objList.Valor("Descricao");
                    art.STKActual = objList.Valor("STKActual");
                    art.PCMedio = objList.Valor("PCMedio");
                    art.Iva = objList.Valor("Iva");
                    art.DataUltimaAtualizacao = objList.Valor("DataUltimaActualizacao");
                    art.Desconto = objList.Valor("Desconto");
                    art.QtReservadaGPR = objList.Valor("QtReservadaGPR");


                    return art;

                }
            }
            else
            {
                return null;

            }

        }

        public static List<Model.Artigo> ListaArtigos()
        {
            StdBELista objList;


            Model.Artigo art = new Model.Artigo();
            List<Model.Artigo> listArts = new List<Model.Artigo>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {

                objList = PriEngine.Engine.Consulta("SELECT Artigo, Descricao, STKActual, PCMedio,Iva,   DataUltimaActualizacao, Desconto, QtReservadaGPR FROM ARTIGO");

                while (!objList.NoFim())
                {

                    listArts.Add(new Model.Artigo
                    {
                        CodArtigo = objList.Valor("Artigo"),
                        DescArtigo = objList.Valor("Descricao"),
                        STKActual = objList.Valor("STKActual"),
                        PCMedio = objList.Valor("PCMedio"),
                        Iva = objList.Valor("Iva"),
                        Desconto = objList.Valor("Desconto"),
                        DataUltimaAtualizacao = objList.Valor("DataUltimaActualizacao"),

                        QtReservadaGPR = objList.Valor("QtReservadaGPR"),


                    });
                    objList.Seguinte();
                    art = new Model.Artigo();



                }

                return listArts;

            }
            else
            {
                return null;

            }

        }

        public static List<Model.Artigo> ListaArtigosDate(DateTime dataDe, DateTime dataAte)
        {
            StdBELista objList;


            Model.Artigo art = new Model.Artigo();
            List<Model.Artigo> listArts = new List<Model.Artigo>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {
                Console.Write(dataDe);
                Console.Write(dataAte);

                objList = PriEngine.Engine.Consulta("SELECT Artigo, Descricao, STKActual, PCMedio,Iva, DataUltimaActualizacao, Desconto, QtReservadaGPR FROM ARTIGO WHERE DataUltimaActualizacao >='" + dataDe.ToString("yyyyMMdd") + "'AND DataUltimaActualizacao <' " + dataAte.ToString("yyyyMMdd") + "'");

                while (!objList.NoFim())
                {

                    listArts.Add(new Model.Artigo
                    {

                        CodArtigo = objList.Valor("Artigo"),
                        DescArtigo = objList.Valor("Descricao"),
                        STKActual = objList.Valor("STKActual"),
                        PCMedio = objList.Valor("PCMedio"),
                        Iva = objList.Valor("Iva"),
                        DataUltimaAtualizacao = objList.Valor("DataUltimaActualizacao"),
                        Desconto = objList.Valor("Desconto"),
                        QtReservadaGPR = objList.Valor("QtReservadaGPR"),

                    });
                    objList.Seguinte();
                    art = new Model.Artigo();


                }

                return listArts;

            }
            else
            {
                return null;

            }

        }


        #endregion Artigo


        #region DocCompra

        public static List<Model.DocCompra> ListDocCompra()
        {

            StdBELista objListCab;
            Model.DocCompra dc = new Model.DocCompra();
            List<Model.DocCompra> listdc = new List<Model.DocCompra>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {
                objListCab = PriEngine.Engine.Consulta("SELECT TipoDoc, DataDoc,TotalMerc, TotalDesc, Nome  From CabecCompras where TipoDoc='VNC'or TipoDoc='VND' or TipoDoc='VVD'or TipoDoc='VFA' or TipoDoc='VFG'or TipoDoc='VFI' or TipoDoc='VFM'or TipoDoc='VFO' or TipoDoc='VFP'or TipoDoc='VFR'");
                while (!objListCab.NoFim())
                {
                    double totalMerc, totalDesc;
                    dc = new Model.DocCompra();
                    dc.TipoDoc = objListCab.Valor("TipoDoc");
                    dc.DataDoc = objListCab.Valor("DataDoc");
                    totalMerc = objListCab.Valor("TotalMerc");
                    totalDesc = objListCab.Valor("TotalDesc");
                    dc.NomeFornecedor = objListCab.Valor("Nome");
                    dc.TotalLiquido = totalMerc - totalDesc;

                    listdc.Add(dc);
                    objListCab.Seguinte();
                }
            }
            return listdc;
        }

        public static List<Model.DocCompra> ListDocCompraData(DateTime dataDe, DateTime dataAte)
        {

            StdBELista objListCab;
            Model.DocCompra dc = new Model.DocCompra();
            List<Model.DocCompra> listdc = new List<Model.DocCompra>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {
                objListCab = PriEngine.Engine.Consulta("SELECT  Nome, DataDoc, TotalMerc,   TotalDesc, TipoDoc From CabecCompras where (TipoDoc='VNC'or TipoDoc='VND' or TipoDoc='VVD'or TipoDoc='VFA' or TipoDoc='VFG'or TipoDoc='VFI' or TipoDoc='VFM'or TipoDoc='VFO' or TipoDoc='VFP'or TipoDoc='VFR') AND DataDoc >=' " + dataDe.ToString("yyyyMMdd") + "'AND DataDoc <' " + dataAte.ToString("yyyyMMdd") + "'");

                while (!objListCab.NoFim())
                {
                    double totalMerc, totalDesc;
                    dc = new Model.DocCompra();
                    dc.TipoDoc = objListCab.Valor("TipoDoc");
                    dc.DataDoc = objListCab.Valor("DataDoc");
                    totalMerc = objListCab.Valor("TotalMerc");
                    totalDesc = objListCab.Valor("TotalDesc");
                    dc.NomeFornecedor = objListCab.Valor("Nome");
                    dc.TotalLiquido = totalMerc - totalDesc;

                    listdc.Add(dc);
                    objListCab.Seguinte();
                }
            }
            return listdc;
        }
        #endregion DocCompra


        #region DocsVenda

        public static Model.RespostaErro Encomendas_New(Model.DocVenda dv)
        {
            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();
            GcpBEDocumentoVenda myEnc = new GcpBEDocumentoVenda();

            GcpBELinhaDocumentoVenda myLin = new GcpBELinhaDocumentoVenda();

            GcpBELinhasDocumentoVenda myLinhas = new GcpBELinhasDocumentoVenda();

            PreencheRelacaoVendas rl = new PreencheRelacaoVendas();
            List<Model.LinhaDocVenda> lstlindv = new List<Model.LinhaDocVenda>();

            try
            {
                if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
                {
                    // Atribui valores ao cabecalho do doc
                    //myEnc.set_DataDoc(dv.Data);
                    myEnc.set_Entidade(dv.Entidade);
                    myEnc.set_Serie(dv.Serie);
                    myEnc.set_Tipodoc("ECL");
                    myEnc.set_TipoEntidade("C");
                    // Linhas do documento para a lista de linhas
                    lstlindv = dv.LinhasDoc;
                    //PriEngine.Engine.Comercial.Vendas.PreencheDadosRelacionados(myEnc, rl);
                    PriEngine.Engine.Comercial.Vendas.PreencheDadosRelacionados(myEnc);
                    foreach (Model.LinhaDocVenda lin in lstlindv)
                    {
                        PriEngine.Engine.Comercial.Vendas.AdicionaLinha(myEnc, lin.CodArtigo, lin.Quantidade, "", "", lin.PrecoUnitario, lin.Desconto);
                    }


                    // PriEngine.Engine.Comercial.Compras.TransformaDocumento(

                    PriEngine.Engine.IniciaTransaccao();
                    //PriEngine.Engine.Comercial.Vendas.Edita Actualiza(myEnc, "Teste");
                    PriEngine.Engine.Comercial.Vendas.Actualiza(myEnc, "Teste");
                    PriEngine.Engine.TerminaTransaccao();
                    erro.Erro = 0;
                    erro.Descricao = "Sucesso";
                    return erro;
                }
                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir empresa";
                    return erro;

                }

            }
            catch (Exception ex)
            {
                PriEngine.Engine.DesfazTransaccao();
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }
        }



        public static List<Model.DocVenda> Encomendas_List()
        {

            StdBELista objListCab;
            StdBELista objListLin;
            Model.DocVenda dv = new Model.DocVenda();
            List<Model.DocVenda> listdv = new List<Model.DocVenda>();
            Model.LinhaDocVenda lindv = new Model.LinhaDocVenda();
            List<Model.LinhaDocVenda> listlindv = new
            List<Model.LinhaDocVenda>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {
                objListCab = PriEngine.Engine.Consulta("SELECT id, Entidade, Data, NumDoc, TotalMerc, Serie From CabecDoc where TipoDoc='ECL'");
                while (!objListCab.NoFim())
                {
                    dv = new Model.DocVenda();
                    dv.id = objListCab.Valor("id");
                    dv.Entidade = objListCab.Valor("Entidade");
                    dv.NumDoc = objListCab.Valor("NumDoc");
                    dv.Data = objListCab.Valor("Data");
                    dv.TotalMerc = objListCab.Valor("TotalMerc");
                    dv.Serie = objListCab.Valor("Serie");
                    objListLin = PriEngine.Engine.Consulta("SELECT idCabecDoc, Artigo, Descricao, Quantidade, Unidade, PrecUnit, Desconto1, TotalILiquido, PrecoLiquido from LinhasDoc where IdCabecDoc='" + dv.id + "' order By NumLinha");
                    listlindv = new List<Model.LinhaDocVenda>();

                    while (!objListLin.NoFim())
                    {
                        lindv = new Model.LinhaDocVenda();
                        lindv.IdCabecDoc = objListLin.Valor("idCabecDoc");
                        lindv.CodArtigo = objListLin.Valor("Artigo");
                        lindv.DescArtigo = objListLin.Valor("Descricao");
                        lindv.Quantidade = objListLin.Valor("Quantidade");
                        lindv.Unidade = objListLin.Valor("Unidade");
                        lindv.Desconto = objListLin.Valor("Desconto1");
                        lindv.PrecoUnitario = objListLin.Valor("PrecUnit");
                        lindv.TotalILiquido = objListLin.Valor("TotalILiquido");
                        lindv.TotalLiquido = objListLin.Valor("PrecoLiquido");

                        listlindv.Add(lindv);
                        objListLin.Seguinte();
                    }

                    dv.LinhasDoc = listlindv;
                    listdv.Add(dv);
                    objListCab.Seguinte();
                }
            }
            return listdv;
        }




        public static Model.DocVenda Encomenda_Get(string numdoc)
        {


            StdBELista objListCab;
            StdBELista objListLin;
            Model.DocVenda dv = new Model.DocVenda();
            Model.LinhaDocVenda lindv = new Model.LinhaDocVenda();
            List<Model.LinhaDocVenda> listlindv = new List<Model.LinhaDocVenda>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {


                string st = "SELECT id, Entidade, Data, NumDoc, TotalMerc, Serie From CabecDoc where TipoDoc='ECL' and NumDoc='" + numdoc + "'";
                objListCab = PriEngine.Engine.Consulta(st);
                dv = new Model.DocVenda();
                dv.id = objListCab.Valor("id");
                dv.Entidade = objListCab.Valor("Entidade");
                dv.NumDoc = objListCab.Valor("NumDoc");
                dv.Data = objListCab.Valor("Data");
                dv.TotalMerc = objListCab.Valor("TotalMerc");
                dv.Serie = objListCab.Valor("Serie");
                objListLin = PriEngine.Engine.Consulta("SELECT idCabecDoc, Artigo, Descricao, Quantidade, Unidade, PrecUnit, Desconto1, TotalILiquido, PrecoLiquido from LinhasDoc where IdCabecDoc='" + dv.id + "' order By NumLinha");
                listlindv = new List<Model.LinhaDocVenda>();

                while (!objListLin.NoFim())
                {
                    lindv = new Model.LinhaDocVenda();
                    lindv.IdCabecDoc = objListLin.Valor("idCabecDoc");
                    lindv.CodArtigo = objListLin.Valor("Artigo");
                    lindv.DescArtigo = objListLin.Valor("Descricao");
                    lindv.Quantidade = objListLin.Valor("Quantidade");
                    lindv.Unidade = objListLin.Valor("Unidade");
                    lindv.Desconto = objListLin.Valor("Desconto1");
                    lindv.PrecoUnitario = objListLin.Valor("PrecUnit");
                    lindv.TotalILiquido = objListLin.Valor("TotalILiquido");
                    lindv.TotalLiquido = objListLin.Valor("PrecoLiquido");
                    listlindv.Add(lindv);
                    objListLin.Seguinte();
                }

                dv.LinhasDoc = listlindv;
                return dv;
            }
            return null;
        }

        #endregion DocsVenda


        #region Financas

        public static IEnumerable<Lib_Primavera.Model.Pagamento> getPagamentos(DateTime initialDate, DateTime finalDate)
        {
            StdBELista objList;
            List<Model.Pagamento> listPays = new List<Model.Pagamento>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {

                objList = PriEngine.Engine.Consulta(
                "SELECT CabecDoc.Id AS CabecDocId, CabecDoc.Nome AS CabecDocNome, CabecDoc.Entidade AS CabecDocEntidade, CabecDoc.Moeda AS CabecDocMoeda, CabecDoc.Data AS CabecDocData, " +
                "LinhasDoc.Id AS LinhasDocId, LinhasDoc.PrecoLiquido AS LinhasDocPrecoLiquido " +
                "FROM CabecDoc " +
                "INNER JOIN LinhasDoc ON LinhasDoc.IdCabecDoc = CabecDoc.Id " +
                "INNER JOIN Artigo ON Artigo.Artigo = LinhasDoc.Artigo " +
                "WHERE CabecDoc.Data >= '" + initialDate.ToString("yyyyMMdd") + "' AND CabecDoc.Data <= '" + finalDate.ToString("yyyyMMdd") + "' " +
                "ORDER BY CabecDoc.Data"
                    );

                while (!objList.NoFim())
                {

                    listPays.Add(new Model.Pagamento
                    {
                        Nome = objList.Valor("CabecDocNome"),
                        valor = objList.Valor("LinhasDocPrecoLiquido"),
                        Moeda = objList.Valor("CabecDocMoeda"),
                        Data = objList.Valor("CabecDocData"),
                    });
                    objList.Seguinte();


                }

                return listPays;
            }
            else return null;
        }

        #endregion Financas


        #region Fornecedor

        public static List<Model.Fornecedor> ListFornecedores()
        {
            StdBELista objListForne;
            StdBELista fornecedor;

            Model.Fornecedor dc = new Model.Fornecedor();
            List<Model.Fornecedor> listdc = new List<Model.Fornecedor>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {
                objListForne = PriEngine.Engine.Consulta("SELECT distinct Nome From CabecCompras where TipoDoc='VNC'or TipoDoc='VND' or TipoDoc='VVD'or TipoDoc='VFA' or TipoDoc='VFG'or TipoDoc='VFI' or TipoDoc='VFM'or TipoDoc='VFO' or TipoDoc='VFP'or TipoDoc='VFR'"); // 
                while (!objListForne.NoFim())
                {
                    String nome = objListForne.Valor("Nome");
                    Double totalMerc = 0;
                    Double totalDesc = 0;
                    fornecedor = PriEngine.Engine.Consulta("SELECT  TotalDesc, TotalMerc From CabecCompras where Nome ='" + nome + "'AND (TipoDoc='VNC'or TipoDoc='VND' or TipoDoc='VVD'or TipoDoc='VFA' or TipoDoc='VFG'or TipoDoc='VFI' or TipoDoc='VFM'or TipoDoc='VFO' or TipoDoc='VFP'or TipoDoc='VFR')");

                    while (!fornecedor.NoFim())
                    {
                        totalMerc += fornecedor.Valor("TotalMerc");
                        totalDesc += fornecedor.Valor("TotalDesc");

                        fornecedor.Seguinte();
                    }

                    dc = new Model.Fornecedor();
                    dc.Nome = objListForne.Valor("Nome");
                    dc.TotalLiquido = totalMerc - totalDesc;


                    listdc.Add(dc);
                    objListForne.Seguinte();
                }
            }
            return listdc;
        }

        public static Lib_Primavera.Model.Fornecedor ListFornecedor(String nome)
        {
            StdBELista objListCab;
            Model.Fornecedor dc = new Model.Fornecedor();

            Double totalMerc = 0;
            Double totalDesc = 0;

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {
                objListCab = PriEngine.Engine.Consulta("SELECT TotalMerc, TotalDesc, Nome  From CabecCompras where Nome='" + nome + "' AND (TipoDoc='VNC'or TipoDoc='VND' or TipoDoc='VVD'or TipoDoc='VFA' or TipoDoc='VFG'or TipoDoc='VFI' or TipoDoc='VFM'or TipoDoc='VFO' or TipoDoc='VFP'or TipoDoc='VFR')");
                while (!objListCab.NoFim())
                {
                    
                    totalMerc += objListCab.Valor("TotalMerc");
                    totalDesc += objListCab.Valor("TotalDesc");
                    dc.Nome = objListCab.Valor("Nome");

                    objListCab.Seguinte();
                }

                dc.TotalLiquido = totalMerc - totalDesc;

            }
            return dc;
        }

        public static List<Model.Fornecedor> ListFornecedoresData(DateTime dataDe, DateTime dataAte)
        {
            StdBELista objListCab;

            StdBELista fornecedor;
            List<Model.Fornecedor> listdc = new List<Model.Fornecedor>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {
                objListCab = PriEngine.Engine.Consulta("SELECT distinct Nome From CabecCompras where  DataDoc >='" + dataDe.ToString("yyyyMMdd") + "' AND DataDoc <'" + dataAte.ToString("yyyyMMdd") + "' AND (TipoDoc='VNC'or TipoDoc='VND' or TipoDoc='VVD'or TipoDoc='VFA' or TipoDoc='VFG' or TipoDoc='VFI' or TipoDoc='VFM'or TipoDoc='VFO' or TipoDoc='VFP' or TipoDoc='VFR' )"); // 

                while (!objListCab.NoFim())
                {
                    Model.Fornecedor dc = new Model.Fornecedor();
                    String nome = objListCab.Valor("Nome");
                    Double totalMerc = 0;
                    Double totalDesc = 0;
                    fornecedor = PriEngine.Engine.Consulta("SELECT  TotalDesc, TotalMerc From CabecCompras where Nome ='" + nome + "' AND (TipoDoc='VNC'or TipoDoc='VND' or TipoDoc='VVD'or TipoDoc='VFA' or TipoDoc='VFG'or TipoDoc='VFI' or TipoDoc='VFM'or TipoDoc='VFO' or TipoDoc='VFP'or TipoDoc='VFR') AND DataDoc >='" + dataDe + "' AND DataDoc <='" + dataAte + "'");

                    while (!fornecedor.NoFim())
                    {
                        totalMerc += fornecedor.Valor("TotalMerc");
                        totalDesc += fornecedor.Valor("TotalDesc");

                        fornecedor.Seguinte();
                    }


                    dc.Nome = nome;
                    dc.TotalLiquido = totalMerc - totalDesc;                    

                    listdc.Add(dc);
                    objListCab.Seguinte();
                }
            }
            return listdc;
        }

        #endregion Fornecedor


        #region Compras

        public static Lib_Primavera.Model.Compras TotalCompras()
        {
            StdBELista objList;


            Model.Compras art = new Model.Compras();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {

                objList = PriEngine.Engine.Consulta("SELECT  TotalDesc, TotalMerc From CabecCompras where (TipoDoc='VNC'or TipoDoc='VND' or TipoDoc='VVD'or TipoDoc='VFA' or TipoDoc='VFG'or TipoDoc='VFI' or TipoDoc='VFM'or TipoDoc='VFO' or TipoDoc='VFP'or TipoDoc='VFR')");
                Double totalMerc = 0;
                Double totalDesc = 0;


                while (!objList.NoFim())
                {
                    totalMerc += objList.Valor("TotalMerc");
                    totalDesc += objList.Valor("totalDesc");

                    objList.Seguinte();

                }

                art.TotalCompras = objList.NumLinhas();
                art.TotalValor = totalMerc - totalDesc;

                return art;

            }
            else
            {
                return null;

            }

        }

        public static Lib_Primavera.Model.Compras TotalComprasData(DateTime dataDe, DateTime dataAte)
        {
            StdBELista objList;


            Model.Compras art = new Model.Compras();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {

                objList = PriEngine.Engine.Consulta("SELECT  TotalDesc, TotalMerc From CabecCompras where (TipoDoc='VNC'or TipoDoc='VND' or TipoDoc='VVD'or TipoDoc='VFA' or TipoDoc='VFG'or TipoDoc='VFI' or TipoDoc='VFM'or TipoDoc='VFO' or TipoDoc='VFP'or TipoDoc='VFR') AND DataDoc >='" + dataDe.ToString("yyyyMMdd") + "' AND DataDoc <'" + dataAte.ToString("yyyyMMdd") + "'");
                Double totalMerc = 0;
                Double totalDesc = 0;


                while (!objList.NoFim())
                {
                    totalMerc += objList.Valor("TotalMerc");
                    totalDesc += objList.Valor("totalDesc");

                    objList.Seguinte();

                }

                art.TotalCompras = objList.NumLinhas();
                art.TotalValor = totalMerc - totalDesc;

                return art;

            }
            else
            {
                return null;

            }

        }

        #endregion Compras

      
        #region ContasAPagar

        public static List<Model.DocCompra> ListaContasAPagar(DateTime dataDe, DateTime dataAte)
        {

            StdBELista objListCab;
            Model.DocCompra dc = new Model.DocCompra();
            List<Model.DocCompra> listdc = new List<Model.DocCompra>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {
                objListCab = PriEngine.Engine.Consulta("SELECT TipoDoc, DataDoc,TotalMerc, TotalDesc, Nome  From CabecCompras where (TipoDoc='VNC'or TipoDoc='VND' or TipoDoc='VVD'or TipoDoc='VFA' or TipoDoc='VFG'or TipoDoc='VFI' or TipoDoc='VFM'or TipoDoc='VFO' or TipoDoc='VFP'or TipoDoc='VFR')  AND DataDoc >='" + dataDe.ToString("yyyyMMdd") + "' AND DataDoc <'" + dataAte.ToString("yyyyMMdd") + "' AND DataIntroducao >='" + dataAte.ToString("yyyyMMdd") + "'");
                while (!objListCab.NoFim())
                {
                    double totalMerc, totalDesc;
                    dc = new Model.DocCompra();
                    dc.TipoDoc = objListCab.Valor("TipoDoc");
                    dc.DataDoc = objListCab.Valor("DataDoc");
                    totalMerc = objListCab.Valor("TotalMerc");
                    totalDesc = objListCab.Valor("TotalDesc");
                    dc.NomeFornecedor = objListCab.Valor("Nome");
                    dc.TotalLiquido = totalMerc - totalDesc;

                    listdc.Add(dc);
                    objListCab.Seguinte();
                }
            }
            return listdc;
        }
        
        #endregion ContasAPagar


        #region Inventario

        public static Double InventarioValor()
        {
            StdBELista objList;
            Double totalValor = 0;

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {


                objList = PriEngine.Engine.Consulta("SELECT PCMedio,STKActual  FROM Artigo");
             


                while (!objList.NoFim())
                {
                    Double precoArt = objList.Valor("PCMedio");
                    Double stockActual = objList.Valor("STKActual");

                    Double valorArt = precoArt * stockActual;

                    totalValor += valorArt;

                    objList.Seguinte();

                }              

                return totalValor;

            }
            else
            {
                return 0;

            }
            
                 

        }
        #endregion Inventario
    }
}