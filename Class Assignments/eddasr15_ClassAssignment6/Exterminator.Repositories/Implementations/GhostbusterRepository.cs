using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Exterminator.Models.Dtos;
using Exterminator.Models.Entities;
using Exterminator.Models.InputModels;
using Exterminator.Repositories.Data;
using Exterminator.Repositories.Interfaces;

namespace Exterminator.Repositories.Implementations
{
    public class GhostbusterRepository : IGhostbusterRepository
    {
        private readonly IGhostbusterDbContext _dbContext;

        public GhostbusterRepository(IGhostbusterDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int CreateGhostbuster(GhostbusterInputModel ghostbuster)
        {
            var nextId = _dbContext.Ghostbusters.Count() + 1;
            _dbContext.Ghostbusters.Add(new Ghostbuster
            {
                Id = nextId,
                Name = ghostbuster.Name,
                Expertize = ghostbuster.Expertize
            });

            return nextId;
        }

        public bool DoesExist(int id) => _dbContext.Ghostbusters.Any(g => g.Id == id);

        public IEnumerable<GhostbusterDto> GetAllGhostbusters(string expertize) =>
            Mapper.Map<IEnumerable<GhostbusterDto>>(_dbContext.Ghostbusters.Where(g => g.Expertize.ToLower().Contains(expertize.ToLower())));

        public GhostbusterDto GetGhostbusterById(int id) =>
            Mapper.Map<GhostbusterDto>(_dbContext.Ghostbusters.Where(g => g.Id == id).ElementAtOrDefault(0));
    }
}