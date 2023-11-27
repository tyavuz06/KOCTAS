using KOCTAS.Business.Interfaces;
using KOCTAS.Common.Entites;
using KOCTAS.Common.Models;
using KOCTAS.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOCTAS.Business.Core
{
    public class MovieBusiness : IMovieBusiness
    {
        private readonly IMovieDal _service;
        private readonly IMapper _mapper;

        public MovieBusiness(IMovieDal service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public BaseResponseModel Create(MovieDTO model)
        {
            var baseResponseModel = new BaseResponseModel();

            try
            {
                var entity = _mapper.AutoMapper.Map<MovieDTO, Movie>(model);
                entity.CreateDate = DateTime.Now;
                _service.Add(entity);
                baseResponseModel.SetCode(Common.SystemConstans.CODES.SUCCESS);
            }
            catch (Exception ex)
            {
                //log ex
                baseResponseModel.SetCode(Common.SystemConstans.CODES.SYSTEMERROR);
            }

            return baseResponseModel;
        }

        public BaseResponseModel Delete(int id)
        {
            var baseResponseModel = new BaseResponseModel();

            try
            {
                var entity = _service.Get(x => x.Id == id);

                if (entity != null)
                {
                    _service.Delete(entity);
                    baseResponseModel.SetCode(Common.SystemConstans.CODES.SUCCESS);
                }
                else
                    baseResponseModel.SetCode(Common.SystemConstans.CODES.NOTFOUND);

            }
            catch (Exception ex)
            {
                //log ex
                baseResponseModel.SetCode(Common.SystemConstans.CODES.SYSTEMERROR);
            }

            return baseResponseModel;
        }

        public BaseResponseModel Get(int id)
        {
            var responseModel = new GetMovieResponseModel();

            try
            {
                var entity = _service.GetWihEagerLoading("Actors", x => x.Id == id);

                if (entity != null)
                {
                    responseModel.Movie = _mapper.AutoMapper.Map<Movie, MovieDTO>(entity);
                    responseModel.SetCode(Common.SystemConstans.CODES.SUCCESS);
                }
                else
                    responseModel.SetCode(Common.SystemConstans.CODES.NOTFOUND);
            }
            catch (Exception ex)
            {
                //log ex
                responseModel.SetCode(Common.SystemConstans.CODES.SYSTEMERROR);
            }

            return responseModel;
        }

        public BaseResponseModel GetAll()
        {
            var baseResponseModel = new MovieListGetResponseModel();

            try
            {
                var list = _service.GetListWihEagerLoading("Actors");

                if (list != null)
                {
                    baseResponseModel.List = _mapper.AutoMapper.Map<List<Movie>, List<MovieDTO>>(list);
                    baseResponseModel.SetCode(Common.SystemConstans.CODES.SUCCESS);
                }
                else
                    baseResponseModel.SetCode(Common.SystemConstans.CODES.NOTFOUND);
            }
            catch (Exception ex)
            {
                //log ex
                baseResponseModel.SetCode(Common.SystemConstans.CODES.SYSTEMERROR);
            }

            return baseResponseModel;
        }

        public BaseResponseModel Update(int id, MovieDTO model)
        {
            var baseResponseModel = new BaseResponseModel();

            try
            {
                var entity = _service.Get(x => x.Id == id);

                if(entity == null)
                    baseResponseModel.SetCode(Common.SystemConstans.CODES.NOTFOUND);
                else
                {
                    var newEntity = _mapper.AutoMapper.Map<MovieDTO, Movie>(model);
                    newEntity.Id = id;
                    newEntity.CreateDate = DateTime.Now;
                    _service.Update(newEntity);
                    baseResponseModel.SetCode(Common.SystemConstans.CODES.SUCCESS);
                }                
            }
            catch (Exception ex)
            {
                //log ex
                baseResponseModel.SetCode(Common.SystemConstans.CODES.SYSTEMERROR);
            }

            return baseResponseModel;
        }
    }
}
