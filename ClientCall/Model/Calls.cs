using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClientCall.Model
{
    public class Calls
    {
        [Key]
        public int Call_Id{ get; set; }
        [ForeignKey("Client")]
        public int Client_Id { get; set; }
        public int PhoneNumber { get; set; }
        public string Call_To { get; set; }
        public DateTime Date_Call { get; set; }
        [JsonIgnore]

        public virtual Client Client { get; set; }
    }
}
