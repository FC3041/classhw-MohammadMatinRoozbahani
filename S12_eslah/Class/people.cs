using System;

namespace CoreConceptsDemo
{
    public class Citizen : IComparable<Citizen>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int NationalId { get; set; }

        public Citizen(string firstName, string lastName, int nationalId)
        {
            FirstName = firstName;
            LastName = lastName;
            NationalId = nationalId;
        }

        public int CompareTo(Citizen other)
        {
            if (other == null) return 1;
            return this.NationalId.CompareTo(other.NationalId);
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} (NID: {NationalId})";
        }
    }
}