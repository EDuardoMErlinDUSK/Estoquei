using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estoquei.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Column("IdProduto")]
        [Display(Name = "codigo")]
        public int Id { get; set; }

        [Column("NomeProduto")]
        [Display(Name ="Nome do produto")]
        public string NomeProduto { get; set; } = string.Empty;

        [Column("PesoProduto")]
        [Display(Name = "Peso do produto")]
        public int PesoProduto { get; set; }

        [Column("QuantidadeProduto")]
        [Display(Name = "Quantidade do produto")]
        public int QuantidadeProduto { get; set;}

        [Column("StatusProduto")]
        [Display(Name = "Status do produto")]
        public bool StatusProduto { get; set; }

        [ForeignKey("TipoProduto")]
        public int TipoProdutoId { get; set;}
        public TipoProduto? TipoProduto { get; set; }


        
    }
}
