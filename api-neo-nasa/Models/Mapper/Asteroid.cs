using AutoMapper;
using Newtonsoft.Json.Linq;

namespace api_neo_nasa.Models.Mapper
{
    public class Asteroid : Profile
    {
        public Asteroid()
        {
            CreateMap<AsteroidsDTO, AsteroidViewModel>();
        }
    }
}
