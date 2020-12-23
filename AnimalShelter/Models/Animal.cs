using System;

namespace AnimalShelter.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public string Breed { get; set; }

        public DateTime AdmittanceDate { get; set; }

        public int OccupantId { get; set; }
        public virtual Occupant Occupant { get; set; }
    }
}