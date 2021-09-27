using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace BotToChiliz.Hangfire.Jobs
{
    public class BiJob
    {
        public BiJob()
        {
            
        }

        public async Task<bool> JobAsync()
        {
            var message = "hisashi buridana (ひさひ ぶりだな)";
            Debug.Write(message);
            Console.WriteLine(message);
            return await Task.Run(() => true);
        }
    }
}
