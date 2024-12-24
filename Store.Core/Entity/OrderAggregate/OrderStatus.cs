using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Entity.OrderAggregate
{
    public enum OrderStatus
    {
        [EnumMember(Value = "Pendding")]
        Pendding,

        [EnumMember(Value = "PaymentRecived")]

        PaymentRecived,

        [EnumMember(Value = "PaymentFaild")]

        PaymentFaild
    }
}
