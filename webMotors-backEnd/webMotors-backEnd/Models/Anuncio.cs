using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace webMotors_backEnd.Models
{
    public class anuncio
    {
        [Key]
        public int ID { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string versao { get; set; }
        public int ano { get; set; }
        public int quilometragem { get; set; }
        public string text { get; set; }

        public string fillMark()
        {
            string ApiBaseUrl = "http://desafioonline.webmotors.com.br/api/OnlineChallenge/"; // endereço da sua api
                                                                                              //string getModels = "Model"; //caminho do método a ser chamado
            string Method = "Make"; //caminho do método a ser chamado
                                    //string getVersions = "Version"; //caminho do método a ser chamado
                                    //var result = ;

            var model = new MarcasViewModel();
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiBaseUrl + Method);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                httpWebRequest.Accept = "application/json";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (Stream responseStream = httpResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    //var test = 
                    //var retorno = JsonConvert.DeserializeObject<List<string>>(streamReader.ReadToEnd());
                    var retorno = JsonConvert.DeserializeObject(reader.ReadToEnd());
                    return JsonConvert.SerializeObject(retorno);

                    //if (retorno != null)
                    //    result = retorno;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}