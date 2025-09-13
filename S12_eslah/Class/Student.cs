using System;

namespace CoreConceptsDemo
{
    public abstract class PersonBase : IComparable<PersonBase>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }

        protected PersonBase(string firstName, string lastName, int id)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
        }

        public int CompareTo(PersonBase other)
        {
            if (other == null) return 1;
            return this.Id.CompareTo(other.Id);
        }

        public override string ToString() => $"{FirstName} {LastName} (ID: {Id})";
    }

    public class Undergrad : PersonBase
    {
        public Undergrad(string fn, string ln, int id) : base(fn, ln, id) { }
    }

    public class Instructor : PersonBase
    {
        public Instructor(string fn, string ln, int id) : base(fn, ln, id) { }
    }
}