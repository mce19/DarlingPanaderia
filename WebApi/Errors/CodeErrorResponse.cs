using Microsoft.EntityFrameworkCore.Query.Internal;

namespace WebApi.Errors
{
    public class CodeErrorResponse
    {
        //constructor
        public CodeErrorResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Menssage = message ?? GetValueOrDefaultTranslatorMessageStatusCode(statusCode);
        }

        private string GetValueOrDefaultTranslatorMessageStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "El Réquest enviado tiene errores",
                401 => "No tienes autorización",
                404 => "No se encontro el item buscado",
                500 => "Se propduceron errores en el resvidor",
                _ => ""
            };
        }

        public int StatusCode { get; set; }
        public string Menssage { get; set; }
    }
}