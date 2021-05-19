using System.Threading.Tasks;
using TakeChallenge.Domain.Commands.Responses;

namespace TakeChallenge.Domain.Handlers
{
    public interface ITakeProjectsHandler
    {
        Task<TakeProjectsResponse> HandleAsync();
        TakeProjectsResponse Handle();
    }
}