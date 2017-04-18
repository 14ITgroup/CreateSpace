﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// TimeTrans 的摘要说明
/// </summary>
public static class TimeTrans
{

    /// <summary>
    /// 日期转换成unix时间戳
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static long DateTimeToUnixTimestamp(DateTime dateTime)
    {
        var start = new DateTime(1970, 1, 1, 8, 0, 0, dateTime.Kind);
        return Convert.ToInt64((dateTime - start).TotalSeconds);
    }

    /// <summary>
    /// unix时间戳转换成日期
    /// </summary>
    /// <param name="unixTimeStamp">时间戳（秒）</param>
    /// <returns></returns>
    public static DateTime UnixTimestampToDateTime(this DateTime target, long timestamp)
    {
        target = new DateTime(1970, 1, 1, 8, 0, 0, target.Kind);
        return target.AddSeconds(timestamp);
    }
}