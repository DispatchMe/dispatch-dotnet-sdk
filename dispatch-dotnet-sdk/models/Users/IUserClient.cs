using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dispatch.Models {
  public interface IUserClient {
    Task<UserList> ListUsersAsync();

    // Task<BrandResult> UpdateBrandAsync(int id, Dictionary<string, object> data);

    // Task DeleteBrandAsync(int id);

  }
}
