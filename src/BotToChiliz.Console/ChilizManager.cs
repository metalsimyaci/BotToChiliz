using System.Threading;
using System.Threading.Tasks;
using BotToChiliz.Infrastructure.Adapter.Abstract;
using Chiliz.Net.Objects;

namespace BotToChiliz.Console
{
    public class ChilizManager
    {
        #region Variables

        private readonly IChilizNetAdapter _adapter;

        #endregion

        #region Methods

        #region Constructor

        public ChilizManager(IChilizNetAdapter adapter)
        {
            _adapter = adapter;
        }
        
        #endregion

        #region Public Methods

        public async Task GetAccountInfo()
        {
            var info = await _adapter.GetAccountInfo(CancellationToken.None);
            Print(info);
        }
        
        #endregion

        #region Private Methods

        private static void Print(ChilizAccountInfo info)
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

        #endregion
        
        #endregion
    }
}