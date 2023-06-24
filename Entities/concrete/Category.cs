using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.concrete
{
    public class Category:IEntity   //Category object is a database object
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
