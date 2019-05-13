using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAOLayer.Model
{
    public class ParentTask
    {
        public int Parent_ID { get; set; }
        public string Parent_Task { get; set; }
    }
}