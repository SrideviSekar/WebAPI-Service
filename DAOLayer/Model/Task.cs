using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAOLayer.Model
{
    public class Task
    {

        public int Task_ID { get; set; }
        public int? Parent_ID { get; set; }
        public int Project_ID { get; set; }
        public int User_ID { get; set; }
        public string TaskName { get; set; }
        public string ParentTaskName { get; set; }
        public DateTime? Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
        public int? Priority { get; set; }
        public string Status { get; set; }
    }
}