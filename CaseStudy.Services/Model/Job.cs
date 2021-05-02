using System;
using System.Collections.Generic;
using System.Text;

namespace CaseStudy.Services.Model
{
    public class Job
    {
        public string Description { get; set; }

        public string Position { get; set; }

        public DateTime ExpireDate { get; set; }

        public int Quality { get; set; }

        public string WorkType { get; set; }

        public string Benefits { get; set; }

        public decimal Salary { get; set; }

        public JobListCompany Company { get; set; }
    }
}
