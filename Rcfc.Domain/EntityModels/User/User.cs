using System;
using System.Collections.Generic;

using Rcfc.Domain.EntityModels.AspNetIdentity;

#nullable disable

namespace Rcfc.Domain.EntityModels
{
    public partial class User
    {
        public int Id { get; set; }
        public string AspNetIdentityUserId { get; set; }
        public string Cpf { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual AspNetUser AspNetIdentityUser { get; set; }
    }
}
