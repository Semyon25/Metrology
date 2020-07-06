﻿using System;
using System.Windows;
using WpfEx.AttachedBehaviors;

namespace WpfEx.Utils
{
    /// <summary>
    /// Contains helper and extension methods for System.String
    /// </summary>
    public static class StringEx
    {
        /// <summary>
        /// Returns true if <paramref name="s"/> contains System.Int32
        /// </summary>
        public static bool IsInt32(string s)
        {
            int dummy;
            bool isValid = Int32.TryParse(s, out dummy);
            return (isValid && dummy >= TextBoxBehavior.MinVal && dummy <= TextBoxBehavior.MaxVal);
        }

        /// <summary>
        /// Returns true if <paramref name="s"/> contains System.Double
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsDouble(string s)
        {
            double dummy;
            s = s.Replace(".", ",");
            bool isValid = Double.TryParse(s, out dummy);
            return (isValid && dummy >=TextBoxBehavior.MinVal && dummy <= TextBoxBehavior.MaxVal && Math.Abs(dummy-Math.Round(dummy,3))==0);
        }

        /// <summary>
        /// Extension method that calls String.IsNullorEmpty on <paramref name="s"/>. Returns true if <paramref name="s"/> is null or empty.
        /// </summary>
        public static bool IsNullOrEmpty(this string s)
        {
            return String.IsNullOrEmpty(s);
        }
    }
}