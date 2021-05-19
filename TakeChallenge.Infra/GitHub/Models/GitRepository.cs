using System;

namespace TakeChallenge.Infra.GitHub.Models
{
    public class GitRepository
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Full_Name { get; set; }
        public string Language { get; set; }
        public Owner Owner { get; set; }
        public string Description { get; set; }
        public DateTime Created_At { get; set; }
    }
}