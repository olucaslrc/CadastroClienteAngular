using System;
using System.Linq;
using CadastroCliente.Data;
using CadastroCliente.Helpers;

namespace CadastroCliente.Methods
{
    public class EditarDadosCliente
    {
        public string EditarDados(long ID, string NomeCliente, DateTime DataNascimentoCliente, string SexoCliente, string CepCliente, 
                                    string EnderecoCliente, string NumeroCliente, string ComplementoCliente, string BairroCliente, 
                                        string EstadoCliente, string CidadeCliente)
        {
            var _context = new ClienteContext();
            var existingID = _context.Clientes.Where(x => x.ID == ID);

            if (existingID != null)
            {
                if (!String.IsNullOrEmpty(NomeCliente))
                {
                    if (!existingID.Any(x => x.Nome == NomeCliente))
                    {
                        _context.Clientes.Where(x => x.ID == ID).FirstOrDefault().Nome = NomeCliente;
                        _context.SaveChanges();
                    }
                }
                
                if (!String.IsNullOrEmpty(DataNascimentoCliente.ToString()) && DataNascimentoCliente.ToString().Length == 21)
                {
                    if (!existingID.Any(x => x.DataNascimento == DataNascimentoCliente))
                    {
                        _context.Clientes.Where(x => x.ID == ID).FirstOrDefault().DataNascimento = DataNascimentoCliente;
                        _context.SaveChanges();
                    }                    
                }

                if (!String.IsNullOrEmpty(SexoCliente))
                {
                    if (!existingID.Any(x => x.Sexo == SexoCliente))
                    {
                        _context.Clientes.Where(x => x.ID == ID).FirstOrDefault().Sexo = SexoCliente;
                        _context.SaveChanges();
                    }
                }

                if (CepCliente.Length >= 5)
                {
                    if (!existingID.Any(x => x.Cep == CepCliente))
                    {
                        _context.Clientes.Where(x => x.ID == ID).FirstOrDefault().Cep = CepCliente;
                        _context.SaveChanges();
                    }
                }

                if (!String.IsNullOrEmpty(EnderecoCliente))
                {
                    if (!existingID.Any(x => x.Endereco == EnderecoCliente))
                    {
                        _context.Clientes.Where(x => x.ID == ID).FirstOrDefault().Endereco = EnderecoCliente;
                        _context.SaveChanges();
                    }
                }

                if (!String.IsNullOrEmpty(NumeroCliente))
                {
                    if (!existingID.Any(x => x.Numero == NumeroCliente))
                    {
                        _context.Clientes.Where(x => x.ID == ID).FirstOrDefault().Numero = NumeroCliente;
                        _context.SaveChanges();
                    }   
                }

                if (!String.IsNullOrEmpty(ComplementoCliente))
                {
                    if (!existingID.Any(x => x.Complemento == ComplementoCliente))
                    {
                        _context.Clientes.Where(x => x.ID == ID).FirstOrDefault().Complemento = ComplementoCliente;
                        _context.SaveChanges();
                    }
                }

                if (!String.IsNullOrEmpty(BairroCliente))
                {
                    if (!existingID.Any(x => x.Bairro == BairroCliente))
                    {
                        _context.Clientes.Where(x => x.ID == ID).FirstOrDefault().Bairro = BairroCliente;
                        _context.SaveChanges();
                    }
                }

                if (!String.IsNullOrEmpty(EstadoCliente))
                {
                    if (!existingID.Any(x => x.Estado == EstadoCliente))
                    {
                        _context.Clientes.Where(x => x.ID == ID).FirstOrDefault().Estado = EstadoCliente;
                        _context.SaveChanges();
                    }
                }

                if (!String.IsNullOrEmpty(CidadeCliente))
                {
                    if (!existingID.Any(x => x.Cidade == CidadeCliente))
                    {
                        _context.Clientes.Where(x => x.ID == ID).FirstOrDefault().Cidade = CidadeCliente;
                        _context.SaveChanges();
                    }
                }

                return Messages.CLIENTE_DADOS_ALTERADOS_COM_SUCESSO;
            }

            return null;
        }
    }
}