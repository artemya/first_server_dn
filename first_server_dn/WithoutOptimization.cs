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
            result += who[0] + " " + how[0] + " " + does[0] + " " + what[0] + "\n";

            result += who[0] + " Gived from: " + who[1] + "\n";
            result += how[0] + " Gived from: " + how[1] + "\n";
            result += does[0] + " Gived from: " + does[1] + "\n";
            result += what[0] + " Gived from: " + what[1] + "\n";

            ellapledTicks = DateTime.Now.Ticks - ellapledTicks;
            result += TimeSpan.FromTicks(ellapledTicks).TotalSeconds;

            return result;
        }
}