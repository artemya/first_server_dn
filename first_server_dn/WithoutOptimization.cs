using System;
using System.Threading;
using System.Threading.Tasks;

public class WithoutOptimization : IWords
{
        public string GetHeaderInfo(string[] hosts)
        {
            long ellapledTicks = DateTime.Now.Ticks;

            var word = new Words();
            
            string[] who = word.GetWord(word.RandomElement(hosts), "who");            

            string[] how = word.GetWord(word.RandomElement(hosts), "how");

            string[] does = word.GetWord(word.RandomElement(hosts), "does");

            string[] what = word.GetWord(word.RandomElement(hosts), "what");

            string result = "";
            result +=  word.CreateSrt(who, how, does, what);

            ellapledTicks = DateTime.Now.Ticks - ellapledTicks;
            result += TimeSpan.FromTicks(ellapledTicks).TotalSeconds;

            return result;
        }
}