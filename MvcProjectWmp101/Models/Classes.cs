using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcProjectWmp101.Models
{
    [Table("Classes")]
    public class Classes
    {
         [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(50),Required]
        public string ClassName { get; set; }

        public virtual List<Students> Students { get; set; }

    }
}