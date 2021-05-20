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
            var takeProjectsResponse = new TakeProjectsResponse();

            if (repositories != null)
            {
                var csharpRepos = repositories
                    .Where(r => r.Language == "C#")
                    .OrderBy(r => r.Created_At).ToList();

                int count = 0;
                foreach (var repo in csharpRepos)
                {
                    count++;
                    var takeProjectViewModel = new TakeProjectViewModel
                    {
                        Id = repo.Id,
                        FullName = repo.Full_Name,
                        Description = repo.Description,
                        OwnerAvatar = repo.Owner.Avatar_Url
                    };

                    switch (count)
                    {
                        case 1:
                            takeProjectsResponse.Project1 = takeProjectViewModel;
                            break;
                        case 2:
                            takeProjectsResponse.Project2 = takeProjectViewModel;
                            break;
                        case 3:
                            takeProjectsResponse.Project3 = takeProjectViewModel;
                            break;
                        case 4:
                            takeProjectsResponse.Project4 = takeProjectViewModel;
                            break;
                        case 5:
                            takeProjectsResponse.Project5 = takeProjectViewModel;
                            break;
                    }
                }
            }

            return takeProjectsResponse;
        }
    }
}