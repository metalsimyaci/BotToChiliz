using System;
using BotToChiliz.Domain.Data.Entity;
using BotToChiliz.Domain.DataAccess.EntityFramework.Abstract;
using BotToChiliz.Domain.DataAccess.EntityFramework.Context;
using BotToChiliz.Domain.DataAccess.EntityFramework.Repository;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BotToChiliz.Domain.DataAccess.EntityFramework.UnitOfWork
{
    internal class BotUnitOfWork:UnitOfWorkBase<DataContext>,IBotUnitOfWork
    {
        #region Variables

        private readonly Lazy<IBotRepository<int, Currency>> _currencyRepository;

        #endregion

        #region Properties

        public IBotRepository<int, Currency> CurrencyRepository => _currencyRepository.Value;

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
        }

        #endregion

        #region Public Methods



        #endregion

        #endregion
    }
}