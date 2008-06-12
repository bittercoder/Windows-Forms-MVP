﻿using System.Collections;
using System.Collections.Generic;

namespace System.Linq
{
    public static partial class Enumerable
    {
        public static int Count<TSource>(this IEnumerable<TSource> source)
        {
            return Count(source, null);
        }

        public static int Count<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException("source");

            if (source is ICollection<TSource>) return ((ICollection<TSource>) source).Count;
            if (source is ICollection) return ((ICollection) source).Count;

            int count = 0;
            foreach (TSource element in source)
                if (predicate == null || predicate(element))
                    count++;

            return count;
        }

        // Min

        public static TSource Min<TSource>(this IEnumerable<TSource> source)
        {
            if (!source.Any() && default (TSource) == null) return default (TSource);
            return
                source.Aggregate(
                    (accum, element) => Comparer<TSource>.Default.Compare(accum, element) < 0 ? accum : element);
        }

        public static TSource? Min<TSource>(this IEnumerable<TSource?> source)
            where TSource : struct
        {
            if (!source.Any()) return default (TSource?);
            return
                source.Aggregate(
                    (accum, element) => Comparer<TSource?>.Default.Compare(accum, element) < 0 ? accum : element);
        }

        public static TResult Min<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            return source.Select(selector).Min();
        }

        // Max

        public static TSource Max<TSource>(this IEnumerable<TSource> source)
        {
            if (!source.Any() && default (TSource) == null) return default (TSource);
            return
                source.Aggregate(
                    (accum, element) => Comparer<TSource>.Default.Compare(accum, element) > 0 ? accum : element);
        }

        public static TSource? Max<TSource>(this IEnumerable<TSource?> source)
            where TSource : struct
        {
            if (!source.Any()) return default (TSource?);
            return
                source.Aggregate(
                    (accum, element) => Comparer<TSource?>.Default.Compare(accum, element) > 0 ? accum : element);
        }

        public static TResult Max<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            return source.Select(selector).Max();
        }

        // Aggregate

        public static TSource Aggregate<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource> func)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (func == null) throw new ArgumentNullException("func");

            bool noElements = true;
            TSource runningValue = default (TSource);

            foreach (TSource element in source)
            {
                if (noElements)
                {
                    noElements = false;
                    runningValue = element;
                }
                else
                    runningValue = func(runningValue, element);
            }

            if (noElements) ThrowNoElements();
            return runningValue;
        }

        public static TAccumulate Aggregate<TSource, TAccumulate>(
            this IEnumerable<TSource> source,
            TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> func)
        {
            return source.Aggregate(seed, func, x => x);
        }

        public static TResult Aggregate<TSource, TAccumulate, TResult>(
            this IEnumerable<TSource> source, TAccumulate seed,
            Func<TAccumulate, TSource, TAccumulate> func,
            Func<TAccumulate, TResult> resultSelector)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (func == null) throw new ArgumentNullException("func");
            if (resultSelector == null) throw new ArgumentNullException("resultSelector");

            TAccumulate runningValue = seed;

            foreach (TSource element in source)
                runningValue = func(runningValue, element);

            return resultSelector(runningValue);
        }
    }
}