using System;
using System.Collections.Generic;
using Core.Entities;

namespace DataAccess
{
    public partial class User : IEntity
    {
        public User()
        {
            Forms = new HashSet<Form>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Form> Forms { get; set; }
    }
}
