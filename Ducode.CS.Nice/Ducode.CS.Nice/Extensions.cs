using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Extensions
{
	public static T Set<T>(this T obj, Action<T> action)
	{
		action(obj);
		return obj;
	}

	public static IEnumerable<TSource> WhereIf<TSource>(this IEnumerable<TSource> source, bool shouldExecute, Func<TSource, bool> predicate)
	{
		if (shouldExecute)
		{
			return source.Where(predicate);
		}
		return source;
	}

	public static T Random<T>(this IEnumerable<T> enumerable)
	{
		return enumerable.OrderBy(e => Guid.NewGuid()).FirstOrDefault();
	}

	public static IEnumerable<T> RandomSelection<T>(this IEnumerable<T> enumerable, int count)
	{
		count = enumerable.Count() < count ? enumerable.Count() : count;
		return enumerable.OrderBy(e => Guid.NewGuid()).Take(count);
	}

	public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
	{
		return enumerable == null || enumerable.Count() == 0;
	}

	public static string Join<T>(this IEnumerable<T> enumerable, string separator)
	{
		T[] array = null;
		if (enumerable.GetType().IsArray)
		{
			array = (T[])enumerable;
		}
		else
		{
			array = enumerable.ToArray();
		}
		return string.Join(separator, array);
	}

	//http://www.danylkoweb.com/Blog/10-extremely-useful-net-extension-methods-8J
	public static long GetAge(this DateTime input)
	{
		var age = DateTime.Now.Year - input.Year;
		if (DateTime.Now < input.AddYears(age))
		{
			age--;
		}
		return age;
	}

	public static T ParseEnum<T>(this string input) where T : struct, IConvertible
	{
		if (!typeof(T).IsEnum)
		{
			throw new ArgumentException("{0} is not an Enum", typeof(T).Name);
		}
		T result = default(T);
		Enum.TryParse(input, out result);
		return result;
	}

	public static StringBuilder AppendFormatLine(this StringBuilder stringBuilder, string format, params object[] args)
	{
		return stringBuilder.AppendLine(string.Format(format, args));
	}

	public static bool IsNullOrEmpty(this string input)
	{
		return string.IsNullOrEmpty(input);
	}

	public static bool IsNullOrWhiteSpace(this string input)
	{
		return string.IsNullOrWhiteSpace(input);
	}

	public static bool IsEmpty(this string input)
	{
		return string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input);
	}

	public static string[] Split(this string input, string splitString)
	{
		return input.Split(input, StringSplitOptions.None);
	}

	public static string[] Split(this string input, string splitString, StringSplitOptions options)
	{
		return input.Split(new string[] { splitString }, options);
	}

	public static string Format(this string format, params object[] args)
	{
		return string.Format(format, args);
	}

	public static string Format(this string format, object arg0)
	{
		return string.Format(format, arg0);
	}

	public static string Format(this string format, IFormatProvider provider, params object[] args)
	{
		return string.Format(provider, format, args);
	}

	public static string Format(this string format, object arg0, object arg1)
	{
		return string.Format(format, arg0, arg1);
	}

	public static string Format(this string format, object arg0, object arg1, object arg2)
	{
		return string.Format(format, arg0, arg1, arg2);
	}
}