using Api.Model;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Database
{
    public static class Seeder
    {
        public static void PreLoadData()
        {
            using var db_context = new AppDbContext();
			db_context.Database.EnsureCreated();
            // adiciona dados pré cadastrado caso não possua pacientes
            if (!db_context.Pacientes.Any())
            {
				db_context.Pacientes.AddRange(new Paciente[]
				{
					new Paciente
					{
						Nome= "Erick Juan Manoel da Silva",
						CPF= "70942408217",
						DataNascimento= DateTime.Parse("09/02/1967"),
						NomeMae= "Lavínia Luciana Nina",
						NumeroCarteirinha = "12343",
						Endereco = new Endereco
						{
							CEP= "78144004",
							Logradoro= "Rua Caeté",
							Numero= "699",
							Bairro= "Petrópolis",
							Cidade= "Várzea Grande"
						},
						PlanoAtivo = new Plano
						{
							Nome = "Plano p",
						}
					},
					new Paciente
					{
						Nome= "Gabriel Alexandre Filipe Mendes",
						CPF= "30069129428",
						DataNascimento= DateTime.Parse("02/03/1980"),
						NomeMae= "Adriana Carolina Natália",
						NumeroCarteirinha = "12344",
						Endereco = new Endereco
						{
							CEP= "76909804",
							Logradoro = "Rua Cedro",
							Numero= "714",
							Bairro= "Nossa Senhora de Fátima",
							Cidade= "Ji-Paraná",
						},
						PlanoAtivo = new Plano
                        {
							Nome = "Plano Premium"
                        }
					},
					new Paciente {
						Nome= "Luciana Elza Silva",
						CPF= "60755216237",
						DataNascimento= DateTime.Parse("26/02/1974"),
						NomeMae= "Sabrina Benedita",
						NumeroCarteirinha= "12345",
						Endereco = new Endereco
						{
							CEP= "79904602",
							Logradoro= "Rua Baltazar Saldanha",
							Numero= "169",
							Bairro= "Centro",
							Cidade= "Ponta Porã"
						},
						PlanoAtivo = new Plano
                        {
							Nome = "Plano Basico"
                        }
					}
				});

                db_context.SaveChanges();
            }
        }
    }
}
