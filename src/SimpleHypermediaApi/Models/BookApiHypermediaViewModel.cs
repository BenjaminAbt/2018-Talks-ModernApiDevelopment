using BenjaminAbt.ModernAPIDevelopment.ApiSdk.Models.Books;
using Newtonsoft.Json;

namespace BenjaminAbt.ModernAPIDevelopment.SimpleHypermediaApi.Models
{
    public class BookApiHypermediaViewModel: BookApiViewModel
    {
        public BookApiHypermediaViewModel(BookApiViewModel apiViewModel, string self)
        {
            Self = self;

            Name = apiViewModel.Name;
            Id = apiViewModel.Id;
            Price = apiViewModel.Price;
        }

        [JsonProperty("__self")]
        public string Self { get;  }
    }
}
