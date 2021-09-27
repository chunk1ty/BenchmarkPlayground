using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace SimpleBenchmark
{
    //|       Method |      Mean |     Error |    StdDev | Allocated |
    //|------------- |----------:|----------:|----------:|----------:|
    //|    'Int Key' |  5.080 ns | 0.1265 ns | 0.2525 ns |         - |
    //| 'String Key' | 11.621 ns | 0.1420 ns | 0.1186 ns |         - |
    [MemoryDiagnoser]
    public class DictionaryKeyIntVsString
    {
        private readonly Dictionary<int, string> _intKeyDictionary = new() { {1, "1"}};
        private readonly Dictionary<string, string> _stringKeyDictionary = new() { { "1", "1" } };

        [Benchmark(Description = "Int Key")]
        public void DeserializeObject()
        {
            var result = _intKeyDictionary[1];
        }

        [Benchmark(Description = "String Key")]
        public void PopulateObject()
        {
            var result = _stringKeyDictionary["1"];
        }
    }
}
