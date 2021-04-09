using Git.Data;
using Git.Models;
using Git.ViewModel.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Git.Services
{
    public class RepositoriesService: IRepositoriesService
    {
        private readonly ApplicationDbContext db;

        public RepositoriesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public string CreateRepo(string name, string repositoryType, string userId)
        {
            var ownerName = this.db.Users
                .Where(x => x.Id == userId).Select(u => u.Username).FirstOrDefault();

            var owner = this.db.Users.Where(x => x.Id == userId).FirstOrDefault();

            var repo = new Repository
            {
                Name = name,
                CreatedOn = DateTime.UtcNow,
                OwnerId = owner.Id,
                Commits = new HashSet<Commit>()
            };

            this.db.Repositories.Add(repo);
            this.db.SaveChanges();
            return repo.Id;
        }

        public IEnumerable<RepositoryViewModel> GetAll()
        {
            var repositories = this.db.Repositories.Select(x => new RepositoryViewModel
            {
                Id = x.Id,
                Commits = x.Commits.Count(),
                CreatedOn = DateTime.UtcNow,
                Name = x.Name,
                Owner = x.Owner.Username
            }).ToArray();

            return repositories;
        }
    }
}
