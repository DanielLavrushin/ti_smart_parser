namespace Smart.Parser.Common.Extensions
{
    public static class CollectionExtensions
    {
        public static TOut Next<TOut>(this TOut[] array, int index)
        {
            if (array == null || array.Length == 0 || index < 0 || index >= array.Length - 1)
            {
                return default;
            }

            return array[index + 1];
        }

        public static TOut Next<TOut>(this IEnumerable<TOut> array, TOut current)
        {
            if (array == null || !array.Any() || current == null)
            {
                return default;
            }

            var list = array.ToList();
            int currentIndex = list.IndexOf(current);
            if (currentIndex == -1 || currentIndex >= list.Count - 1)
            {
                return default;
            }
            return list[currentIndex + 1];
        }
    }
}
