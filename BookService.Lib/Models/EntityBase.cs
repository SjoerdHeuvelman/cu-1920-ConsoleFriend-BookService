using System;

namespace BookService.Lib.Models
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
