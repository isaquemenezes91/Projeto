using ControleDeNota.Models;
using ControleDeNota.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeNota.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase

    {
        private readonly IAlunoRepositorio _alunoRepositorio;
        public  AlunoController(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<AlunoModel>>> MostrarTodosAlunos()
        {
            List<AlunoModel> alunos = await _alunoRepositorio.MostrarTodosAlunos();
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AlunoModel>> BuscarPorId( int id)
        {
            AlunoModel aluno = await _alunoRepositorio.BuscarPorId(id);
            return Ok(aluno);
        }

        [HttpPost]
        public async Task<ActionResult<AlunoModel>> Adicionar([FromBody] AlunoModel alunoModel)
        {
            AlunoModel aluno = await _alunoRepositorio.Adicionar(alunoModel);
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AlunoModel>> Atualizar([FromBody]AlunoModel alunoModel,int id)
        {
            alunoModel.Id = id;
            AlunoModel aluno = await _alunoRepositorio.Atualizar(alunoModel, id);
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AlunoModel>> Remover(int id)
        {
            bool removido = await _alunoRepositorio.Remover(id); ;
            return Ok(removido);
        }

    }
}
