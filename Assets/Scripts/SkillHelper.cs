using System;

public static class SkillHelper
{
    public static bool TryFind<T>(T[] array, Func<T, bool> condition, out T result)
    {
        foreach (var item in array)
        {
            if (condition(item))
            {
                result = item;
                return true;
            }
        }

        result = default;
        return false;
    }
}
