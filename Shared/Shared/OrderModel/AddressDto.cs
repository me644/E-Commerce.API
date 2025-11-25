using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Shared.OrderModel
{
    public record AddressDto
    {


        public string Firstname { get; init; } = string.Empty;

        public string Lastname { get; init; } = string.Empty;

        public string Country { get; init; } = string.Empty;


        public string City { get; init; } = string.Empty;
        public string Street { get; init; } = string.Empty;
    }
}
