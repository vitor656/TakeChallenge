using System.Collections.Generic;
using System.Threading.Tasks;
using TakeChallenge.Domain.Common.Classes.GitHub;

namespace TakeChallenge.Domain.Common.Interfaces
{
    public interface IGitHubApiClient
    {

        List<GitRepository> GetTakeProjects();
        Task<List<GitRepository>> GetTakeProjectsAsync();
    }
}