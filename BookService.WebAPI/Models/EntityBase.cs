using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.Models
{
    public class EntityBase
    {
        public int Id { get; set; }

        private DateTime? createdDateTime;

        public DateTime? CreatedDateTime
        {
            get
            {
                return createdDateTime ?? DateTime.Now;
            }
            set
            {               
                if (value != null)
                {
                    createdDateTime = value;
                }
                else
                {
                    createdDateTime = DateTime.Now;
                }
            }
        }

    }
}
