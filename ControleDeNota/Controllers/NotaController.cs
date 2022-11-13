using ControleDeNota.Data;
using ControleDeNota.Dtos;
using ControleDeNota.Models;
using ControleDeNota.Repositorios;
using ControleDeNota.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeNota.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaController: ControllerBase
    {
        private readonly NotaRepositorio _notaRepositorio;
        private readonly LogErrorRepositorio _logErrorRepositorio;
        private readonly string erroBadRequest = "Ocorreu uma falha interna, favor tente novamente mais tarde ou procure um dos nossos suportes!";

        public NotaController(SistemasDeNotasDBContext ctx)
        {
            _notaRepositorio = new(ctx);
            _logErrorRepositorio = new(ctx);    
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorIDNota(int id)
        {
            try
            {
                NotaModel nota = _notaRepositorio.BuscarPorIDNota(id);
                if (nota == null)
                {
                    throw new ArgumentNullException();
                    
                }
                return Ok(nota);

            }
            catch (Exception ex)
            {
                _logErrorRepositorio.Adicionar(ex);
                
                return BadRequest(erroBadRequest);
            }
        }

        [HttpPost]
        public IActionResult Adicionar(NotaDto dto)
        {
            NotaModel nota = new();
            try
            {
                nota.AlunoId = dto.AlunoId;
                nota.Disciplina = dto.Disciplina;
                nota.NotaDaDisciplina = dto.Nota;
          
                _notaRepositorio.AdicionarNota(nota);
                return Ok();
            }
            catch (Exception ex)
            {
                _logErrorRepositorio.Adicionar(ex);
                
                return BadRequest(erroBadRequest);
            }
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarNota(int id,NotaDto nota)
        {
            try
            {
                var notaBase = _notaRepositorio.BuscarPorIDNota(id);

                if (notaBase == null)
                {
                    throw new ArgumentNullException();
                }
                notaBase.NotaDaDisciplina = nota.Nota;
                notaBase.Disciplina = nota.Disciplina;

                _notaRepositorio.AtualizarNota(notaBase);
                return Ok();
            }
            catch (Exception ex)
            {
                _logErrorRepositorio.Adicionar(ex);

                return BadRequest(erroBadRequest);
            }
        }

        [HttpDelete("{id}")]

        public IActionResult RemoverNota(int id)
        {
            try
            {
                var notaBase = _notaRepositorio.BuscarPorIDNota(id);
                if(notaBase == null)
                {
                    throw new ArgumentNullException();
                }
                _notaRepositorio.RemoverNota(notaBase);
                _notaRepositorio.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                _logErrorRepositorio.Adicionar(ex);
                return BadRequest(erroBadRequest);
            }
        }

    }
}
