using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estoquei.Models
{
    [Table("TipoProduto")]
    public class TipoProduto
    {
        [Column("TipoProdutoId")]
        [Display(Name = "codigo")]
        public int Id { get; set; }

        [Column("NomeTipoProduto")]
        [Display(Name = "Nome do tipo do produto")]
        public string NomeTipoProduto { get; set; } = string.Empty;
    }
}
