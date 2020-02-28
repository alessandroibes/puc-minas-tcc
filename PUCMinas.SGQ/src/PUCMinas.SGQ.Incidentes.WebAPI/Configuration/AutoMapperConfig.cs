using AutoMapper;
using PUCMinas.SGQ.Incidentes.Business.Models;
using PUCMinas.SGQ.Incidentes.WebAPI.ViewModels;

namespace PUCMinas.SGQ.Incidentes.WebAPI.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Acao, AcaoViewModel>().ReverseMap();
            CreateMap<Causa, CausaViewModel>().ReverseMap();
            CreateMap<Gravidade, GravidadeViewModel>().ReverseMap();
            CreateMap<RNC, RNCViewModel>().ReverseMap();
        }
    }
}
