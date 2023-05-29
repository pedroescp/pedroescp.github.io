
using Microsoft.AspNetCore.Mvc;

namespace uNotes.Application.Responses.Anexo
{
    public class ArquivoResponse
    {
        public ArquivoResponse(string base64, FileContentResult file)
        {
            Base64 = base64;
            File = file;
        }

        public ArquivoResponse(string base64)
        {
            Base64 = base64;
        }

        public string Base64 { get; set; }
        public FileContentResult? File { get; set; }
    }
}
