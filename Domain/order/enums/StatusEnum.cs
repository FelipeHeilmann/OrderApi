using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Domain.Enums
{
    public enum StatusEnum
    {
        [Description("Created")]
        created = 1,
        [Description("Payed")]
        payed = 2,
        [Description("Refused")]
        refused = 3,
        [Description("Canceled")]
        canceled = 4,
        [Description("Shipped")]
        shiped = 5

    }
}
