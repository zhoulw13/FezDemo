using System;

public static class Extensions {
    /// <summary>
    /// Resouce: http://stackoverflow.com/questions/908543/how-to-convert-from-system-enum-to-base-integer
    /// </summary>
    /// <param name="enumValue"></param>
    /// <returns></returns>
    public static int ToInt(this Enum enumValue) {
        return (int)((object)enumValue);
    }
}