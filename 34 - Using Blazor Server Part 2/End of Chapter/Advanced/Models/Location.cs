using System.Collections.Generic;

namespace Advanced.Models {
    public class Location {

        public long LocationId { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public IEnumerable<Person> People { get; set; }
    }
}
