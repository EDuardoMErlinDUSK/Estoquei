using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estoquei.Models
{
    [Table("TipoMovimentacao")]
    public class TipoMovimentacao
    {
        [Column("IdTipoMovimentacao")]
        [Display(Name = "Codigo")]
        public int Id { get; set; }

        [Column("NomeTipoMovimentacao")]
        [Display(Name = "Nome do tipo de movimentacao")]
        public string NomeTipoMovimentacao { get; set; } = string.Empty;
    }
}
