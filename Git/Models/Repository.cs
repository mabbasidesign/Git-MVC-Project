using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Git.Models
{
    public class Repository
    {
        public Repository()
        {
            this.Id = new Guid().ToString();
            this.Commits = new HashSet<Commit>();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsPublic { get; set; }

        [ForeignKey(nameof(User))]
        public string OwnerId { get; set; }
        public User Owner { get; set; }

        public virtual ICollection<Commit> Commits { get; set; }
    }
}
