using KOCTAS.Common.Entites;
using KOCTAS.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOCTAS.Data.Core
{
    public class MovieDal : RepositoryBase<Movie, MovieContext>, IMovieDal
    {
    }
}
