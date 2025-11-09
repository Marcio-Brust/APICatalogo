using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using APICatalogo.Domain;

namespace APICatalogo.Repositories
{
    public class ProdutoRepository
    {
        private readonly string _connectionString;

        public ProdutoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Produto> GetProdutos()
        {
            var produtos = new List<Produto>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Produto";
                using (var command = new MySqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        produtos.Add(new Produto
                        {
                            // Ajuste os nomes dos campos conforme sua tabela
                            ProdutoId = Convert.ToInt32(reader["Id"]),
                            Nome = reader["Nome"].ToString(),
                            // Adicione outros campos conforme necessário
                        });
                    }
                }
            }
            return produtos;
        }
    }
}
