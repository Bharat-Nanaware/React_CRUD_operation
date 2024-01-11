using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace React_assignment_1_web_api.Model
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }
    }
}
