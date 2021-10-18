using System;
using System.Threading;
using System.Threading.Tasks;
using BotToChiliz.Infrastructure.Adapter.Abstract;
using Chiliz.Net.Objects;
using Microsoft.Extensions.DependencyInjection;

namespace BotToChiliz.Console
{
    public class Program
    {
         
        public static async Task Main(string[] args)
        {
            try
            {
                var botto = new Botto();
                botto.SetServices();

                var client = botto._serviceProvider.GetRequiredService<IChilizNetAdapter>();
                var info = await client.GetAccountInfo(CancellationToken.None);
                print(info);
                System.Console.ReadLine();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                throw;
            }
            
        }
        private static void print(ChilizAccountInfo info)
        {
            System.Console.WriteLine("#### Account Info");
            foreach (var balance in info.Balances)
            {
                System.Console.WriteLine($"{nameof(balance.AssetId)}:{balance.AssetId}, " +
                                         $"{nameof(balance.Asset)}:{balance.Asset}, " +
                                         $"{nameof(balance.Free)}:{balance.Free}, " +
                                         $"{nameof(balance.Locked)}:{balance.Locked}, " +
                                         $"{nameof(balance.Total)}:{balance.Total}");
            }
            System.Console.WriteLine("######################");
        }
        
    }
}