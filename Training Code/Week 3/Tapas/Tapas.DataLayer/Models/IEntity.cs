using System;

namespace Tapas.DataLayer.Models
{
    public interface IEntity
    {
         DateTime Created { get; set; }
         DateTime? Modified { get; set; }
    }
}