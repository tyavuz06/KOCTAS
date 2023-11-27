using KOCTAS.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOCTAS.Business.Interfaces
{
    public interface IMovieBusiness
    {
        public BaseResponseModel Create(MovieDTO model);
        public BaseResponseModel Get(int id);
        public BaseResponseModel GetAll();
        public BaseResponseModel Update(int id, MovieDTO model);
        public BaseResponseModel Delete(int id);
    }
}
