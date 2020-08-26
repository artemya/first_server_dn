using System;
using System.Threading;
using System.Threading.Tasks;

namespace first_server_dn
{
    public class WithOptimization : IWords
    {
        public string GetHeaderInfo(string [] hosts)
        {
            return GetWordInfo(hosts).Result;
        }

        public async Task<string> GetWordInfo(string[] hosts) 
        {
            long ellapledTicks = DateTime.Now.Ticks;

            var word = new Words();

            Task<Tuple<string,string>> who = Task.Run(() =>
            {
                return Words.GetWord(hosts[0], "who");
            });
            Task<Tuple<string,string>> how = Task.Run(() =>
            {
                return Words.GetWord(hosts[1], "how");
            });
            Task<Tuple<string,string>> does = Task.Run(() =>
            {
                return Words.GetWord(hosts[2], "does");
            });
            Task<Tuple<string,string>> what = Task.Run(() =>
            {
                return Words.GetWord(hosts[3], "what");
            });
            await Task.WhenAll(who, how, does, what);

            string result = "";

            result +=  Words.CreateLine(who.Result, how.Result, does.Result, what.Result);

            ellapledTicks = DateTime.Now.Ticks - ellapledTicks;
            result += TimeSpan.FromTicks(ellapledTicks).TotalSeconds + " sec";

            return result;
        }
    }
}