using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dispatch.Models {
  public interface IOrganizationClient {
    Task<CustomerList> ListOrganizationsAsync();

    // Task<BrandResult> UpdateBrandAsync(int id, Dictionary<string, object> data);

    // Task DeleteBrandAsync(int id);

  }
}
