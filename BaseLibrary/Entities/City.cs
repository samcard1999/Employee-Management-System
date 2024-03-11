

using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class City : BaseEntity
    {
        //Relationship: Many to one with Country
        public Country? Country { get; set; }
        public int CountryId {get; set;}

        //One to many relationship with town
        [JsonIgnore]
        public List<Town>? Towns { get; set; }

    }
}
