using CadastroCliente.Helpers;
using CadastroCliente.Methods;
using CadastroCliente.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CadastroCliente.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public class CadastroClienteController : ControllerBase
    {
        private readonly ILogger<CadastroClienteController> _logger;
        public CadastroClienteController(ILogger<CadastroClienteController> logger)
        {
            _logger = logger;
        }



        [HttpGet("ListarClientes")]
        public IActionResult ListarClientes()
        {
            var getClientes = new ListarDadosCliente();

            var result = getClientes.ListarDados();

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound(Messages.CLIENTES_NAO_ENCONTRADOS);
        }

        [HttpPost("AdicionarCliente")]
        public IActionResult AdicionarCliente([FromBody] Cliente model)
        {
            var postClientes = new InserirDadosCliente();

            var result = postClientes.InserirDados(model.Nome, model.DataNascimento, model.Sexo, model.Cep, 
                                                        model.Endereco, model.Numero, model.Complemento, model.Bairro, 
                                                            model.Estado, model.Cidade);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(Messages.CLIENTE_FALTANDO_DADOS);
        }

        [HttpPut("EditarCliente")]
        public IActionResult EditarCliente([FromBody] Cliente model)
        {
            var putCliente = new EditarDadosCliente();

            var result = putCliente.EditarDados(model.ID, model.Nome, model.DataNascimento, model.Sexo, model.Cep, 
                                                    model.Endereco, model.Numero, model.Complemento, model.Bairro, 
                                                        model.Estado, model.Cidade);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(Messages.CLIENTE_ERRO_AO_EDITAR_DADOS);
        }

        [HttpDelete("RemoverCliente")]
        public IActionResult RemoverCliente([FromBody] Cliente model)
        {
            var deleteCliente = new RemoverDadosCliente();

            var result = deleteCliente.RemoverDados(model.ID);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(Messages.CLIENTE_ERRO_AO_REMOVER);
        }
    }
}