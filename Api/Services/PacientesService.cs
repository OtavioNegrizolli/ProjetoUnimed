using Api.Database;
using Api.Model;
using Api.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public class PacientesService : IPacientesService
    {
        private readonly AppDbContext _DbContext;

        public PacientesService(AppDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<Paciente> Get(int id)
        {
            var paciente = await _DbContext.Pacientes
                .Where(p => p.Id == id)
                .Include(p=>p.Exames)
                .Include(p=>p.Endereco)
                .Include(p=>p.PlanoAtivo)
                .FirstOrDefaultAsync();

            return paciente;
        }

        public IEnumerable<Paciente> Index(IndexOptions options = null)
        {
            if (options == null)
                options = IndexOptions.DefaultOptions;

            var skip = options.ElementosPagina * options.NumeroPagina;
            var resultados = _DbContext.Pacientes.Skip(skip).Take(options.ElementosPagina).ToList();

            if (typeof(Paciente).GetProperty(options.CampoFiltro) == null)
                options.CampoFiltro = nameof(Paciente.Id);
            
            var pacientes = options.Decrescente ? 
                resultados.OrderByDescending( p => p.GetType().GetProperty(options.CampoFiltro).GetValue(p) ) : 
                resultados.OrderBy( p => p.GetType().GetProperty(options.CampoFiltro).GetValue(p) );

            // Mudar para DTO com apenas os dados necessários
            return pacientes;
        }
    }
}
