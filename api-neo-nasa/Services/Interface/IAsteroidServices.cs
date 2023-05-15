using api_neo_nasa.Models;

namespace api_neo_nasa.Services.Interface
{
    public interface IAsteroidServices
    {
        public List<NEODTO> GetOcurrencesOrdererBySize(NEOModel model);
        public string GenerateUrlPersonal(string days);
        public string GenerateUrlDemo(string days);
    }
}
