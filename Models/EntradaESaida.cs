using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estoquei.Models
{
    [Table("EntradaESaida")]
    public class EntradaESaida
    {
        [Column("IdEntradaESaida")]
        [Display(Name = "codigo")]
        public int Id { get; set; }

        [ForeignKey("ProdutoId")]
        public int ProdutoId { get; set; }
        public Produto? Produto { get; set; }

        [Column("QuantidadeMovimento")]
        [Display(Name = "quantidade de movimento")]
        public string QuantidadeMovimento { get; set;} = string.Empty;

        [ForeignKey("IdTipoMovimentacao")]
        public int IdTipoMovimentacao { get; set; }
        public TipoMovimentacao? TipoMovimentacao { get; set; }

        [Column("DataMovimentacao")]
        [Display(Name = "data da movimentaçao")]
        public DateTime DataMovimentacao { get; set;}
    }
}
