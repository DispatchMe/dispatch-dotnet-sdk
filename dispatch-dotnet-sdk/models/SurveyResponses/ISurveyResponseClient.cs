using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dispatch.Models {
  public interface ISurveyResponseClient {

    Task<SurveyResponseList> ListSurveyResponsesAsync();

    // Task<BrandResult> UpdateBrandAsync(int id, Dictionary<string, object> data);

    // Task DeleteBrandAsync(int id);

  }
}
