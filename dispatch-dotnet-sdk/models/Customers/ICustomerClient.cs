using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dispatch.Models {
  public interface ICustomerClient {
    Task<CustomerList> ListCustomersAsync();

    // Task<BrandResult> UpdateBrandAsync(int id, Dictionary<string, object> data);

    // Task DeleteBrandAsync(int id);

  }
}
