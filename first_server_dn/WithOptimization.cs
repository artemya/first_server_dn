using System;
using System.Threading;
using System.Threading.Tasks;
public class WithOptimization : IWords
{
public string GetHeaderInfo(string [] hosts)
        {
            long ellapledTicks = DateTime.Now.Ticks;

            var word = new Words();
            
            string[] who = {}; 
            string[] how = {};
            string[] does = {};
            string[] what = {};
            var thread1 = new Thread(
                () =>
                {
                    who = word.GetWord(word.RandomElement(hosts), "who");
                });
            thread1.Start();
            
            var thread2 = new Thread(
                () =>
                {
                    how = word.GetWord(word.RandomElement(hosts), "how");
                });
            thread2.Start();
            thread2.Join();

            var thread3 = new Thread(
                () =>
                {
                    does = word.GetWord(word.RandomElement(hosts), "does");
                });
            thread3.Start();
            thread3.Join();

            var thread4 = new Thread(
                () =>
                {
                    what = word.GetWord(word.RandomElement(hosts), "what");
                });
            thread4.Start();
            thread4.Join();

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