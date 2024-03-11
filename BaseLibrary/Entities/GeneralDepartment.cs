

using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class GeneralDepartment : BaseEntity
    {
        //One to many relationship with departments 
        [JsonIgnore]
        public List<Department>? Departments { get; set; }
    }
}
