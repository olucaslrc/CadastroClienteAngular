using System;
using CadastroCliente.Data;
using CadastroCliente.Helpers;
using CadastroCliente.Models;

namespace CadastroCliente.Methods
{
    public class InserirDadosCliente
    {
        public string InserirDados(string NomeCliente, DateTime DataNascimentoCliente, string SexoCliente, string CepCliente, 
                                    string EnderecoCliente, string NumeroCliente, string ComplementoCliente, string BairroCliente, 
                                        string EstadoCliente, string CidadeCliente)
        {
            if (String.IsNullOrEmpty(NomeCliente) || DataNascimentoCliente.ToString().Length < 10)
            {
                return null;
            }
            else if (String.IsNullOrEmpty(SexoCliente) || String.IsNullOrEmpty(CepCliente) || CepCliente.Length < 8)
            {
                return null;
            }
            else if (String.IsNullOrEmpty(EnderecoCliente) || NumeroCliente == null)
            {
                return null;
            }
            else if (String.IsNullOrEmpty(ComplementoCliente) || String.IsNullOrEmpty(BairroCliente))
            {
                return null;
            }
            else if (String.IsNullOrEmpty(EstadoCliente) || String.IsNullOrEmpty(CidadeCliente))
            {
                return null;
            }
            else
            {
                using (var _context = new ClienteContext())
                {
                    _context.Clientes.Add(new Cliente {
                        Nome = NomeCliente,
                        DataNascimento = DataNascimentoCliente,
                        Sexo = SexoCliente,
                        Cep = CepCliente,
                        Endereco = EnderecoCliente,
                        Numero = NumeroCliente,
                        Complemento = ComplementoCliente,
                        Bairro = BairroCliente,
                        Estado = EstadoCliente,
                        Cidade = CidadeCliente
                    });

                    _context.SaveChanges();

                    Console.WriteLine($"Cliente {NomeCliente} adicionado na base.");

                    return Messages.CLIENTE_INSERIDO_COM_SUCESSO;
                }
            }
        }
    }
}