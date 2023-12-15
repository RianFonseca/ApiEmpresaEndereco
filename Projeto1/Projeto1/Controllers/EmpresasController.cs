
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Teste
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly AppDbContext _dbcontext;

        public EmpresaController(AppDbContext _context)
        {
            _dbcontext = _context;
        }

        [HttpPost]
        public ActionResult CadastrarEmpresa([FromBody] Empresa context)
        {
            if (context == null)
            {
                return BadRequest("Dado Invalido");
            }

            var empresa = new Empresa(context.Id, context.NomeSocial);
            empresa.CNPJ = context.CNPJ;
            empresa.NomeFantasia = context.NomeFantasia;
            _dbcontext.Empresas.Add(empresa);
            _dbcontext.SaveChanges();
            return CreatedAtAction(actionName: nameof(CadastrarEmpresa), new { id = empresa.Id }, empresa);
        }
        [HttpGet]
        public ActionResult<IEnumerable<Empresa>> ListarEmpresas()
        {
            var empresas = _dbcontext.Empresas.ToList();
            return Ok(empresas);
        }

        [HttpGet("{id}")]
        public ActionResult<Empresa> ObterempresaPorId(int id)
        {
            var empresa = _dbcontext.Empresas.Find(id);

            if (empresa == null)
            {
                return NotFound();
            }

            return Ok(empresa);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarEmpresa(int id, Empresa empresaAtualizada)
        {
            var empresa = _dbcontext.Empresas.Find(id);

            if (empresa == null)
            {
                return NotFound();
            }

            empresa.Id = empresaAtualizada.Id;
            empresa.NomeSocial = empresaAtualizada.NomeSocial;
            empresa.NomeFantasia = empresaAtualizada.NomeFantasia;
            empresa.CNPJ = empresaAtualizada.CNPJ;
           
            _dbcontext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarEmpresa(int id)
        {
            var empresa = _dbcontext.Empresas.Find(id);

            if (empresa == null)
            {
                Console.WriteLine("Não encontrado!!!");
                return NotFound();
            }

            _dbcontext.Empresas.Remove(empresa);
            _dbcontext.SaveChanges();

            return NoContent();
        }
    }

}