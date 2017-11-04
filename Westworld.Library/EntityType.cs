using System.ComponentModel.DataAnnotations;

namespace Westworld.Library
{
    public enum EntityType
    {
        [Display(Name="Miner Bob")]
        Miner,

        [Display(Name = "Elsa")]
        Wife
    }
}