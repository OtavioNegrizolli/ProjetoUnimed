using Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System;

namespace Api.Database
{
    public class AppDbContext: DbContext
    {
        public string LocalArquivo { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            var pasta = Environment.SpecialFolder.LocalApplicationData;
            var caminho = Environment.GetFolderPath(pasta);
            LocalArquivo = System.IO.Path.Join(caminho, "unimed.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={LocalArquivo}");

        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Plano> Planos { get; set; }
    }
}
