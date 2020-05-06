using System.Collections.Generic;
using System.Linq;

namespace LanguageFeatures.Models {
    public interface IProductSelection {

        IEnumerable<Product> Products { get; }

        IEnumerable<string> Names => Products.Select(p => p.Name);
    }
}
