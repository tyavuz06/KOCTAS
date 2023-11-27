using AutoMapper;
using KOCTAS.Common.Entites;
using KOCTAS.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOCTAS.Business
{
    public class AutoMap : IMapper
    {
        public Mapper AutoMapper { get; set; }

        public AutoMap()
        {
            AutoMapper = InitializeAutomapper();
        }

        private AutoMapper.Mapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Movie, MovieDTO>().ReverseMap();
                cfg.CreateMap<Actor, ActorDTO>().ReverseMap();
            });

            var mapper = new AutoMapper.Mapper(config);
            return mapper;
        }
    }
}
