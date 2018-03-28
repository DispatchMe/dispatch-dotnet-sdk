using System;
using Newtonsoft.Json;

namespace Dispatch.Models {

  public class SurveyResponseResult : SingleRoot {

    [JsonProperty("survey_response")]
    public SurveyResponse SurveyResponse { get; set; }
  }
}
