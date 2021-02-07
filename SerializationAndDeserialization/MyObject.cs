using System;
using MessagePack;

namespace SerializationAndDeserialization
{
    [MessagePackObject]
    public class MyObject
    {
        public MyObject()
        {
        }
        
        public MyObject(DateTime someDateTime, 
                        string someString,
                        int someInteger, 
                        decimal someDecimal,
                        decimal someDecimal1, 
                        decimal someDecimal2)
        {
            SomeDateTime = someDateTime;
            SomeString = someString;
            SomeInteger = someInteger;
            SomeDecimal = someDecimal;
            SomeDecimal1 = someDecimal1;
            SomeDecimal2 = someDecimal2;
        }
        
        [Key("SomeDateTime")]
        public DateTime SomeDateTime { get; set; }
        
        [Key("SomeString")]
        public string SomeString { get; set; }
        
        [Key("SomeInteger")]
        public int SomeInteger { get; set; }

        [Key("SomeDecimal")]
        public decimal SomeDecimal { get; set; }
        
        [Key("SomeDecimal1")]
        public decimal SomeDecimal1 { get; set; }
        
        [Key("SomeDecimal2")]
        public decimal SomeDecimal2 { get; set; }
    }
}