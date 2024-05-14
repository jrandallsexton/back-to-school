
#nullable enable
using System;

namespace BackToSchool.CSharp.Records
{
    /// <summary>
    /// https://www.youtube.com/watch?v=VouNkrgkH78
    /// More goodness from Zoran
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="BirthDate"></param>
    public record PersonRecord(string Name, DateOnly BirthDate);

    public class Person : IEquatable<Person>
    {
        public string Name { get; init; }
        public DateOnly BirthDate { get; init; }

        public Person(string name, DateOnly birthDate)
        {
            this.Name = name;
            this.BirthDate = birthDate;
        }

        public void Deconstruct(out string name, out DateOnly birthDate)
        {
            name = this.Name;
            birthDate = this.BirthDate;
        }

        public bool Equals(Person? other) =>
            other?.Name.Equals(this.Name) == true &&
            other?.BirthDate.Equals(this.BirthDate) == true;

        public override bool Equals(object? other) => this.Equals(other as Person);

        public override int GetHashCode() => HashCode.Combine(this.Name, this.BirthDate);

        public override string ToString() =>
            $"{nameof(Person)} {{ {nameof(Name)} = {Name}, {nameof(BirthDate)} = {BirthDate} }}";
    }
}
