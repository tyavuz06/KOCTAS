using KOCTAS.Common.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOCTAS.Common.Models
{
    public class MovieDTO
    {
        public MovieDTO()
        { 
        }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string DirectedBy { get; set; }
        public List<ActorDTO> Actors { get; set; }
    }
}
