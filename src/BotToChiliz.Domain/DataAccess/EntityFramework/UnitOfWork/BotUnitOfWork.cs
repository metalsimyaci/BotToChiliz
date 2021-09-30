using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BotToChiliz.Abstraction.DataAccess.EntityFramework.Abstract;
using BotToChiliz.Domain.Data.Entity;
using BotToChiliz.Domain.Data.Enumeration;
using BotToChiliz.Domain.DataAccess.EntityFramework.Context;
using BotToChiliz.Domain.DataAccess.EntityFramework.Repository;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BotToChiliz.Domain.DataAccess.EntityFramework.UnitOfWork
{
    internal class BotUnitOfWork:UnitOfWorkBase<DataContext>,IBotUnitOfWork
    {
        #region Variables

        private readonly Lazy<IBotRepository<int, Currency>> _currencyRepository;
        private readonly Lazy<IBotRepository<int, Worker>> _workerRepository;
        private readonly Lazy<IBotRepository<int, CurrencyBalance>> _currencyBalanceRepository;
        private readonly Lazy<IBotRepository<int, WorkerOrder>> _workerOrderRepository;

        #endregion

        #region Properties

        public IBotRepository<int, Worker> WorkerRepository => _workerRepository.Value;
        public IBotRepository<int, Currency> CurrencyRepository => _currencyRepository.Value;
        public IBotRepository<int, CurrencyBalance> CurrencyBalanceRepository => _currencyBalanceRepository.Value;
        public IBotRepository<int, WorkerOrder> WorkerOrderRepository => _workerOrderRepository.Value;

        #endregion

        #region Methods

        #region Constructor

        public BotUnitOfWork()
        {
            _currencyRepository = new Lazy<IBotRepository<int, Currency>>(() =>
            {
                var repository = Context.GetService<IBotRepository<int, Currency>>();
                repository.UseContext(Context);
                return repository;
            });

            _workerRepository = new Lazy<IBotRepository<int, Worker>>(() =>
            {
                var repository = Context.GetService<IBotRepository<int, Worker>>();
                repository.UseContext(Context);
                return repository;
            });

            _workerOrderRepository = new Lazy<IBotRepository<int, WorkerOrder>>(() =>
            {
                var repository = Context.GetService<IBotRepository<int, WorkerOrder>>();
                repository.UseContext(Context);
                return repository;
            });

            _currencyBalanceRepository = new Lazy<IBotRepository<int, CurrencyBalance>>(() =>
            {
                var repository = Context.GetService<IBotRepository<int, CurrencyBalance>>();
                repository.UseContext(Context);
                return repository;
            });
        }

        #endregion

        #region Public Methods

        public async Task<CurrencyBalance> ReadCurrencyBalanceAsync(BalanceTypes type, string currencyCode, CancellationToken cancellationToken)
        {
            return await CurrencyBalanceRepository.GetFirstAsync(x => x.Type == type
                                                                      && x.Currency.Code == currencyCode,
                o => o.OrderByDescending(s => s.CreationTime), cancellationToken, "Currency");
        }
        public async Task<IEnumerable<Worker>> ReadWorkersAsync(WorkerType type, CancellationToken cancellationToken)
        {
            return await WorkerRepository.GetAllAsync(x => x.Type == type, cancellationToken, "Currency");
        }

        #endregion

        #endregion
    }
}