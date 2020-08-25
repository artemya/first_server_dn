using System;
using System.Threading;
using System.Threading.Tasks;
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
            
            string[] who = {}; 
            string[] how = {};
            string[] does = {};
            string[] what = {};
            who = await Task.Run(()=>word.GetWord(word.RandomElement(hosts), "who"));
            how = await Task.Run(()=>word.GetWord(word.RandomElement(hosts), "how"));
            does = await Task.Run(()=>word.GetWord(word.RandomElement(hosts), "does"));
            what = await Task.Run(()=>word.GetWord(word.RandomElement(hosts), "what"));

            string result = "";

            result +=  word.CreateSrt(who, how, does, what);
            ellapledTicks = DateTime.Now.Ticks - ellapledTicks;
            result += TimeSpan.FromTicks(ellapledTicks).TotalSeconds;

            return result;
        }
}