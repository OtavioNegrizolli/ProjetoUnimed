using Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System;

namespace Api.Database
{
    public class AppDbContext: DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var pasta = Environment.SpecialFolder.LocalApplicationData;
            var caminho = Environment.GetFolderPath(pasta);
            var localArquivo = System.IO.Path.Join(caminho, "unimed.db");
            options.UseSqlite($"Data Source={localArquivo}");
        }

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Plano> Planos { get; set; }
    }
}
