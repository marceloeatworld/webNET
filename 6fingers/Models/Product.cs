using Newtonsoft.Json;
using System.ComponentModel;

namespace _6fingers.Models
{
    public class Product
    {
       // [JsonIgnore]
        public int Id { get; set; }
     
        public string name { get; set; }
     
        public float price { get; set; }
        public string description { get; set; }
        public string category { get; set; }

    }
}
