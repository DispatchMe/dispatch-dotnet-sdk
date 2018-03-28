using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dispatch.Models {
  public interface IJobClient {
    Task<JobList> ListJobsAsync();

    // Task<BrandResult> UpdateBrandAsync(int id, Dictionary<string, object> data);

    // Task DeleteBrandAsync(int id);

  }
}
