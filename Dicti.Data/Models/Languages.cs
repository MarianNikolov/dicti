using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Dicti.Data.Models
{
    public partial class Languages
    {
        public Languages()
        {
            TransalationValues = new HashSet<TransalationValues>();
        }

        public int Id { get; set; }
        public string Language { get; set; }

        [JsonIgnore]
        public virtual ICollection<TransalationValues> TransalationValues { get; set; }
    }
}
