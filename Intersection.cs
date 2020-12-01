namespace System
{
    /// <summary>
    /// Defines the interval types.
    /// </summary>
    public enum Interval
    {
        /// <summary>
        /// The start and the end are included.
        /// </summary>
        AllInclude,
        /// <summary>
        /// The start and the end are excluded.
        /// </summary>
        AllExclude,
        /// <summary>
        /// The start is excluded, the end part is included.
        /// </summary>
        StartExcludeEndInclude,
        /// <summary>
        /// The start is included, the end is excluded.
        /// </summary>
        StartIncludeEndExclude
    }
}
