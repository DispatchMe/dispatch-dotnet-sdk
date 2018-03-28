using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dispatch.Models {

  public class SurveyResponseList : ListRoot {

    [JsonProperty("survey_responses")]
    public IEnumerable<SurveyResponse> SurveyResponses { get; set; }
  }

}
