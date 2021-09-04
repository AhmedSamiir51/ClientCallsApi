using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClientCall.Model
{
    public class Client
    {
        [Key]
        public int Clint_Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public int Phone { get; set; }
        [JsonIgnore]
        public virtual Calls Calls { get; set; }
    }
}
