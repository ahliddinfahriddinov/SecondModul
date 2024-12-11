﻿namespace Lesson_2.Models;

public class Student
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int Age { get; set; }

    public string Degree { get; set; }

    public string Gender { get; set; }

    public List<double> Results { get; set; } = new List<double>();
}
