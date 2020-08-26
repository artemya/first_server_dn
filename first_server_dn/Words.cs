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

        public string[] hosts = {"http://service1:3000/", "http://service2:3000/", "http://service3:3000/"};
        // public string[] hosts = {"http://localhost:3000/"};

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
            return array[rand.Next(0, array.Length)];
        }
        public static Tuple<string, string> GetWord (string host, string word) {
            
            Tuple<string, string> words = GetHeader(host + word);
            return words;
        }
        public static Tuple<string, string> GetHeader(string host)
        {
            string word = "";
            string header = "";
            Tuple<string, string> words;
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(host);
            HttpWebResponse myRes = (HttpWebResponse)myReq.GetResponse();

            using (StreamReader stream = new StreamReader(
            myRes.GetResponseStream())) { word = stream.ReadToEnd(); }
            header = myRes.Headers["InCamp-Student"];
            myRes.Close();

            words = new Tuple<string, string>(word, header);
            return words;
        }

        public static string CreateLine(Tuple<string, string> who, Tuple<string, string> how, Tuple<string, string> does, Tuple<string, string> what)
        {
            string result = "";
            result += who.Item1 + " " + how.Item1 + " " + does.Item1 + " " + what.Item1 + "\n";
            result += who.Item1 + " Gived from: " + who.Item2 + "\n";
            result += how.Item1 + " Gived from: " + how.Item2 + "\n";
            result += does.Item1 + " Gived from: " + does.Item2 + "\n";
            result += what.Item1 + " Gived from: " + what.Item2 + "\n";
            return result;
        }
}