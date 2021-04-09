using Git.ViewModel.Commits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Git.Services
{
    interface ICommitsService
    {
        IEnumerable<CommitsViewModel> GetAll();
        string GetNameById(string id);
        string CreateCommit(string description, string id, string userId, string repoId);
        void Delete(string id, string userId);
    }
}
