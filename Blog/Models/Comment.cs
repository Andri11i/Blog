
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(2000)]
        public string Text { get; set; }

        [Column(TypeName = "date")]
        public DateTime CommentDate {  get; set; }
    }
}
