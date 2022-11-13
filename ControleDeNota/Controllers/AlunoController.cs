using ControleDeNota.Data;
using ControleDeNota.Dtos;
using ControleDeNota.Models;
using ControleDeNota.Repositorios;
using ControleDeNota.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ControleDeNota.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase

    {
        private readonly AlunoRepositorio _alunoRepositorio;
        private readonly LogErrorRepositorio _logRepositorio;
        private readonly string erroBadRequest = "Ocorreu uma falha interna, favor tente novamente mais tarde ou procure um dos nossos suportes!";
        public  AlunoController(SistemasDeNotasDBContext contexto)
        {
            _alunoRepositorio = new(contexto);
            _logRepositorio = new(contexto);
        }

        [HttpGet]
        public IActionResult MostrarTodosAlunos()
        {
            List<AlunoDto> retorno = new();
            try
            {
                var alunosBase = _alunoRepositorio.MostrarTodosAlunos();
                if (alunosBase.Count() > 0)
                {
                    foreach(AlunoModel aluno in alunosBase)
                    {
                        AlunoDto dto = new();
                        dto.Id = aluno.Id;
                        dto.Nome = aluno.Nome;
                        retorno.Add(dto);
                    }

                }
                return Ok(retorno);
            }
            catch(Exception ex)
            {
                _logRepositorio.Adicionar(ex);
                return BadRequest(erroBadRequest);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                AlunoModel aluno =  _alunoRepositorio.BuscarPorId(id);
                if (aluno == null)
                {
                    
                    return BadRequest($"Não foi possivel encontrar o ID:{id}");

                }
                return Ok(aluno);

            }
            catch (Exception ex)
            {
                _logRepositorio.Adicionar(ex);
                return BadRequest(erroBadRequest);
            }

        }

        [HttpPost]
        public IActionResult Adicionar(AlunoDto dto)
        {
            AlunoModel aluno = new();
            try
            {
                aluno.Nome = dto.Nome;
                _alunoRepositorio.Adicionar(aluno);
                return Ok();
            }
            catch(Exception ex)
            {
                _logRepositorio.Adicionar(ex);
                return BadRequest(erroBadRequest);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, AlunoModel aluno)
        {
            try
            {
                var alunoBase = _alunoRepositorio.BuscarPorId(id);
                if (alunoBase == null)
                {
                    return BadRequest($"Não foi possivel encontrar o ID:{id}");
                }

                alunoBase.Nome = aluno.Nome;
                alunoBase.Notas = aluno.Notas;
                _alunoRepositorio.Atualizar(alunoBase);
                
                return Ok();
            }
            catch (Exception ex)
            {
                _logRepositorio.Adicionar(ex);
                return BadRequest(erroBadRequest);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            try
            {
                var alunoBase = _alunoRepositorio.BuscarPorId(id);
                if (alunoBase == null)
                {
                    return BadRequest($"Não foi possivel encontrar o ID:{id}");
                }
                _alunoRepositorio.Remover(alunoBase);
                _alunoRepositorio.SaveChanges();
                return Ok();

            }
            catch (Exception ex)
            {
                _logRepositorio.Adicionar(ex);
                return BadRequest(erroBadRequest);
            }
        }

    }
}
