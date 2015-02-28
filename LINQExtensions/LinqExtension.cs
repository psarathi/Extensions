using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQExtensions
{
    public static class LinqExtension
    {
        /// <summary>
        /// Skips the given number of items starting from the end of a collection
        /// </summary>
        /// <typeparam name="T">The type of the collection</typeparam>
        /// <param name="source">The collections of items</param>
        /// <param name="numberOfItemsToSkip">The number of items to skip from the collection</param>
        /// <returns>A collection of items with specified number of items skipped starting from the end</returns>
        public static IEnumerable<T> SkipLast<T>(this IEnumerable<T> source, int numberOfItemsToSkip)
        {
            if (source == null)
            {
                return null;
            }

            var items = source as IList<T> ?? source.ToList();

            if (!items.Any())
            {
                return null;
            }

            var itemsToSkip = Math.Abs(numberOfItemsToSkip);
            if (itemsToSkip >= items.Count())
            {
                return null;
            }

            return numberOfItemsToSkip > 0 ? source.Take(items.Count - itemsToSkip) : source.Skip(itemsToSkip);
        }

        /// <summary>
        /// Gets the given number of items starting from the end of a collection
        /// </summary>
        /// <typeparam name="T">The type of the collection</typeparam>
        /// <param name="source">The collections of items</param>
        /// <param name="numberOfItemsToTake">The number of items to take from the collection</param>
        /// <returns>A collection of items with specified number of items taken starting from the end</returns>
        public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> source, int numberOfItemsToTake)
        {
            if (source == null)
            {
                return null;
            }

            var items = source as IList<T> ?? source.ToList();

            if (!items.Any())
            {
                return null;
            }

            var itemsToTake = Math.Abs(numberOfItemsToTake);
            if (itemsToTake >= items.Count())
            {
                return source;
            }

            return numberOfItemsToTake > 0 ? source.Skip(items.Count - itemsToTake) : source.Take(itemsToTake);
        }

        /// <summary>
        /// Gets the items from the collection whose indices are provided
        /// </summary>
        /// <typeparam name="T">The type of the collection</typeparam>
        /// <param name="source">The collection of items</param>
        /// <param name="indexOfItemsToTake">An array of indices of the items to take</param>
        /// <returns>A collection of items whose indices were provided</returns>
        public static IEnumerable<T> TakeNs<T>(this IEnumerable<T> source, params int[] indexOfItemsToTake)
        {
            if (source == null)
            {
                return null;
            }

            if (indexOfItemsToTake == null)
            {
                return source;
            }

            if (!source.Any())
            {
                return null;
            }

            return !indexOfItemsToTake.Any() ? null : source.Where((item, i) => indexOfItemsToTake.Contains(i));
        }

        /// <summary>
        /// Skips the items from the collection whose indices are provided
        /// </summary>
        /// <typeparam name="T">The type of the collection</typeparam>
        /// <param name="source">The collection of items</param>
        /// <param name="indexOfItemsToSkip">An array of indices of the items to skip</param>
        /// <returns>A collection of items wihtout the skipped ones</returns>
        public static IEnumerable<T> SkipNs<T>(this IEnumerable<T> source, params int[] indexOfItemsToSkip)
        {
            if (source == null)
            {
                return null;
            }

            if (indexOfItemsToSkip == null)
            {
                return source;
            }

            if (!source.Any())
            {
                return null;
            }

            return !indexOfItemsToSkip.Any() ? source : source.Where((item, i) => !indexOfItemsToSkip.Contains(i));
        } 
    }
}
