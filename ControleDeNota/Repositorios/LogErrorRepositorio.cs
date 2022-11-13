using ControleDeNota.Data;
using ControleDeNota.Models;

namespace ControleDeNota.Repositorios
{
    public class LogErrorRepositorio
    {
       
            private SistemasDeNotasDBContext _ctx;

            public LogErrorRepositorio(SistemasDeNotasDBContext ctx)
            {
                _ctx = ctx;
            }

            public void Adicionar(Exception ex)
            {
                var logBase = new LogError();

                logBase.InnerException = ex.InnerException?.ToString();
                logBase.StackTrace = ex.StackTrace;
                logBase.Mensagem = ex.Message;
                logBase.DataHoraRegistro = DateTime.Now;

                _ctx.LogsErros.Add(logBase);
                _ctx.SaveChanges();
            }
            
    }
}
