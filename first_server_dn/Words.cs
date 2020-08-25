using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Words
{
     private IWords _strategy;

        // public string[] hosts = {"http://172.27.0.3:3000/", "http://172.27.0.2:3000/", "http://172.27.0.4:3000/"};
        public string[] hosts = {"http://localhost:3000/"};

        public Words()
        { }

        public Words(IWords strategy)
        {
            this._strategy = strategy;
        }

        public void SetStrategy(IWords strategy)
        {
            this._strategy = strategy;
        }
        
        public string GetHeaderInfoStrategy() 
        {
            return this._strategy.GetHeaderInfo(hosts);
        }
        public string RandomElement(string[] array)
        {
            var rand = new Random();
            int randomElement = rand.Next(0, array.Length);
            return array[randomElement];
        }
        public string[] GetWord (string host, string word) {
            string[] gottenWord = {};
            string tempWho = GetHeader(host + word);
            gottenWord = tempWho.Split("/*/");
            return gottenWord;
        }
        public string GetHeader(string host)
        {
            string word = "";
            string header = "";
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(host);
            HttpWebResponse myRes = (HttpWebResponse)myReq.GetResponse();
            using (StreamReader stream = new StreamReader(
                myRes.GetResponseStream()))
                {
                    word = stream.ReadToEnd();
                }
                header = myRes.Headers["InCamp-Student"];
                myRes.Close();
            

            return word + "/*/" + host;
        }
}