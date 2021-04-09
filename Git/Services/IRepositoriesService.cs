using Git.ViewModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Git.Services
{
    interface IRepositoriesService
    {
        IEnumerable<RepositoryViewModel> GetAll();
        string CreateRepo(string name, string repositoryType, string userId);
    }
}
