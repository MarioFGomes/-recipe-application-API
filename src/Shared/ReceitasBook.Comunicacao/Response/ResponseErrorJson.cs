
namespace ReceitasBook.Comunicacao.Response;

public class ResponseErrorJson
{
    public List<string> Errors { get; set; }

    public ResponseErrorJson(string message)
    {
        Errors = new List<string>
        {
            message
        };
    }

    public ResponseErrorJson(List<string> message)
    {
        Errors = message;
    }
}
