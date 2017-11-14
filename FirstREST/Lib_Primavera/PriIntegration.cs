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

                objList = PriEngine.Engine.Consulta("SELECT Artigo, Descricao, STKActual, PCMedio,Iva, DataUltimaActualizacao, Desconto, QtReservadaGPR FROM ARTIGO WHERE DataUltimaActualizacao >='" + dataDe + "'AND DataUltimaActualizacao <=' " + dataAte + "'");

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

        public static List<Model.DocCompra> List()
        {

            StdBELista objListCab;
            Model.DocCompra dc = new Model.DocCompra();
            List<Model.DocCompra> listdc = new List<Model.DocCompra>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {
                objListCab = PriEngine.Engine.Consulta("SELECT id,TipoDoc, DataDoc,TotalMerc, TotalIva, TotalDesc,  TotalOutros, TotalDocumento,  Nome  From CabecCompras");
                while (!objListCab.NoFim())
                {
                    dc = new Model.DocCompra();
                    dc.id = objListCab.Valor("id");
                    dc.TipoDoc = objListCab.Valor("TipoDoc");
                    dc.DataDoc = objListCab.Valor("DataDoc");
                    dc.TotalMerc = objListCab.Valor("TotalMerc");
                    dc.TotalIva = objListCab.Valor("TotalIva");
                    dc.TotalDesc = objListCab.Valor("TotalDesc");
                    dc.TotalOutros = objListCab.Valor("TotalOutros");
                    dc.TotalDocumento = objListCab.Valor("TotalDocumento");
                    dc.NomeFornecedor = objListCab.Valor("Nome");

                    listdc.Add(dc);
                    objListCab.Seguinte();
                }
            }
            return listdc;
        }

        public static List<Model.DocCompra> ListTipoDoc(string nomeFornecedor)
        {

            StdBELista objListCab;
            Model.DocCompra dc = new Model.DocCompra();
            List<Model.DocCompra> listdc = new List<Model.DocCompra>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {
                objListCab = PriEngine.Engine.Consulta("SELECT id,TipoDoc, DataDoc,TotalMerc, TotalIva, TotalDesc,  TotalOutros, TotalDocumento,  Nome  From CabecCompras where Nome=' " + nomeFornecedor + "'");
                while (!objListCab.NoFim())
                {
                    dc = new Model.DocCompra();
                    dc.id = objListCab.Valor("id");
                    dc.TipoDoc = objListCab.Valor("TipoDoc");
                    dc.DataDoc = objListCab.Valor("DataDoc");
                    dc.TotalMerc = objListCab.Valor("TotalMerc");
                    dc.TotalIva = objListCab.Valor("TotalIva");
                    dc.TotalDesc = objListCab.Valor("TotalDesc");
                    dc.TotalOutros = objListCab.Valor("TotalOutros");
                    dc.TotalDocumento = objListCab.Valor("TotalDocumento");
                    dc.NomeFornecedor = objListCab.Valor("Nome");

                    listdc.Add(dc);
                    objListCab.Seguinte();
                }
            }
            return listdc;
        }

        public static List<Model.DocCompra> ListTipoDocData(string nomeFornecedor, DateTime dataDe, DateTime dataAte)
        {

            StdBELista objListCab;
            Model.DocCompra dc = new Model.DocCompra();
            List<Model.DocCompra> listdc = new List<Model.DocCompra>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {
                objListCab = PriEngine.Engine.Consulta("SELECT id, NumDocExterno, Entidade, DataDoc,TotalMerc, TotalIva,  Nome, TipoDoc, TotalOutros, TotalDocumento From CabecCompraswhere Nome=' " + nomeFornecedor + "' AND DataDoc >=' " + dataDe + "'AND DataDoc <=' " + dataAte + "'");

                while (!objListCab.NoFim())
                {
                    dc = new Model.DocCompra();
                    dc.id = objListCab.Valor("id");
                    dc.TipoDoc = objListCab.Valor("TipoDoc");
                    dc.DataDoc = objListCab.Valor("DataDoc");
                    dc.TotalMerc = objListCab.Valor("TotalMerc");
                    dc.TotalIva = objListCab.Valor("TotalIva");
                    dc.TotalDesc = objListCab.Valor("TotalDesc");
                    dc.TotalOutros = objListCab.Valor("TotalOutros");
                    dc.TotalDocumento = objListCab.Valor("TotalDocumento");
                    dc.NomeFornecedor = objListCab.Valor("Nome");

                    listdc.Add(dc);
                    objListCab.Seguinte();
                    /*

                    objListLin = PriEngine.Engine.Consulta("SELECT Artigo, Descricao, Quantidade, Unidade,TotalDC,TotalDA, PrecUnit,TotalILiquido, PrecoLiquido, Armazem, TaxaIva, TotalIva, PercIncidenciaIva from LinhasCompras where IdCabecCompras='" + dc.id + "' order By NumLinha");
                    listlindc = new List<Model.LinhaDocCompra>();

                    while (!objListLin.NoFim())
                    {
                        lindc = new Model.LinhaDocCompra();
                        lindc.CodArtigo = objListLin.Valor("Artigo");
                        lindc.DescArtigo = objListLin.Valor("Descricao");
                        lindc.Quantidade = objListLin.Valor("Quantidade");
                        lindc.Unidade = objListLin.Valor("Unidade");
                        lindc.TDescontoComercial = objListLin.Valor("TotalDC");
                        lindc.TDescontoArtigo = objListLin.Valor("TotalDA");
                        lindc.PrecoUnitario = objListLin.Valor("PrecUnit");
                        lindc.TotalILiquido = objListLin.Valor("TotalILiquido");
                        lindc.TotalLiquido = objListLin.Valor("PrecoLiquido");
                        lindc.Armazem = objListLin.Valor("Armazem");
                        lindc.Iva = objListLin.Valor("TaxaIva");
                        lindc.TotalIva = objListLin.Valor("TotalIva");
                        lindc.PercIncidenciaIva = objListLin.Valor("PercIncidenciaIva");

                        listlindc.Add(lindc);
                        objListLin.Seguinte();
                    }

                    dc.LinhasDoc = listlindc;

                    listdc.Add(dc);
                    objListCab.Seguinte();*/
                }
            }
            return listdc;
        }

        public static Model.RespostaErro VGR_New(Model.DocCompra dc)
        {
            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();


            GcpBEDocumentoCompra myGR = new GcpBEDocumentoCompra();
            GcpBELinhaDocumentoCompra myLin = new GcpBELinhaDocumentoCompra();
            GcpBELinhasDocumentoCompra myLinhas = new GcpBELinhasDocumentoCompra();

            PreencheRelacaoCompras rl = new PreencheRelacaoCompras();
            List<Model.LinhaDocCompra> lstlindv = new List<Model.LinhaDocCompra>();

            try
            {
                if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
                {
                    // Atribui valores ao cabecalho do doc
                    //myEnc.set_DataDoc(dv.Data);
                    //myGR.set_Entidade(dc.Entidade);
                    //myGR.set_NumDocExterno(dc.NumDocExterno);
                    myGR.set_Tipodoc("VGR");
                    myGR.set_TipoEntidade("F");
                    // Linhas do documento para a lista de linhas
                    //lstlindv = dc.LinhasDoc;
                    //PriEngine.Engine.Comercial.Compras.PreencheDadosRelacionados(myGR,rl);
                    PriEngine.Engine.Comercial.Compras.PreencheDadosRelacionados(myGR);
                    foreach (Model.LinhaDocCompra lin in lstlindv)
                    {
                        PriEngine.Engine.Comercial.Compras.AdicionaLinha(myGR, lin.CodArtigo, lin.Quantidade, lin.Armazem, "", lin.PrecoUnitario, lin.TDescontoArtigo);
                    }


                    PriEngine.Engine.IniciaTransaccao();
                    PriEngine.Engine.Comercial.Compras.Actualiza(myGR, "Teste");
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
            StdBELista objListCab;
            Model.Fornecedor dc = new Model.Fornecedor();
            List<Model.Fornecedor> listdc = new List<Model.Fornecedor>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {
                objListCab = PriEngine.Engine.Consulta("SELECT DISTINCT Nome From CabecCompras");

                while (!objListCab.NoFim())
                {
                    dc = new Model.Fornecedor();
                    dc.NomeFornecedor = objListCab.Valor("Nome");


                    listdc.Add(dc);
                    objListCab.Seguinte();
                }
            }
            return listdc;
        }

        public static List<Model.DocCompra> ListFornecedor(String nomeFornecedor)
        {
            StdBELista objListCab;
            Model.DocCompra dc = new Model.DocCompra();
            List<Model.DocCompra> listdc = new List<Model.DocCompra>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {
                objListCab = PriEngine.Engine.Consulta("SELECT id, TipoDoc, DataDoc, TotalMerc, TotalIva, TotalDesc,  TotalOutros, TotalDocumento,  Nome  From CabecCompras where Nome='" + nomeFornecedor + "'");
                while (!objListCab.NoFim())
                {
                    dc = new Model.DocCompra();
                    dc.id = objListCab.Valor("id");
                    dc.TipoDoc = objListCab.Valor("TipoDoc");
                    dc.DataDoc = objListCab.Valor("DataDoc");
                    dc.TotalMerc = objListCab.Valor("TotalMerc");
                    dc.TotalIva = objListCab.Valor("TotalIva");
                    dc.TotalDesc = objListCab.Valor("TotalDesc");
                    dc.TotalOutros = objListCab.Valor("TotalOutros");
                    dc.TotalDocumento = objListCab.Valor("TotalDocumento");
                    dc.NomeFornecedor = objListCab.Valor("Nome");

                    listdc.Add(dc);
                    objListCab.Seguinte();
                }
            }
            return listdc;
        }

        public static List<Model.Fornecedor> ListFornecedoresTipoDocData(String tipoDoc, DateTime dataDe, DateTime dataAte)
        {
            StdBELista objListCab;
            StdBELista objListForne;
            Model.Fornecedor dc = new Model.Fornecedor();
            List<Model.Fornecedor> listdc = new List<Model.Fornecedor>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {
                objListCab = PriEngine.Engine.Consulta("SELECT distinct Nome From CabecCompras where TipoDoc='" + tipoDoc + "' AND DataDoc >='" + dataDe + "'AND DataDoc <='" + dataAte + "'"); // 
                while (!objListCab.NoFim())
                {
                    String fornecedor = objListCab.Valor("Nome");
                    Double mercadoria = 0;
                    objListForne = PriEngine.Engine.Consulta("SELECT  TotalMerc From CabecCompras where Nome ='" + fornecedor + "'AND TipoDoc='" + tipoDoc + "' AND DataDoc >='" + dataDe + "'AND DataDoc <='" + dataAte + "'");// 

                    while (!objListForne.NoFim())
                    {
                        mercadoria += objListForne.Valor("TotalMerc");

                        objListForne.Seguinte();
                    }

                    dc = new Model.Fornecedor();
                    dc.NomeFornecedor = objListCab.Valor("Nome");
                    dc.TipoDoc = tipoDoc;
                    dc.TotalMerc = mercadoria;

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

                objList = PriEngine.Engine.Consulta("SELECT TotalMerc FROM CabecCompras");
                Double totalValor = 0;


                while (!objList.NoFim())
                {
                    totalValor += objList.Valor("TotalMerc");
                    objList.Seguinte();

                }

                art.TotalCompras = objList.NumLinhas();
                art.TotalValor = totalValor;

                return art;

            }
            else
            {
                return null;

            }

        }


        public static Lib_Primavera.Model.Compras TotalComprasTipoDoc(String tipoDoc)
        {
            StdBELista objList;


            Model.Compras art = new Model.Compras();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {

                objList = PriEngine.Engine.Consulta("SELECT TotalMerc FROM CabecCompras where TipoDoc='" + tipoDoc + "'");
                Double totalValor = 0;


                while (!objList.NoFim())
                {
                    totalValor += objList.Valor("TotalMerc");
                    objList.Seguinte();

                }

                art.TotalCompras = objList.NumLinhas();
                art.TotalValor = totalValor;
                art.TipoCompras = tipoDoc;

                return art;

            }
            else
            {
                return null;

            }

        }

        #endregion Compras

        #region Inventario

        public static Double InventarioValor()
        {
            StdBELista objList;
            Double totalValor = 0;

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {

                objList = PriEngine.Engine.Consulta("SELECT PCMedio, Iva, Desconto  FROM Artigo");
             


                while (!objList.NoFim())
                {
                    Double valorArt = objList.Valor("PCMedio");

                    Double desconto = (100 - objList.Valor("Desconto"))/100;
                    valorArt *= desconto;

                    Double Iva = (100 + Double.Parse(objList.Valor("Iva")))/100;

                    valorArt *= Iva;

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