using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WordsAPI.Api;
using Domain.WordModel;
using PersonalityApp.Web.Domain;
using System.Runtime.InteropServices;
using System.Threading;

using RapidAPISDK;
using System.Web.Configuration;
using System.Net;
using WordsAPI;
using System.IO;
using Newtonsoft.Json;

namespace PersonalityApp.Web.Services
{
    public class WordSearchService : IWordSearchService
    {

        private static readonly WordSearchService _instance = new WordSearchService();

        public static WordSearchService GetInstance()
        {
            return _instance;
        }

        public List<DetailsResponse> GetSynonyms(WordRequest model)
        {
            string path = "https://wordsapiv1.p.mashape.com/words/";
            var key = WebConfigurationManager.AppSettings["X-Mashape-Key"].ToString();
            var host = WebConfigurationManager.AppSettings["X-Mashape-Host"].ToString();

            List<DetailsResponse> response = new List<DetailsResponse>();
            for (int i = 0; i < model.Word.Length; i++)
                {
                HttpWebRequest client = (HttpWebRequest)WebRequest.Create(path + model.Word[i] + "/synonyms");
                client.Method = "GET";
                // user agent
                client.Headers.Add("X-Mashape-Key", key);
                client.Accept = "application/json";
                
                //gets Response as a string
                string r = GetResponse(client);
                if (r != null)
                {
                    //this converts string to some JSON
                    var oResp = (DetailsResponse)deserialize(r, typeof(DetailsResponse));
                    response.Add(oResp);
                }
                else
                {
                    return null;
                }
            }
            return response;
            

        }




        public string GetResponse(WebRequest client)
        {

            try
            {
                var webResponse = (HttpWebResponse)client.GetResponse();
                if (!((int)webResponse.StatusCode >= 200 &&
                    (int)webResponse.StatusCode <= 299))
                {
                    webResponse.Close();
                    throw new ApiException((int)webResponse.StatusCode, webResponse.StatusDescription);
                }
                //dont think a binary response will ever happen because that is a namespace for a bool, and cause I am not passing a bool
                //if (binaryResponse)
                //{
                //    using (var memoryStream = new MemoryStream())
                //    {
                //        webResponse.GetResponseStream().CopyTo(memoryStream);
                //        var resp = memoryStream.ToArray();
                //        return resp as string;
                //    }
                //}
                else
                {
                    using (var responseReader = new StreamReader(webResponse.GetResponseStream()))
                    {
                        var responseData = responseReader.ReadToEnd();
                        return responseData as string;
                    }
                }
            }
            catch (WebException ex)
            {
                var response = ex.Response as HttpWebResponse;
                int statusCode = 0;
                if (response != null)
                {
                    statusCode = (int)response.StatusCode;
                    response.Close();
                }
                throw new ApiException(statusCode, ex.Message);
            }
        }

        private class ApiException : Exception
        {

            private int errorCode = 0;

            public ApiException() { }

            public int ErrorCode
            {
                get
                {
                    return errorCode;
                }
            }

            public ApiException(int errorCode, string message) : base(message)
            {
                this.errorCode = errorCode;
            }
        }

        private static object deserialize(string json, Type type)
        {
            try
            {
                return JsonConvert.DeserializeObject(json, type);
            }
            catch (IOException e)
            {
                throw new ApiException(500, e.Message);
            }

        }

    }
}
