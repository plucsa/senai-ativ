using Exo.WebApi.Contexts;
using Exo.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Exo.WebApi.Repositories
{
public class ProjetoRepository
{
private readonly ExoContext _context;
public ProjetoRepository(ExoContext context)
{
_context = context;
}
public List<Projeto> Listar()
{
return _context.Projetos.ToList();
}
using Exo.WebApi.Models;
using Exo.WebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
namespace Exo.WebApi.Controllers
{
[Route("api/[controller]")]
[ApiController]
public class ProjetosController : ControllerBase
{
private readonly ProjetoRepository _projetoRepository;
public ProjetosController(ProjetoRepository
projetoRepository)
{
_projetoRepository = projetoRepository;
}
[HttpGet]
public IActionResult Listar()
{
return Ok(_projetoRepository.Listar());
}
// Código novo que completa o CRUD.
[HttpPost]
public IActionResult Cadastrar(Projeto projeto)
{
_projetoRepository.Cadastrar(projeto);
return StatusCode(201);
}
[HttpGet("{id}")]
public IActionResult BuscarPorId(int id)
{
Projeto projeto = _projetoRepository.BuscarporId(id);
if (projeto == null)
{
return NotFound();
}
return Ok(projeto);
}
[HttpPut("{id}")]
public IActionResult Atualizar(int id, Projeto projeto)
{
_projetoRepository.Atualizar(id, projeto);
return StatusCode(204);
}
[HttpDelete("{id}")]
public IActionResult Deletar(int id)
{
try
{
_projetoRepository.Deletar(id);
return StatusCode(204);
}
catch (Exception e)
{
return BadRequest();
}
}
}
}



}
}
