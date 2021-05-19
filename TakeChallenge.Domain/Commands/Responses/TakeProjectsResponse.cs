using System.Collections.Generic;

namespace TakeChallenge.Domain.Commands.Responses
{
    public class TakeProjectsResponse
    {
        public List<TakeProjectViewModel> TakeProjects { get; set; }
    }
}