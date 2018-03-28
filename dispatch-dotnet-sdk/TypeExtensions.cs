using System;

namespace Dispatch
{
  public static class TypeExtensions
  {
    public static string PluralizeName(this Type type) => type.Name.Pluralize();

    public static string PluralizeNameToLower(this Type type) => type.Name.Pluralize().ToLower();

    public static string PluralizeAndExpandNameToLower(this Type type) => type.Name.Pluralize().ExpandWithUnderscores().ToLower();
  }
}
