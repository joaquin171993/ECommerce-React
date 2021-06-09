using System;

namespace WebApi.Errors
{
    public class CodeErrorResponse
    {
        public CodeErrorResponse(int statusCode, string message = null)
        {
            this.StatusCode = statusCode;
            this.Message = message ?? GetDefaultMessageStatusCode(statusCode);
        }

        private static string GetDefaultMessageStatusCode(int statusCode)
        {
            string v = statusCode switch
            {
                400 => "El request enviado tiene errores",
                401 => "No tienes autorización para este recurso",
                404 => "No se encontró el item buscado",
                500 => "Se producieron errores en el servidor",
                _ => null
            };
            return v;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
