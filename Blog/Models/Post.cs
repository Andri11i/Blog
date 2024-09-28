
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    public class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(2000)]
        public string Text { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreationDate {  get; set; }

        public List<Comment> Comments { get; set; }

        public int AuthorId { get; set; }


        
    }
}
