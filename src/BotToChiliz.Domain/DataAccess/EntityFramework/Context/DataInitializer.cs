using System;
using System.Collections.Generic;
using BotToChiliz.Domain.Data.Entity;
using BotToChiliz.Domain.Data.Enumeration;
using Microsoft.EntityFrameworkCore;

namespace BotToChiliz.Domain.DataAccess.EntityFramework.Context
{
    public static class DataInitializer
    {
        public static void Initialize(ModelBuilder builder)
        {
            builder.Entity<Currency>().HasData(
                new Currency
                {
                    Id = 1,
                    Code = "TRACHZ",
                    Name = "TRA",
                    Definition = "TRABZON SPOR CHILIZ",
                    IsActive = true,
                    CurrencyBalances = new List<CurrencyBalance>
                    {
                        new CurrencyBalance
                        {
                            Type = BalanceTypes.Balance, Balance = 0, CreatedBy = "metalsimyaci",
                            CreationTime = new DateTime(2021, 09, 28, 15, 35, 00),
                        },
                        new CurrencyBalance
                        {
                            Type = BalanceTypes.Rate, Balance = 0, CreatedBy = "metalsimyaci", CreationTime = new DateTime(2021, 09, 28, 15, 35, 00)
                        },
                    },
                    CreatedBy = "metalsimyaci",
                    CreationTime = new DateTime(2021, 09, 28, 15, 35, 00)
                });

            builder.Entity<Worker>().HasData(
                new Worker
                {
                    Id = 1,
                    CurrencyId = 1,

                    Type = WorkerType.BuyBot,
                    WorkerName = "TRA_BUYYER",
                    Status = WorkerStatuses.Wait,
                    Quantity = 10,

                    MinQuantityLimit = 5,
                    MaxQuantityLimit = -1,
                    PriceDifferentLimit = 0.09,
                    LevelReductionLimit = -1,
                    Timeout = 20,
                    RateLimit = -1,

                    CreatedBy = "metalsimyaci",
                    CreationTime = new DateTime(2021, 09, 28, 15, 35, 00),
                },
                new Worker
                {
                    Id = 2,
                    CurrencyId = 1,

                    Type = WorkerType.SellBot,
                    WorkerName = "TRA_SELLER",
                    Status = WorkerStatuses.Wait,
                    Quantity = 10,

                    MinQuantityLimit = 5,
                    MaxQuantityLimit = 10,
                    PriceDifferentLimit = 0.09,
                    LevelReductionLimit = 0.01,
                    Timeout = -1,
                    RateLimit = -1,

                    CreatedBy = "metalsimyaci",
                    CreationTime = new DateTime(2021, 09, 28, 15, 35, 00),
                },
                new Worker
                {
                    Id = 3,
                    CurrencyId = 1,

                    Type = WorkerType.RateBot,
                    WorkerName = "TRA_EXCHANGER",
                    Status = WorkerStatuses.Wait,
                    Quantity = -1,

                    MinQuantityLimit = -1,
                    MaxQuantityLimit = -1,
                    PriceDifferentLimit = -1,
                    LevelReductionLimit = -1,
                    Timeout = -1,
                    RateLimit = 0.10,//%10

                    CreatedBy = "metalsimyaci",
                    CreationTime = new DateTime(2021, 09, 28, 15, 35, 00),
                }
            );
        }
    }
}
