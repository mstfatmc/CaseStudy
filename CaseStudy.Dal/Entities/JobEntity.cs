using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CaseStudy.Dal.Entities
{
    public class JobEntity 
    {
        [Key]
        public int JobId { get; set; }

        public string Description { get; set; }

        public string Position { get; set; }

        public DateTime ExpireDate { get; set; }

        public int Quality { get; set; }
          
        public string WorkType { get; set; }

        public string Benefits { get; set; }

        public decimal Salary { get; set; }

        public int CompanyId { get; set; }

        public CompanyEntity Company { get; set; }

    }
}
