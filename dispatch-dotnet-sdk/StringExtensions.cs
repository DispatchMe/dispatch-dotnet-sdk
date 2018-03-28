using System;
using System.Text.RegularExpressions;
using PluralizationService;
using PluralizationService.English;

namespace Dispatch {
  public static class StringExtensions
  {

    private static readonly IPluralizationApi _pluralizationApi;

    static StringExtensions()
    {
        var builder = new PluralizationApiBuilder();
        builder.AddEnglishProvider();
        _pluralizationApi = builder.Build();
    }

    public static string Pluralize(this string source)
    {
      return _pluralizationApi.Pluralize(source);
    }

    public static string ExpandWithUnderscores(this string source)
    {
      if (string.IsNullOrWhiteSpace(source)) return string.Empty;
      return Regex.Replace(source, "([A-Z])", "_$1", RegexOptions.Compiled).TrimStart('_');
    }
  }
}
