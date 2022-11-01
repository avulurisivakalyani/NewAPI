using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using GWAPI.Base;
//using ServiceStack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;


namespace GWAPI.Utils
{
    public static class APIHelper
    {
        public static Dictionary<string, string> ToDictionary(Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row[0], row[1]);
            }
            return dictionary;
        }

        public static string ToCame1Case(String stringToSplit)
        {
            String[] lines = stringToSplit.Split();
            lines[0] = lines[0].ToLower();
            return String.Join(" ", lines);
        }
        public static string GetFilePath(string file)
        {
            return Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, file).ToString();
        }

        public static DTO ParseJsonFile<DTO>(string file)
        {
            return JsonConvert.DeserializeObject<DTO>(File.ReadAllText(ProjectSettings.PAYLOADS_PATH + file));

        }

        public static DTO DeserializeObject<DTO>(RestResponse response)
        {
            return JsonConvert.DeserializeObject<DTO>(response.Content);
        }

        public static string GetGUIDString()
        {
            return Guid.NewGuid().ToString("N");
        }
        public static string GetResponseObject(this RestResponse response, string responseObject)
        {
            JObject obs = JObject.Parse(response.Content);
            return obs[responseObject].ToString();

      
        }
        public static async Task<string> ReadAllTextAsync(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                string jsonData = reader.ReadToEnd();
                return jsonData;
            }
        }
    }




}



