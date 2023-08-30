namespace GPMigratorApp.GPConnect.Helpers;

public static class ReferenceHelper
{
    public static string? GetId(string reference)
    {
        var split = reference.Split("/");
        return split.Length == 2 ? split[1] : null;
    }
}