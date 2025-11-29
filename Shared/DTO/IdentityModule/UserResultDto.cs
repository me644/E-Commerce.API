using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO.IdentityModule
{
    public record UserResultDto
    {

        public string DisplayName { get; init; } = string.Empty;

        public string Email { get; init; }        = string.Empty;   
                                                 
        public string Tooken { get; init; } = string.Empty;
    }
}
