using System;

namespace Tapas.DataLayer.Models
{
    public abstract class BaseEntity
    {
         DateTime Created { get; set; }
         DateTime? Modified { get; set; }
    }
}