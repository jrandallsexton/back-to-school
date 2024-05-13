
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
}
