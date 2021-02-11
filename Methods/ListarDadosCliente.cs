using System;
using System.Linq;
using Newtonsoft.Json;
using CadastroCliente.Data;

namespace CadastroCliente.Methods
{
    public class ListarDadosCliente
    {
        private readonly ClienteContext _context = new ClienteContext();
        public string ListarDados()
        {
            var clientes = _context.Clientes.OrderBy(x => x.ID).ToList();

            var json = JsonConvert.SerializeObject(clientes, Formatting.Indented);

            if (!String.IsNullOrEmpty(json))
            {
                return json;
            }
            return null;
        }
    }
}