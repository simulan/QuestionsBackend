using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionsApplication.Models {
    public class Test {
        [Key]
        public int ID { get; set; }
        [MaxLength(32, ErrorMessage = "Name can be 32 char max.")]
        public string Name { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
