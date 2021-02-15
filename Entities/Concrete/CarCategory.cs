
using Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public  class CarCategory:IEntity
    {
       
       
        public int CarCategoryId { get; set; }
        
        public string CategoryName { get; set; }
    }
}
