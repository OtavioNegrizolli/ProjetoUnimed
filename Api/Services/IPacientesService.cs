using Api.Model;
using Api.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Services
{
    public interface IPacientesService
    {
        public IEnumerable<Paciente> Index(IndexOptions options);   
        public Task<Paciente> Get(int id);   
    }
}
