using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Core.Entities
{
    public class Comments : BaseEntity
    {
        public string Content { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int PostId { get; set; }
        public Blog Blog { get; set; }
        public int? ParentCommentId { get; set; }
        public Comments? ParentComment { get; set; }
        public ICollection<Comments>? Children { get; set; }


    }
}
