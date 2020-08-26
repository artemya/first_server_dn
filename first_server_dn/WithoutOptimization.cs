using System;
using System.Threading;
using System.Threading.Tasks;

public class WithoutOptimization : IWords
{
        public string GetHeaderInfo(string[] hosts)
        {
            long ellapledTicks = DateTime.Now.Ticks;

            var word = new Words();
            
            Tuple<string, string> who = Words.GetWord(word.RandomElement(hosts), "who");            

            Tuple<string, string> how = Words.GetWord(word.RandomElement(hosts), "how");

            Tuple<string, string> does = Words.GetWord(word.RandomElement(hosts), "does");

            Tuple<string, string> what = Words.GetWord(word.RandomElement(hosts), "what");

            string result = "";
            result +=  Words.CreateLine(who, how, does, what);

            ellapledTicks = DateTime.Now.Ticks - ellapledTicks;
            result += TimeSpan.FromTicks(ellapledTicks).TotalSeconds;

            return result;
        }
}