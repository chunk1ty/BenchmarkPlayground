using System;
using BenchmarkDotNet.Attributes;
using MessagePack;
using Newtonsoft.Json;

namespace SerializationAndDeserialization
{
    // |                             Method |       Mean |     Error |    StdDev |     Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
    // |----------------------------------- |-----------:|----------:|----------:|-----------:|-------:|------:|------:|----------:|
    // |    'Newtonsoft.Json - Deserialize' | 3,676.6 ns | 128.69 ns | 365.08 ns | 3,537.0 ns | 1.8387 |     - |     - |    2888 B |
    // | 'Newtonsoft.Json - PopulateObject' | 3,321.3 ns |  40.49 ns |  35.89 ns | 3,322.8 ns | 1.8387 |     - |     - |    2888 B |
    // |        'MessagePack - Deserialize' |   886.0 ns |   9.90 ns |   7.73 ns |   884.7 ns | 0.0858 |     - |     - |     136 B |
    [MemoryDiagnoser]
    public class NewtonsoftJsonVsMessagePack
    {
        private readonly string _myObjectAsString;
        private readonly byte[] _myObjectAsMessagePackBytes;

        public NewtonsoftJsonVsMessagePack()
        {
            var myObject = new MyObject(DateTime.Now, "someString", 42, 100, 200, 300);
            
            _myObjectAsString = JsonConvert.SerializeObject(myObject);

            _myObjectAsMessagePackBytes = MessagePackSerializer.Serialize(myObject);
        }
        
        [Benchmark(Description = "Newtonsoft.Json - Deserialize")]
        public void DeserializeObject()
        {
            JsonConvert.DeserializeObject<MyObject>(_myObjectAsString);
        }

        [Benchmark(Description = "Newtonsoft.Json - PopulateObject")]
        public void PopulateObject()
        {
            var myDeserializedObject = new MyObject();
            JsonConvert.PopulateObject(_myObjectAsString, myDeserializedObject);
        }

        [Benchmark(Description = "MessagePack - Deserialize")]
        public void MessagePack_Deserialize()
        {
            MessagePackSerializer.Deserialize<MyObject>(_myObjectAsMessagePackBytes, MessagePackSerializerOptions.Standard);
        }
    }
}