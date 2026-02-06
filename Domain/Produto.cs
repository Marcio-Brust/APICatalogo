using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using APICatalogo.Validations;

namespace APICatalogo.Domain;

[Table("Produtos")]
public class Produto : IValidatableObject
{
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "O nome deve ter entre 3 e 20 caracteres")]
        //[PrimeiraLetraMaiuscula]
        public string? Nome { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "A descrição deve ter no máximo 10 caracteres")]
        public string? Descricao { get; set; }
        [Required]
        [Range(1, 10000, ErrorMessage = "O preço deve estar entre 1 e 10.000")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 10, ErrorMessage = "A URL da imagem deve ter entre 10 e 300 caracteres")]
        public string? ImagemUrl { get; set; }
        public float Estoque { get; set; }
        public DateTime DataCadastro { get; set; }

        public int CategoriaId { get; set; }

        [JsonIgnore]
        public Categoria? Categoria { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
                if (!string.IsNullOrEmpty(this.Nome))
                {
                        var primeiraLetra = this.Nome![0].ToString();
                        if (primeiraLetra != primeiraLetra.ToUpper())
                        {
                                yield return new ValidationResult("A primeira letra do nome deve ser maiúscula.", new[] { nameof(this.Nome) });
                        }
                }

                if (this.Estoque <= 0)
                {
                        yield return new ValidationResult("O estoque não pode ser negativo.", new[] { nameof(this.Estoque) });
                }

        }

}
