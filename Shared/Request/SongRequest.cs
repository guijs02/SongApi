using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Request
{
    public record class SongRequest
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Artist { get; set; } = null!;

    }
}