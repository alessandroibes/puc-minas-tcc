using AutoMapper;
using PUCMinas.SGQ.Processos.Business.Models;
using PUCMinas.SGQ.Processos.WebAPI.ViewModel;

namespace PUCMinas.SGQ.Processos.WebAPI.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            //CreateMap<Parada, ParadaViewModel>().ReverseMap();
            //CreateMap<Passo, PassoViewModel>().ReverseMap();
            //CreateMap<Workflow, WorkflowViewModel>().ReverseMap();
            CreateMap<PassoDefinicao, PassoDefinicaoViewModel>().ReverseMap();
            CreateMap<WorkflowDefinicao, WorkflowDefinicaoViewModel>().ReverseMap();
        }
    }
}
