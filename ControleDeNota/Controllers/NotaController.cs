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
        private readonly INotaRepositorio _notaRepositorio;
        public NotaController(INotaRepositorio notaRepositorio)
        {
            _notaRepositorio = notaRepositorio;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NotaModel>> BuscarPorIDNota(int id)
        {
            NotaModel nota = await _notaRepositorio.BuscarPorIDNota(id);
            return Ok(nota);
        }

        [HttpPost]
        public async Task<ActionResult<NotaModel>> AdicionarNota([FromBody] NotaModel notaModel)
        {
            NotaModel nota = await _notaRepositorio.AdicionarNota(notaModel);
            return Ok(nota);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<NotaModel>> RemoverNota(int id)
        {
            bool removido = await _notaRepositorio.RemoverNota(id); ;
            return Ok(removido);
        }
    }
}
