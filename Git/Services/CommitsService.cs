using Git.Data;
using Git.Models;
using Git.ViewModel.Commits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Git.Services
{
    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext db;
        public CommitsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string CreateCommit(string description, string id, string userId, string repoId)
        {
            var repo = this.db.Repositories.Where(x => x.Commits.Any(u => u.Id == id)).FirstOrDefault();
            var creator = this.db.Users.Where(x => x.Id == id).FirstOrDefault();

            var commit = new Commit
            {
                CreatedOn = DateTime.UtcNow,
                Description = description,
                CreatorId = creator.Id,
                RepositoryId = repo.Id
            };

            this.db.Commits.Add(commit);
            this.db.SaveChanges();
            return commit.Id;
        }

        public void Delete(string id, string userId)
        {
            var commit = this.db.Commits.Where(x => x.Id == id).FirstOrDefault();

            if(commit.CreatorId == userId)
            {
                this.db.Commits.Remove(commit);
                this.db.SaveChanges();
            }
        }

        public IEnumerable<CommitsViewModel> GetAll()
        {
            var commit = this.db.Commits.Select(x => new CommitsViewModel
            {
                Id = x.Id,
                CreatedOn = DateTime.UtcNow,
                Description = x.Description,
                Repository = x.Repository.Name
            });

            return commit;
        }

        public string GetNameById(string id)
        {
            var name = this.db.Repositories.Where(x => x.Id == id)
                .Select(u => u.Name)
                .FirstOrDefault();

            return name;
        }
    }
}
