using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Leilao.Models
{
    public class Pessoa
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Nome inválido!")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "O nome deve conter entre {0} e {1}! ")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Data de nascimento inválida!")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataDeNascimento { get; set; }


        [Display(Name = "Produto")]
        public Produto Produto { get; set; }

        [Display(Name = "Produto")]

        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Valor inválido!")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Lance { get; set; }


        public Pessoa()
        {

        }

        public Pessoa(int id, string nome, DateTime dataDeNascimento, Produto produto, double lance)
        {
            Id = id;
            Nome = nome;
            DataDeNascimento = dataDeNascimento;
            Produto = produto;
            if(produto.Preco >= lance)
            {
                throw new Exception("Valor não pode ser igual ou menor ao atual!");
            }
            Produto.Preco = lance;
            Lance = produto.Preco;
        }
    }
}
