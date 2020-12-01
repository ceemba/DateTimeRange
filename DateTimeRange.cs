namespace System
{
    /// <summary>
    /// Defines a DateTime range object.
    /// </summary>
    public struct DateTimeRange
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimeRange"/>.
        /// </summary>
        /// <param name="start">A <see cref="DateTime"/> representing the start of the range.</param>
        /// <param name="end">A <see cref="DateTime"/> representing the end of the range.</param>
        /// <remarks>By default the start and the end dates are included.</remarks>
        /// <exception cref="ArgumentException">If the <paramref name="start"/> is bigger than <paramref name="end"/>.</exception>
        public DateTimeRange(DateTime start, DateTime end)
            : this(start, end, Interval.AllInclude)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimeRange"/>.
        /// </summary>
        /// <param name="start">A <see cref="DateTime"/> representing the start of the range.</param>
        /// <param name="end">A <see cref="Nullable{DateTime}"/> representing the end of the range.</param>
        /// <remarks>If the <paramref name="end"/> is null, the <see cref="System.Interval"/> is set to 'StartIncludeEndExclude', otherwise is set to 'AllIncude'.</remarks>
        /// <exception cref="ArgumentException">If the <paramref name="start"/> is bigger than <paramref name="end"/>.</exception>
        public DateTimeRange(DateTime start, DateTime? end)
            : this(start, end, end.HasValue ? Interval.AllInclude : Interval.StartIncludeEndExclude)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimeRange"/>.
        /// </summary>
        /// <param name="start">A <see cref="DateTime"/> representing the start of the range.</param>
        /// <param name="end">A <see cref="Nullable{DateTime}"/> representing the end of the range.</param>
        /// <remarks>If the <paramref name="start"/> is null, the <see cref="System.Interval"/> is set to 'StartExcludeEndInclude', otherwise is set to 'AllInclude'.</remarks>
        /// <exception cref="ArgumentException">If the <paramref name="start"/> is bigger than <paramref name="end"/>.</exception>
        public DateTimeRange(DateTime? start, DateTime end)
            : this(start, end, start.HasValue ? Interval.AllInclude : Interval.StartExcludeEndInclude)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimeRange"/>.
        /// </summary>
        /// <param name="start">A <see cref="DateTime"/> representing the start of the range.</param>
        /// <param name="end">A <see cref="Nullable{DateTime}"/> representing the end of the range.</param>
        /// <param name="interval">The <see cref="System.Interval"/> (default: 'Close').</param>
        /// <exception cref="ArgumentOutOfRangeException">If no value.</exception>
        /// <exception cref="ArgumentException">If <paramref name="start"/> has no value and the interval is different of 'Open' or 'LeftOpenRightClose'.</exception>
        /// <exception cref="ArgumentException">If <paramref name="end"/> has no value and the interval is different of 'Open' or 'LeftCloseRightOpen'.</exception>
        /// <exception cref="ArgumentException">If the <paramref name="start"/> is bigger than <paramref name="end"/>.</exception>
        public DateTimeRange(DateTime? start, DateTime? end, Interval interval = Interval.AllInclude)
        {
            if (!start.HasValue && !end.HasValue)
            {
                throw new ArgumentOutOfRangeException("The range is incorrect because the start and the end has no value.");
            }

            if (!start.HasValue && (interval != Interval.AllExclude && interval != Interval.StartExcludeEndInclude))
            {
                throw new ArgumentException("The interval type is incorrect because the start has no value.", "interval");
            }

            if (!end.HasValue && (interval != Interval.AllExclude && interval != Interval.StartIncludeEndExclude))
            {
                throw new ArgumentException("The interval type is incorrect because the end has no value.", "interval");
            }

            if (end.HasValue && start >= end.Value)
            {
                throw new ArgumentException("Start is bigger than End.", "start");
            }

            Start = start;
            End = end;
            Interval = interval;
        }

        /// <summary>
        /// Gets the duration of the <see cref="DateTimeRange"/>.
        /// </summary>
        /// <value>A <see cref="TimeSpan"/> representing the duration.</value>
        public TimeSpan Duration
        {
            get
            {
                return this.Interval switch
                {
                    Interval.AllExclude => this.Start.HasValue && this.End.HasValue ? this.End.Value.AddSeconds(-1) - this.Start.Value.AddSeconds(1) : TimeSpan.MaxValue,
                    Interval.StartIncludeEndExclude => this.End.HasValue ? this.End.Value.AddSeconds(-1) - this.Start.Value : TimeSpan.MaxValue,
                    Interval.StartExcludeEndInclude => this.Start.HasValue ? this.End.Value - this.Start.Value.AddSeconds(1) : TimeSpan.MaxValue,
                    _ => this.End.Value - this.Start.Value
                };
            }
        }

        /// <summary>
        /// The end of the <see cref="DateTimeRange"/>.
        /// </summary>
        public DateTime? End { get; private set; }

        /// <summary>
        /// Gets the first date include in the current <see cref="DateTimeRange"/>.
        /// </summary>
        /// <value>A <see cref="DateTime"/> representing the first date in the range.</value>
        public DateTime FirstDate
        {
            get
            {
                return this.Interval switch
                {
                    var x when x == Interval.AllExclude || x == Interval.StartExcludeEndInclude => this.Start.HasValue ? this.Start.Value.AddSeconds(1) : DateTime.MinValue,
                    _ => this.Start.Value
                };
            }
        }

        /// <summary>
        /// The <see cref="IntervalType"/> of the <see cref="DateTimeRange"/>.
        /// </summary>
        public Interval Interval { get; set; }

        /// <summary>
        /// Gets the last date include in the current <see cref="DateTimeRange"/>.
        /// </summary>
        /// <value>A <see cref="DateTime"/> representing the last date in the range.</value>
        public DateTime LastDate
        {
            get
            {
                return this.Interval switch
                {
                    var x when x == Interval.AllExclude || x == Interval.StartIncludeEndExclude => this.End.HasValue ? this.End.Value.AddSeconds(-1) : DateTime.MaxValue,
                    _ => this.End.Value
                };
            }
        }

        /// <summary>
        /// The start of the <see cref="DateTimeRange"/>.
        /// </summary>
        public DateTime? Start { get; private set; }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns>true if obj and this instance are the same type and represent the same value; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is DateTimeRange dtr)
            {
                return this.Start == dtr.Start && this.End == dtr.End && this.Interval == dtr.Interval;
            }

            return base.Equals(obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Converts the value of the current System.DateTimeRange object to its equivalent string representation using the formatting conventions of the current culture.
        /// </summary>
        /// <returns>A string representation of the value of the current System.DateTime object.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The date and time are outside the range of dates supported by the calendar used by the current culture.</exception>
        public override string ToString()
        {
            string result = String.Format("{0}, {1}", this.Start.HasValue ? this.Start.ToString() : " ", this.End.HasValue ? this.End.ToString() : String.Empty);
            return Interval switch
            {
                Interval.AllExclude => "]" + result + "[",
                Interval.StartIncludeEndExclude => "[" + result + "[",
                Interval.StartExcludeEndInclude => "]" + result + "]",
                _ => "[" + result + "]",
            };
        }

        /// <summary>
        /// Get the <see cref="DateTimeRange"/> which results of the intersection of the given <see cref="DateTimeRange"/> with the current instance.
        /// </summary>
        /// <param name="range">The <see cref="DateTimeRange"/> to compare width the current instance.</param>
        /// <returns>A <see cref="DateTimeRange"/> which results of the intersection of the given <see cref="DateTimeRange"/> with the current instance.</returns>
        public DateTimeRange? GetIntersection(DateTimeRange range)
        {
            this.TryGetIntersection(range, out Intersection intersectionType, out DateTimeRange? intersection);
            return intersection;
        }

        /// <summary>
        /// Determines the <see cref="Intersection"/> of the given <see cref="DateTimeRange"/> with the current instance.
        /// </summary>
        /// <param name="range">The <see cref="DateTimeRange"/> to compare with the current instance.</param>
        /// <returns>The <see cref="Intersection"/> type of the given <see cref="DateTimeRange"/> with the current instance.</returns>
        public Intersection GetIntersectionType(DateTimeRange range)
        {
            this.TryGetIntersection(range, out Intersection intersectionType, out DateTimeRange? intersection);
            return intersectionType;
        }

        /// <summary>
        /// Determines if the given <see cref="DateTimeRange"/> intersects this instance.
        /// </summary>
        /// <param name="range">The <see cref="DateTimeRange"/> to compare with the current instance.</param>
        /// <returns>true if the <paramref name="range"/> intersects the current instance; otherwise, false.</returns>
        public bool Intersects(DateTimeRange range)
        {
            return GetIntersectionType(range) != Intersection.None;
        }

        /// <summary>
        /// Determines if the given <see cref="DateTime"/> is in the current <see cref="DateTimeRange"/>.
        /// </summary>
        /// <param name="date">The <see cref="DateTime"/> to compare with the current <see cref="DateTimeRange"/>.</param>
        /// <returns>true if the <paramref name="date"/> is in the current <see cref="DateTimeRange"/>; otherwise, false.</returns>
        public bool IsInRange(DateTime date)
        {
            return this.Interval switch
            {
                Interval.AllExclude => (!this.Start.HasValue || date > this.Start.Value) && (!this.End.HasValue || date < this.End.Value),
                Interval.StartIncludeEndExclude => date >= this.Start.Value && (!this.End.HasValue || date < this.End.Value),
                Interval.StartExcludeEndInclude => (!this.Start.HasValue || date > this.Start.Value) && date <= this.End.Value,
                _ => date >= this.Start.Value && date <= this.End.Value
            };
        }

        /// <summary>
        /// Tries the get intersection.
        /// </summary>
        /// <param name="range">The range to work with.</param>
        /// <param name="intersectionType">Type of the intersection.</param>
        /// <param name="intersection">The intersection.</param>
        /// <returns>True if a intersection exists, otherwise, false.</returns>
        public bool TryGetIntersection(DateTimeRange range, out Intersection intersectionType, out DateTimeRange? intersection)
        {
            intersectionType = Intersection.None;
            intersection = null;
            if (this.Start == range.Start && this.End == range.End && this.Interval == range.Interval) // this tart, end and interval are equal to range start, end and interval.
            {
                intersectionType = Intersection.Equals;
                intersection = this;
            }
            else // this tart, end and interval are not equal to range start, end and interval.
            {
                if (!this.Start.HasValue && this.End.HasValue) // this has no and has end.
                {
                    if (!range.Start.HasValue && range.End.HasValue) // range has no start and has end.
                    {
                        if (this.IsInRange(range.LastDate)) // range last date is between this start and end.
                        {
                            intersectionType = Intersection.Contains;
                            intersection = new DateTimeRange(null, range.LastDate);
                        }
                        else // range last date is not between this start and end.
                        {
                            intersectionType = Intersection.IsContained;
                            intersection = new DateTimeRange(null, this.LastDate);
                        }
                    }
                    else if (range.Start.HasValue && !range.End.HasValue && this.IsInRange(range.FirstDate))  // range has no start, has end and range first date is between this start and end.
                    {
                        intersectionType = Intersection.PartiallyContains;
                        intersection = new DateTimeRange(range.FirstDate, this.LastDate);
                    }
                    else // range has start and end.
                    {
                        var rs = this.IsInRange(range.FirstDate);
                        var re = this.IsInRange(range.LastDate);
                        if (rs && re) // range first date is between this start and end, and range last date is between this start and end.
                        {
                            intersectionType = Intersection.Contains;
                            intersection = new DateTimeRange(range.FirstDate, range.LastDate);
                        }
                        else if (rs && !re) // range first date is between this start and end, and range last date is not between this start and end.
                        {
                            intersectionType = Intersection.PartiallyContains;
                            intersection = new DateTimeRange(range.FirstDate, this.LastDate);
                        }
                    }
                }
                else if (this.Start.HasValue && !this.End.HasValue) // this has start and no end.
                {
                    if (!range.Start.HasValue && range.End.HasValue && this.IsInRange(range.LastDate)) // range has no start, has end and range last date is between this start and end.
                    {
                        intersectionType = Intersection.PartiallyContains;
                        intersection = new DateTimeRange(this.FirstDate, range.LastDate);
                    }
                    else if (range.Start.HasValue && !range.End.HasValue)// range has start and no end.
                    {
                        if (this.IsInRange(range.FirstDate)) // range first date is between this start and end.
                        {
                            intersectionType = Intersection.Contains;
                            intersection = new DateTimeRange(range.FirstDate, null);
                        }
                        else // range first date is not between this start and end.
                        {
                            intersectionType = Intersection.IsContained;
                            intersection = new DateTimeRange(this.FirstDate, null);
                        }
                    }
                    else // range has start and end.
                    {
                        var rs = this.IsInRange(range.FirstDate);
                        var re = this.IsInRange(range.LastDate);
                        if (rs && re) // range first start is between this start and end, and range last date is between this start and end.
                        {
                            intersectionType = Intersection.Contains;
                            intersection = new DateTimeRange(range.FirstDate, range.LastDate);
                        }
                        else if (!rs && re)  // range first date is not between this start and end, and range last date is between this start and end.
                        {
                            intersectionType = Intersection.PartiallyContains;
                            intersection = new DateTimeRange(this.FirstDate, range.LastDate);
                        }
                    }
                }
                else // this have Start & End.
                {
                    if (!range.Start.HasValue && range.End.HasValue) // range has no Start and have End.
                    {
                        if (this.IsInRange(range.LastDate)) // range last date is between this Start and End.
                        {
                            intersectionType = Intersection.PartiallyContains;
                            intersection = new DateTimeRange(this.FirstDate, range.LastDate);
                        }
                        else if (range.IsInRange(this.LastDate)) // range last date is not between this Start and End, and this last date is between range Start and End.
                        {
                            intersectionType = Intersection.IsContained;
                            intersection = new DateTimeRange(this.FirstDate, this.LastDate);
                        }

                    }
                    else if (range.Start.HasValue && !range.End.HasValue)   // range has Start and no End.
                    {
                        if (this.IsInRange(range.FirstDate)) // range first date is between this Start and End.
                        {
                            intersectionType = Intersection.PartiallyContains;
                            intersection = new DateTimeRange(range.FirstDate, this.LastDate);
                        }
                        else if (range.IsInRange(this.FirstDate)) // range first date is not between this Start and End, and this Start is between range Start and End.
                        {
                            intersectionType = Intersection.IsContained;
                            intersection = new DateTimeRange(this.FirstDate, this.LastDate);
                        }
                    }
                    else // range has Start and End.
                    {
                        var dtrs = range.IsInRange(this.FirstDate);
                        var dtre = range.IsInRange(this.LastDate);
                        var rs = this.IsInRange(range.FirstDate);
                        var re = this.IsInRange(range.LastDate);
                        if (rs && re) // range Start and End is between this Start and End.
                        {
                            intersectionType = Intersection.Contains;
                            intersection = new DateTimeRange(range.FirstDate, range.LastDate);
                        }
                        else if ((!rs && re) || (rs && !re)) // range Start is not between this Start and End, range End is between this Start and End, or range Start is between this Start and End, range End is not between this Start and End.
                        {
                            intersectionType = Intersection.PartiallyContains;
                            intersection = new DateTimeRange(!rs && re ? this.FirstDate : range.FirstDate, rs && !re ? this.LastDate : range.LastDate);
                        }
                        else if (dtrs && dtre) // this Start and End is between range Start and End.
                        {
                            intersectionType = Intersection.IsContained;
                            intersection = new DateTimeRange(this.FirstDate, this.LastDate);
                        }
                    }
                }
            }

            return intersectionType != Intersection.None;
        }
    }
}
