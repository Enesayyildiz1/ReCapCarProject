using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class CustomerDetailDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public int Findeks { get; set; }
    }
}
