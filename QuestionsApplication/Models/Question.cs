using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionsApplication.Models {
    public class Question {
        [Key]
        public int ID { get; set; }
        public string Content { get; set; }
        public string Answer { get; set; }
        public ICollection<Test> Tests { get; set; }
    }
}
