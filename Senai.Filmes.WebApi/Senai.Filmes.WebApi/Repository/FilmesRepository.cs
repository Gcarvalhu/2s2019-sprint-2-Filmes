using Senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Repository
{
    public class FilmesRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=RoteiroFilmes;;Integrated Security=True";

        public List<FilmesDomain> Listar()
        {
            List<FilmesDomain> filmes = new List<FilmesDomain>();

            string Query = "SELECT F.IdFilme, F.Titulo, G.IdGenero, G.Nome AS NomeGenero FROM Filmes AS F INNER JOIN Generos AS G ON F.IdGenero = G.IdGenero;";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {

                        FilmesDomain filme = new FilmesDomain
                        {
                            IdFilme = Convert.ToInt32(sdr["IdArtista"]),
                            Titulo = sdr["Titulo"].ToString(),
                            Genero = new GeneroDomain
                            {
                                IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                Nome = sdr["Nome"].ToString()
                            }
                        };
                        filmes.Add(filme);
                    }
                }
            }
            return filmes;
        }
    }
}
