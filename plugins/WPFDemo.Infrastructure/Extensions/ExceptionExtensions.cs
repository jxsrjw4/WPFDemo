﻿using System;
using System.IO;
using System.Linq;

namespace WPFDemo.Infrastructure
{
    public static class ExceptionExtensions
    {
        public const int ERROR_HANDLE_DISK_FULL = unchecked((int)0x80070027);
        public const int ERROR_DISK_FULL = unchecked((int)0x80070070);

        public static bool IsNotEnoughDiskSpace(this IOException e)
        {
            return e.IsException(ERROR_DISK_FULL, ERROR_HANDLE_DISK_FULL);
        }

        public static bool IsConnectionWasClosed(this IOException e)
        {
            throw new NotImplementedException();
        }

        public static bool IsException(this Exception e, params int[] hResults)
        {
            return hResults.Any(item => item == e.HResult);
        }
    }
}
