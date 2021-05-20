using System.Collections.Generic;

namespace TakeChallenge.Domain.Commands.Responses
{
    public class TakeProjectsResponse
    {
        public TakeProjectViewModel Project1 { get; set; }
        public TakeProjectViewModel Project2 { get; set; }
        public TakeProjectViewModel Project3 { get; set; }
        public TakeProjectViewModel Project4 { get; set; }
        public TakeProjectViewModel Project5 { get; set; }
    }
}