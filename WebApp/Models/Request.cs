using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Request
    {
        private JToken ParsedObject = null;

        public Request(string Json, string key = "form")
        {
            this.ParsedObject = JObject.Parse(Json)[key];
        }

        public String Get(String key)
        {
            return ((String)this.ParsedObject[key]).Trim();
        }

        public String GetOrNull(String key)
        {
            try {
                return ((String)this.ParsedObject[key]).Trim();
            } catch (NullReferenceException) {
                return null;
            }
        }

        public Dictionary<String, String> GetValidatedFile(HttpRequest httpRequest, int mediaType)
        {
            if (httpRequest.Form.Files.Count == 0)
                throw new Exception("No se ha enviado ningun archivo");

            IFormFile file = httpRequest.Form.Files[0];
            var filePath = Path.GetTempFileName();

            string extension = file.FileName.Substring(file.FileName.IndexOf(".") + 1, 3).ToLower();
            string saveRoot = @Directory.GetCurrentDirectory() + "\\Frontend\\public\\";
            string savePath = "Uploads\\";

            switch (mediaType) {
                case 1: // Musica
                    if (extension != "mp3")
                        throw new Exception("Tipo de contenido inválido. Solo se acepta MP3.");

                    savePath += "Music\\";
                    break;
                case 2: // Video
                    if (extension != "mp4")
                        throw new Exception("Tipo de contenido inválido. Solo se acepta MP4.");

                    savePath += "Videos\\";
                    break;
                case 3: // Libro
                    if (extension != "pdf")
                        throw new Exception("Tipo de contenido inválido. Solo se acepta PDF.");

                    savePath += "Books\\";
                    break;
                case 4: // Imagen
                    if (extension != "png" && extension != "jpg")
                        throw new Exception("Tipo de contenido inválido. Solo se acepta PNG o JPG.");

                    savePath += "Images\\";
                    break;
                default:
                    throw new Exception("Tipo de contenido inválido");
            }

            savePath += file.FileName;

            using (FileStream DestinationStream = new FileStream(saveRoot + savePath, FileMode.OpenOrCreate)) {
                file.CopyTo(DestinationStream);
            }

            Dictionary<String, String> toReturn = new Dictionary<String, String>();
            toReturn["fileSize"] = file.Length.ToString();
            toReturn["fileDestination"] = savePath.Replace("\\", "/");

            return toReturn;
        }
    }
}
