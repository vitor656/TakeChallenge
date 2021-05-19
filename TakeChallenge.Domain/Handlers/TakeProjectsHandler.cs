using System.Collections.Generic;
using System.Linq;
using TakeChallenge.Domain.Commands.Responses;
using TakeChallenge.Infra.GitHub;
using System.Threading.Tasks;
using TakeChallenge.Infra.GitHub.Models;

namespace TakeChallenge.Domain.Handlers
{
    public class TakeProjectsHandler : ITakeProjectsHandler
    {
        private readonly IGitHubApiClient GitHubApiClient;

        public TakeProjectsHandler(IGitHubApiClient gitHubApiClient)
        {
            GitHubApiClient = gitHubApiClient;
        }

        public TakeProjectsResponse Handle()
        {
            var response = GitHubApiClient.GetTakeProjects();
            return ManipulateResponse(response);
        }

        public async Task<TakeProjectsResponse> HandleAsync()
        {
            var response = await GitHubApiClient.GetTakeProjectsAsync();
            return ManipulateResponse(response);
        }

        private TakeProjectsResponse ManipulateResponse(List<GitRepository> repositories)
        {
            List<TakeProjectViewModel> takeProjects = new List<TakeProjectViewModel>();

            if (repositories != null)
            {
                var csharpRepos = repositories
                    .Where(r => r.Language == "C#")
                    .OrderBy(r => r.Created_At).ToList();

                foreach (var repo in csharpRepos)
                {
                    var takeProjectViewModel = new TakeProjectViewModel
                    {
                        Id = repo.Id,
                        FullName = repo.Full_Name,
                        Description = repo.Description,
                        OwnerAvatar = repo.Owner.Avatar_Url
                    };

                    takeProjects.Add(takeProjectViewModel);
                }
            }

            return new TakeProjectsResponse
            {
                TakeProjects = takeProjects
            };
        }
    }
}