using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOCTAS.Common.Models
{
    public class MovieListGetResponseModel: BaseResponseModel
    {
        public MovieListGetResponseModel()
        {

        }

        public List<MovieDTO> List { get; set; }
    }
}
