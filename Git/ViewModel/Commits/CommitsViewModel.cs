using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Git.ViewModel.Commits
{
    public class CommitsViewModel
    {
        public string Id { get; set; }
        public string Repository { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
