using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Git.Models
{
    public class Commit
    {
        public Commit()
        {
            Id = new Guid().ToString();
        }

        public string Id { get; set; }

        [Required]
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(User))]
        public string CreatorId { get; set; }
        public User Creator { get; set; }

        [ForeignKey("Repository")]
        public string RepositoryId { get; set; }
        public Repository Repository { get; set; }
    }
}
