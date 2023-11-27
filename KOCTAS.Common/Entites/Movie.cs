using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOCTAS.Common.Entites
{
    public class Movie : IEntity
    {
        public Movie()
        {
            Actors = new List<Actor>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Film Adı En Fazla 100 Karakter Olabilir", MinimumLength = 5)]
        public string Name { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        [StringLength(50, ErrorMessage = "Yönetmen Adı En Fazla 50 Karakter Olabilir", MinimumLength = 5)]
        [Required]
        public string DirectedBy { get; set; } = string.Empty;
        public IEnumerable<Actor> Actors { get; set; }
    }
}
