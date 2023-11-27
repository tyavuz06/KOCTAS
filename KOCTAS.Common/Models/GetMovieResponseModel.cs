using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOCTAS.Common.Models
{
    public class GetMovieResponseModel: BaseResponseModel
    {
        public MovieDTO Movie { get; set; }
    }
}
