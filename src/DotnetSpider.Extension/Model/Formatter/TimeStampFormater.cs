﻿using System;
using DotnetSpider.Core;

namespace DotnetSpider.Extension.Model.Formatter
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
	public class TimeStampFormatter : Formatter
	{
		protected override object FormateValue(object value)
		{
			DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0);
			string tmp = value.ToString();
			if (!long.TryParse(tmp, out var timeStamp))
			{
				return dt.ToString("yyyy-MM-dd HH:mm:ss");
			}

			switch (tmp.Length)
			{
				case 10:
					{
						dt = dt.AddSeconds(timeStamp).ToLocalTime();
						break;
					}
				case 13:
					{
						dt = dt.AddMilliseconds(timeStamp).ToLocalTime();
						break;
					}
				default:
					{
						throw new SpiderException("Wrong input timestamp");
					}
			}
			return dt.ToString("yyyy-MM-dd HH:mm:ss");
		}

		protected override void CheckArguments()
		{
		}
	}
}
