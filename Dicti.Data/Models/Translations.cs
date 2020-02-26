using System;
using System.Collections.Generic;

namespace Dicti.Data.Models
{
    public partial class Translations
    {
        public Translations()
        {
            TransalationValues = new HashSet<TransalationValues>();
        }

        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime? EditedOn { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<TransalationValues> TransalationValues { get; set; }
    }
}
