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

        public void CheckParameter(string days)
        {
            int parsedDay = int.Parse(days);
            if (days is null)
            {
                throw new ArgumentNullException(nameof(days));
            }
            else if (parsedDay < 1 || parsedDay > 7)
            {
                throw new ArgumentOutOfRangeException(nameof(days));
            }
        }
    }
}
