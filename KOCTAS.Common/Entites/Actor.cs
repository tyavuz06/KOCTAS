using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOCTAS.Common.Entites
{
    public class Actor: IEntity
    {
        [Key]
        public int Id { get; set; }
        public int MovieId { get; set; }
        [StringLength(50, ErrorMessage = "Aktör Adı En Fazla 50 Karakter Olabilir", MinimumLength = 5)]
        [Required]
        public string Name { get; set; } = string.Empty;
        [StringLength(50, ErrorMessage = "Aktör Soy Adı En Fazla 50 Karakter Olabilir", MinimumLength = 5)]
        [Required]
        public string Surname { get; set; } = string.Empty;

        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }
    }
}
