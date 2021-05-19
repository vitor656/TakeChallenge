using System.Collections.Generic;
using System.Threading.Tasks;
using TakeChallenge.Infra.GitHub.Models;

namespace TakeChallenge.Infra.GitHub
{
    public interface IGitHubApiClient
    {
        List<GitRepository> GetTakeProjects();
        Task<List<GitRepository>> GetTakeProjectsAsync();
    }
}