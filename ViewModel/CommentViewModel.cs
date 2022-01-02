using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppRating.ViewModel
{
    public class CommentViewModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int CommentId { get; set; }
        public int ArticleId { get; set; }
        public string CommentDescription { get; set; }
        public int Rating { get; set; }
        public DateTime CommentedOn { get; set; }
    }
}