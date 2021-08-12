using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebDeploymentApi.Models;

namespace WebDeploymentApi.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class InfosController : ControllerBase
    {
        public static List<Info> infos = new List<Info>();

        /// <summary>
        /// With this GET method you can grab all the information from my own API. You can also go to www.{domain}/api/infos to get the JSON.
        /// The information returned by this API are the older projects in C# developed by the company TakeBlip
        /// </summary>
        /// <returns code="200"> Means that your GET was successful</returns>
        ///<returns code="500"> Means that occurred an error processing the GET method</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<Info>),200)]
        [ProducesResponseType(500)]
        public async Task<List<Info>> GetAsync()
        {

            
            try
            {
                infos = await GetData();
                return infos;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro" + e);
            }
            return infos;

        }




        private static async Task<List<Info>> GetData()
        {
            var url = "https://api.github.com/users/TakeNet/repos?sort=created&direction=desc";
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Add("User-Agent", @"Mozilla/5.0 (Windows NT 10; Win64; x64; rv:60.0) Gecko/20100101 Firefox/60.0");
                Console.WriteLine(client.BaseAddress);
                HttpResponseMessage response = await client.GetAsync(url);
                string strResult = await response.Content.ReadAsStringAsync();
                JToken token = JArray.Parse(strResult);
                dynamic ResultArray = Newtonsoft.Json.JsonConvert.DeserializeObject(strResult);

                //TESTING -------- var description = ResultArray[0].description;
                List<Info> jsonobj = new List<Info> { };
                foreach (dynamic array in ResultArray)
                {

                    string description = array.description;
                    string createdAt = array.created_at;
                    string language = array.language;
                    string imageLocatedAt = array.owner.avatar_url;
                    string title = array.name;
                    Info filtered = new Info(createdAt, language, description, imageLocatedAt, title);
                    jsonobj.Add(filtered);

                }
                if(CheckList().Result==false){
                int repoCounter = 0;
                for (int i = (jsonobj.Count - 1); i > 0; i--)
                {
                    if (jsonobj[i].Language == "C#" && repoCounter <= 4)
                    {
                        //Console.WriteLine($"\nData: {jsonobj[i].CreatedAt} \nDescricao: {jsonobj[i].Description} \nImage located at: {jsonobj[i].ImageLocatedAt}\nTitle: {jsonobj[i].Title}\n\n\n");

                        string description = jsonobj[i].Description;
                        string createdAt = jsonobj[i].CreatedAt;
                        string language = jsonobj[i].Language;
                        string imageLocatedAt = jsonobj[i].ImageLocatedAt;
                        string title = jsonobj[i].Title;
                        Info grabedInfo = new Info(createdAt, language, description, imageLocatedAt, title);
                        infos.Add(grabedInfo);
                        repoCounter++;
                    }
                }

               

                var json = JsonConvert.SerializeObject(jsonobj);


                return infos;
                }
                else
                {
                    return infos;
                }
            }
        }
        private static async Task<bool> CheckList()
        {
            var url = "https://webapichatbotdeployment.azurewebsites.net/api/infos";
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Add("User-Agent", @"Mozilla/5.0 (Windows NT 10; Win64; x64; rv:60.0) Gecko/20100101 Firefox/60.0");
                Console.WriteLine(client.BaseAddress);
                HttpResponseMessage response = await client.GetAsync(url);
                string strResult = await response.Content.ReadAsStringAsync();
                JToken token = JArray.Parse(strResult);
                dynamic ResultArray = Newtonsoft.Json.JsonConvert.DeserializeObject(strResult);
                int count = 0;
                bool listAlreadyFull = false;
                foreach (dynamic array in ResultArray)
                {
                    count++;
                }
                if (count > 4)
                {
                    listAlreadyFull = true;
                }

                return listAlreadyFull;
            }
        }
    }
}
