using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BotToChiliz.Abstraction.DependencyInjection.Abstract;
using BotToChiliz.Abstraction.Service.Abstract;
using BotToChiliz.Domain.Data.Enumeration;
using BotToChiliz.Domain.DataAccess.EntityFramework.UnitOfWork;
using BotToChiliz.Domain.Models;
using BotToChiliz.Domain.Services.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace BotToChiliz.Domain.Services
{
    public class BotManager:ManagerBase,IBotManager
    {
        private readonly IMapper _mapper;

        public BotManager(IDependencyContext dependencyContext, IMapper mapper) : base(dependencyContext)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<WorkerModel>> ReadWorkerAsync(WorkerType type, CancellationToken cancellationToken )
        {
            using (var uow = DependenctContext.ServiceProvider.GetService<IBotUnitOfWork>())
            {
                var r = await uow.ReadWorkersAsync(type, cancellationToken);
                var d = _mapper.Map<IEnumerable<WorkerModel>>(r);
                return d;
            }
        }

    }
}
