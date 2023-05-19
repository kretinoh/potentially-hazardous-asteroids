using api_neo_nasa.Utils.Interface;
using Newtonsoft.Json;

namespace api_neo_nasa.Utils
{
    public class Utils : IUtils
    {
        public string MakeExceptionMessageJSON(string exceptionMessage)
        {
            var errorObject = new
            {
                exceptionMessage
            };
            var json = JsonConvert.SerializeObject(errorObject);
            return json;
        }
    }
}
