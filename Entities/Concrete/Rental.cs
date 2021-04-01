using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Rental:IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; } 
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; } = DateTime.Now.Date;
        public DateTime? RentEndDate { get; set; }
        public DateTime?  ReturnDate { get; set; }
    }
}
