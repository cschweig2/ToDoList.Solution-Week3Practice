using System.Collections.Generic;

namespace AnimalShelter.Models
{
    public class Occupant
    {
        public Occupant()
        {
            this.Animals = new HashSet<Animal>();
        }

        public int OccupantId { get; set; }
        public string Type { get; set; }
        public virtual ICollection<Animal> Animals { get; set; }
    }
}