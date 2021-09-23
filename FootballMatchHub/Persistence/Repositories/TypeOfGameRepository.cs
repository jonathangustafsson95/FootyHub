using FootballMatchHub.Core.Models;
using FootballMatchHub.Core.Repositories;
using FootballMatchHub.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballMatchHub.Persistence.Repositories
{
    public class TypeOfGameRepository : ITypeOfGameRepository
    {
        private readonly ApplicationDbContext _context;

        public TypeOfGameRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TypeOfGame> GetTypesOfGames()
        {
            return _context.TypesOfGame
                .ToList();
        }
    }
}