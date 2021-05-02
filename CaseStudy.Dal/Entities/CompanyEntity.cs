using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CaseStudy.Dal.Entities
{
    public class CompanyEntity 
    {
        [Key]
        public int CompanyId { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public int AdvertisementLimit { get; set; } = 2;

        public int AdvertisementCount => JobEntities != null ? JobEntities.Count : 0;

        public ICollection<JobEntity> JobEntities { get; set; }
        public CompanyEntity()
        {
            JobEntities = new List<JobEntity>();
        }
    }
}
