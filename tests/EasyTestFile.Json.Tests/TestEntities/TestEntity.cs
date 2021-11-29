namespace EasyTestFile.Json.Tests.TestEntities;

using System;
using System.Collections.Generic;

public class TestEntity
{
    public string Name { get; set; }

    public DateTime DateOfBirth { get; set; }

    public List<SubTestEntity> Subs { get; set; }
}