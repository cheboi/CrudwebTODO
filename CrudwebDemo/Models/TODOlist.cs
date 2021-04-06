using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudwebTODO.Models
{
    public class TODOlist
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Specify your TODO")]
        public string Title { get; set; }

        public DateTime start_Time { get; set; }
        public DateTime End_Time { get; set; }
    }
}
