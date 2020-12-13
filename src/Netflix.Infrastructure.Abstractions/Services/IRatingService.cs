using System;
using System.Threading.Tasks;

namespace Netflix.Infrastructure.Abstractions.Services
{
    public interface IRatingService
    {
        Task<int> GetRattingStars(Guid moveId);
    }
}
