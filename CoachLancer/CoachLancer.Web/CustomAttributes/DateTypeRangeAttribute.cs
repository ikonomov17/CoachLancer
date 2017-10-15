using System;
using System.ComponentModel.DataAnnotations;

namespace CoachLancer.Web.CustomAttributes
{
    public class DateTypeRangeAttribute : RangeAttribute
    {
        public DateTypeRangeAttribute()
            : base(typeof(DateTime),
                DateTime.Now.AddYears(-100).ToShortDateString(),
                DateTime.Now.ToShortDateString())
        {
            
        }
    }
}
