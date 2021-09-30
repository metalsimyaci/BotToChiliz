using AutoMapper;
using BotToChiliz.Domain.Data.Entity;
using BotToChiliz.Domain.Models;

namespace BotToChiliz.Domain.Mapping.Profiles
{
    internal class BotProfile:Profile
    {
        public BotProfile()
        {
            CreateMap<WorkerModel, Worker>().ReverseMap();
        }
    }
}
