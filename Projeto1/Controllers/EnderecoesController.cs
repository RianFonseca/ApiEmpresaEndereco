using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Teste
{

    [Route("api/[controller]")]
    [ApiController]
    public class EndereçoController : ControllerBase
    {
        private readonly AppDbContext context;

        public EndereçoController(AppDbContext context)
        {
            this.context = context;
        }


        [HttpPost]
        public ActionResult<Endereco> CadastrarEndereco(Endereco endereco)
        {
            if (context == null)
            {
                return BadRequest("Invalido");
            }

            var endereço = new Endereco (endereco.Empresa);
            endereço.Empresa = context.Empresa;
            context.Enderecos.Add(endereco);
            context.SaveChanges();
            
            return CreatedAtAction(nameof(CadastrarEndereco), new { id = endereco.Id }, endereco);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Endereco>> ListarEnderecos()
        {
            var enderecos = context.Enderecos.ToList();
            return Ok(enderecos);
        }

        [HttpGet("{id}")]
        public ActionResult<Endereco> ObterEnderecoPorId(int id)
        {
            var endereco = context.Enderecos.Find(id);
            var empresa = context.Empresas.Find(id);

            if (endereco == null)
            {
                return NotFound();
            }

            return Ok(endereco);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarEndereco(int id, Endereco enderecoAtualizado)
        {
            var endereco = context.Enderecos.Find(id);

            if (endereco == null)
            {
                return NotFound();
            }

            endereco.Cep = enderecoAtualizado.Cep;
            endereco.EnderecoCompleto = enderecoAtualizado.EnderecoCompleto;
            endereco.Bairro = enderecoAtualizado.Bairro;
            endereco.Numero = enderecoAtualizado.Numero;
            endereco.Cidade = enderecoAtualizado.Cidade;

            context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarEndereco(int id)
        {          
            var endereco = context.Enderecos.Find(id);
            if (endereco == null)
            {
                return NotFound();
            }

            context.Enderecos.Remove(endereco);          
            context.SaveChanges();

            return NoContent();
        }
    
    }
}