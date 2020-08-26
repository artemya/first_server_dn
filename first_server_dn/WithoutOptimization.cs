using System;
using System.Threading;
using System.Threading.Tasks;

namespace first_server_dn
{
    public class WithoutOptimization : IWords
    {
            public string GetHeaderInfo(string[] hosts)
            {
                long ellapledTicks = DateTime.Now.Ticks;

                var word = new Words();
                
                Tuple<string, string> who = Words.GetWord(hosts[0], "who");            

                Tuple<string, string> how = Words.GetWord(hosts[1], "how");

                Tuple<string, string> does = Words.GetWord(hosts[2], "does");

                Tuple<string, string> what = Words.GetWord(hosts[3], "what");

                string result = "";
                result +=  Words.CreateLine(who, how, does, what);

                ellapledTicks = DateTime.Now.Ticks - ellapledTicks;
                result += TimeSpan.FromTicks(ellapledTicks).TotalSeconds + " sec";

                return result;
            }
    }
}
