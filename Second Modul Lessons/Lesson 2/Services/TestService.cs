﻿using Lesson_2.Models;
using System.Text.Json;
namespace Lesson_2.Services;

public class TestService
{
    private string testFilePath;
    private List<Test> _tests;
    public TestService()
    {
        testFilePath = "../../../Data/Test.json";
        if (File.Exists(testFilePath) is false)
        {
            File.WriteAllText(testFilePath, "[]");
        }
        _tests = new List<Test>();
        _tests = GetAllTests();
    }
    public Test AddTest(Test test)
    {
        test.Id = Guid.NewGuid();
        _tests.Add(test);
        Save();
        return test;
    }
    public Test GetById(Guid testId)
    {
        foreach (var test in _tests)
        {
            if (test.Id == testId)
            {
                return test;
            }
        }
        return null;
    }
    public bool DeleteTest(Guid testId)
    {
        var testFromDb = GetById(testId);
        if (testFromDb is null)
        {
            return false;
        }
        _tests.Remove(testFromDb);
        Save();
        return true;
    }
    public bool UpdateTest(Test test)
    {
        var testFromDb = GetById(test.Id);
        if (testFromDb is null)
        {
            return false;
        }
        var index = _tests.IndexOf(testFromDb);
        _tests[index] = test;
        Save();
        return true;
    }
   public List<Test> GetAllTests()
    {
        return GetTests();
    }
    public List<Test> GetRandomTests(int count)
    {
        if (count >= _tests.Count)
        {
            return _tests;
        }

        var randomTests = new List<Test>();
        var rand = new Random();
        for (var i = 0; i < count;)
        {
            var option = rand.Next(0, _tests.Count);
            if (randomTests.Contains(_tests[option]) is false)
            {
                randomTests.Add(_tests[option]);
                i++;
            }
        }

        return randomTests;
    }
    private List<Test>? GetTests()
    {
        var testsJson = File.ReadAllText(testFilePath);
        var tests = JsonSerializer.Deserialize<List<Test>>(testsJson);
        return tests;
    }

    private void Save()
    {
        var testJson = JsonSerializer.Serialize(_tests);
        File.WriteAllText(testFilePath, testJson);
    }


}
