using System;
using System.Linq;
using CadastroCliente.Data;
using CadastroCliente.Helpers;

namespace CadastroCliente.Methods
{
    public class RemoverDadosCliente
    {
        public string RemoverDados(long ID)
        {
            using (var _context = new ClienteContext())
            {
                var existingID = _context.Clientes.Where(x => x.ID == ID);

                if (existingID != null)
                {
                    _context.Clientes.Remove(existingID.FirstOrDefault());
                    _context.SaveChanges();

                    Console.WriteLine($"Usuário {ID} foi removido.");

                    return Messages.CLIENTE_REMOVIDO_COM_SUCESSO;
                }
            }
            return null;
        }
    }
}