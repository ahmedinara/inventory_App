using Newtonsoft.Json;
using RfIDAicTec.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RfIDAicTec.Sheard
{
    public class HttpClientService
    {
        public string CallServicePost(string url, object request,string token)
        {
            string results = null;
            string messageResponse = "";

            try
            {
                Uri myUri = new Uri(url, UriKind.Absolute);
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(myUri);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "Post";
                httpWebRequest.Timeout = 30000;
                httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(JsonConvert.SerializeObject(request));
                }
                HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                Stream response = httpResponse.GetResponseStream();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    results = streamReader.ReadToEnd();
                }

            }
            catch (Exception ex)
            {
                var e = ex.ToString();

                results = "Filed";
            }

            return results;
        }
        public async Task<RequestResult<T>> CallService<T>(string url,string token)
        {
            try
            {
                Uri myUri = new Uri(url, UriKind.Absolute);
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(myUri);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                httpWebRequest.Timeout = 30000;
                HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);

                string result = "";
                Stream response = httpResponse.GetResponseStream();
                if (response == null) return new RequestResult<T>(default(T));
                using (StreamReader streamReader = new StreamReader(response))
                {
                    result = await streamReader.ReadToEndAsync();
                }

                if (!string.IsNullOrEmpty(result))
                    try
                    {
                        T messageResponse = JsonConvert.DeserializeObject<T>(result);

                        return new RequestResult<T>(messageResponse);
                    }
                    catch (Exception ex)
                    {
                        return new RequestResult<T>(ResponseMessagesEnum.NoContent, ex);
                    }

                return new RequestResult<T>(default(T));
            }
            catch (Exception ex)
            {
                return new RequestResult<T>(ex);
            }
        }

    } 
}
