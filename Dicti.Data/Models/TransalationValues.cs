using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Dicti.Data.Models
{
    public partial class TransalationValues
    {
        public int Id { get; set; }
        public int TransaltionId { get; set; }
        public string Text { get; set; }
        public int LanguageId { get; set; }

        public virtual Languages Language { get; set; }

        [JsonIgnore]
        public virtual Translations Transaltion { get; set; }
    }
}
