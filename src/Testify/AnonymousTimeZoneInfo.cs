﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testify
{
    /// <summary>
    /// Defines factory methods for creating <see langword="TimeZoneInfo"/> values.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class AnonymousTimeZoneInfo
    {
        /// <summary>
        /// Creates a random <see langword="TimeZoneInfo"/> value using a uniform distribution algorithm.
        /// </summary>
        /// <param name="anon">The anonymous data provider to use.</param>
        /// <returns>A random <see langword="TimeZoneInfo"/> value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="anon"/> is <see langword="null"/>.</exception>
        public static TimeZoneInfo AnyTimeZoneInfo(this IAnonymousData anon)
        {
            Argument.NotNull(anon, nameof(anon));

            return anon.AnyTimeZoneInfo(Distribution.Uniform);
        }

        /// <summary>
        /// Creates a random <see langword="TimeZoneInfo"/> value using the specified distribution algorithm.
        /// </summary>
        /// <param name="anon">The anonymous data provider to use.</param>
        /// <param name="distribution">The distribution algorithm to use.</param>
        /// <returns>A random <see langword="TimeZoneInfo"/> value.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="anon"/> is <see langword="null"/>.</exception>
        public static TimeZoneInfo AnyTimeZoneInfo(this IAnonymousData anon, Distribution distribution)
        {
            Argument.NotNull(anon, nameof(anon));

            // Figure out a better way to randomize a result in a PCL.
            return anon.AnyBool() ? TimeZoneInfo.Utc : TimeZoneInfo.Local;
        }
    }
}
