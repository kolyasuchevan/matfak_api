using System;

public static class StringExtension
{
    public static string GetHash(this string str)
    {
        var md5 = MD5.Create();
        var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
        return Convert.ToBase64String(hash);
    }
}
