using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SerializationAndDeserialization
{
    //|                       Method |     Mean |     Error |    StdDev |    Gen 0 |  Gen 1 | Allocated |
    //|----------------------------- |---------:|----------:|----------:|---------:|-------:|----------:|
    //|     'Single Deserialization' | 1.595 ms | 0.0313 ms | 0.0347 ms | 343.7500 |      - |  1,410 KB |
    //| 'Collection Deserialization' | 1.281 ms | 0.0242 ms | 0.0226 ms |  39.0625 | 3.9063 |    163 KB |
    [MemoryDiagnoser]
    public class SingleVsCollectionDeserialization
    {
        private const int ElementsSize = 500;

        private readonly string _mySingleObjectAsString;
        private readonly string _myCollectionObjectAsString;

        public SingleVsCollectionDeserialization()
        {
            var myObject = new MyObject(DateTime.Now, "someString", 42, 100, 200, 300);
            _mySingleObjectAsString = JsonConvert.SerializeObject(myObject);

            var myCollectionObject = new List<MyObject>();
            for (int i = 0; i < ElementsSize; i++)
            {
                myCollectionObject.Add(myObject);
            }

            _myCollectionObjectAsString = JsonConvert.SerializeObject(myCollectionObject);
        }

        [Benchmark(Description = "Single Deserialization")]
        public void SingleDeserialize()
        {
            for (int i = 0; i < ElementsSize; i++)
            {
                MyObject result = JsonConvert.DeserializeObject<MyObject>(_mySingleObjectAsString);
            }
        }

        [Benchmark(Description = "Collection Deserialization")]
        public void CollectionDeserialize()
        {
            MyObject[] result = JsonConvert.DeserializeObject<MyObject[]>(_myCollectionObjectAsString);
        }
    }
}
