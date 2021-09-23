using FootballMatchHub.Core.Models;
using System.Collections.Generic;

namespace FootballMatchHub.Core.Repositories
{
    public interface ITypeOfGameRepository
    {
        IEnumerable<TypeOfGame> GetTypesOfGames();
    }
}