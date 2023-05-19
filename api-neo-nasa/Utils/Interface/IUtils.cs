namespace api_neo_nasa.Utils.Interface
{
    public interface IUtils
    {
        void CheckParameter(string days);
        string MakeExceptionMessageJSON(string exceptionMessage);
    }
}
