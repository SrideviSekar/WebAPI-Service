using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAOLayer.Model
{
    public class Project 
    {
        public int Project_ID { get; set; }
        public string ProjectName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Priority { get; set; }
        public string Manager { get; set; }
        public int NoOfTasks { get; set; }
        public int CompletedTasks { get; set; }
    }
}