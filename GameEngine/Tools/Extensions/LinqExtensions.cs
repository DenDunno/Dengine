
public static class LinqExtensions
{
    public static int Sum<T>(this IList<T> collection, int start, int end, Func<T, int> sum)
    {
        int result = 0;

        for (int i = start; i < end; ++i)
        {
            result += sum(collection[i]);
        }

        return result;
    }
}