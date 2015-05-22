using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace Infnet.Ivo.Tcc.Web.Helper
{
    public class WebApiHelper
    {
        public static string BaseUrl
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["WebApiBaseUrl"];
            }
        }

        public static WebClient NovoWebClient(TipoConteudo tipoConteudo = TipoConteudo.Padrao)
        {
            var client = new WebClient();
            client.BaseAddress = BaseUrl;
            if (tipoConteudo == TipoConteudo.Json)
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
            return client;
        }

        private static string InvokeWebClient(Func<WebClient, string> action)
        {
            try
            {
                return action.Invoke(action.Target as WebClient);
            }
            catch (WebException Ex)
            {
                string message = new StreamReader(Ex.Response.GetResponseStream()).ReadToEnd();

                throw new WebException(message, Ex, Ex.Status, Ex.Response);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public static string Get(string urlRelativa)
        {
            using (var client = NovoWebClient())
            {
                //return client.DownloadString(urlRelativa);
                return InvokeWebClient(p => client.DownloadString(urlRelativa));
            }
        }

        public static string Get(string urlRelativa, Guid id)
        {
            var url = String.Format("{0}/{1}", urlRelativa, id);
            return Get(url);
        }

        public static T Get<T>(string urlRelativa)
        {
            var json = Get(urlRelativa);
            var objeto = JsonConvert.DeserializeObject<T>(json);
            return objeto;
        }

        public static T Get<T>(string urlRelativa, Guid id)
        {
            var json = Get(urlRelativa, id);
            var objeto = JsonConvert.DeserializeObject<T>(json);
            return objeto;
        }

        public static string Post(string urlRelativa, string dados)
        {
            using (var client = NovoWebClient(TipoConteudo.Json))
            {
                //return client.UploadString(urlRelativa, "POST", dados);
                return InvokeWebClient(p => client.UploadString(urlRelativa, "POST", dados));
            }
        }

        public static string Post(string urlRelativa, object objeto)
        {
            var json = JsonConvert.SerializeObject(objeto);
            return Post(urlRelativa, json);
        }

        public static string Post(string urlRelativa, Guid id, object objeto)
        {
            urlRelativa = String.Format("{0}/{1}", urlRelativa, id.ToString());
            return Post(urlRelativa, objeto);
        }

        public static string Put(string urlRelativa, string dados)
        {
            using (var client = NovoWebClient(TipoConteudo.Json))
            {
                //return client.UploadString(urlRelativa, "PUT", dados);
                return InvokeWebClient(p => client.UploadString(urlRelativa, "PUT", dados));
            }
        }

        public static string Put(string urlRelativa, object objeto)
        {
            var json = JsonConvert.SerializeObject(objeto);
            return Put(urlRelativa, json);
        }

        public static string Put(string urlRelativa, Guid id, object objeto)
        {
            urlRelativa = String.Format("{0}/{1}", urlRelativa, id.ToString());
            return Put(urlRelativa, objeto);
        }

        public static string Delete(string urlRelativa)
        {
            using (var client = NovoWebClient())
            {
                //return client.UploadString(urlRelativa, "DELETE", "");
                return InvokeWebClient(p => client.UploadString(urlRelativa, "DELETE", ""));
            }
        }

        public static string Delete(string urlRelativa, Guid id)
        {
            var url = String.Format("{0}/{1}", urlRelativa, id);
            return Delete(url);
        }

        public static string Delete(string urlRelativa, Guid id, object objeto)
        {
            using (var client = NovoWebClient(TipoConteudo.Json))
            {
                urlRelativa = String.Format("{0}/{1}", urlRelativa, id.ToString());
                var json = JsonConvert.SerializeObject(objeto);

                //return client.UploadString(urlRelativa, "DELETE", json);
                return InvokeWebClient(p => client.UploadString(urlRelativa, "DELETE", json));
            }
        }
    }

    public enum TipoConteudo
    {
        Padrao,
        Json
    }
}
