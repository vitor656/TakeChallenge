using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;
using TakeChallenge.Domain.Common.Interfaces;
using TakeChallenge.Domain.Common.Classes.GitHub;

namespace TakeChallenge.Infra.GitHub
{
    public class GitHubApiClient : IGitHubApiClient
    {
        private readonly RestClient Client;

        public GitHubApiClient()
        {
            Client = new RestClient("https://api.github.com/users/takenet/repos?sort=created");
        }

        public List<GitRepository> GetTakeProjects()
        {
            var request = new RestRequest(Method.GET);
            List<GitRepository> repositories = null;

            try
            {
                var response = Client.Execute(request);
                repositories = JsonConvert.DeserializeObject<List<GitRepository>>(response.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return repositories;
        }

        public async Task<List<GitRepository>> GetTakeProjectsAsync()
        {
            var request = new RestRequest(Method.GET);
            List<GitRepository> repositories = null;

            try
            {
                var response = await Client.ExecuteAsync(request);
                repositories = JsonConvert.DeserializeObject<List<GitRepository>>(response.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return repositories;
        }
    }
}