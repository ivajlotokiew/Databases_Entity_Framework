using System;

namespace StudentSystem.Models
{
    public class Homework
    {
        public int HomeworkId { get; set; }

        public string Content { get; set; }

        public string ContentType { get; set; }

        public DateTime SubmissionDate { get; set; }

        public virtual Course Course { get; set; }

        public virtual Student Student { get; set; }
    }
}
