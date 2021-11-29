namespace EasyTestFile.Tests;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

internal class AllDataContractResolver : Newtonsoft.Json.Serialization.DefaultContractResolver
{
    // Copied from https://stackoverflow.com/questions/24106986/json-net-force-serialization-of-all-private-fields-and-all-fields-in-sub-classe
    protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
    {
        IEnumerable<JsonProperty> props = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                                              .Select(p => base.CreateProperty(p, memberSerialization))
                                              .Union(type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                                                         .Select(f => base.CreateProperty(f, memberSerialization)));

        // manually skip the 'k__BackingField' fields
        props = props.Where(p => p.UnderlyingName == null || !p.UnderlyingName!.EndsWith("k__BackingField"));
        
        var list = props.ToList();
        list.ForEach(p => { p.Writable = true; p.Readable = true; });
        return list;
    }
}