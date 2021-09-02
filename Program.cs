using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;




namespace Covid_App
{
    class Program
    {
        static void Main(string[] args)
        {
            string Url = String.Format("https://jsonplaceholder.typicode.com/posts/1/comments");
            WebRequest request = WebRequest.Create(Url);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string Strresultest = null;
            Stream stream = response.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            Strresultest = sr.ReadToEnd();
            sr.Close();
            var JsonData = Strresultest;
            var cmtsList = JsonConvert.DeserializeObject<Root>(JsonData);
            Console.WriteLine(cmtsList.Id);
         }
  
    }

    public class Root
    {
        public int PostId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }

    }

}
