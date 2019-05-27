using System;
using System.Collections.Generic;
using System.Text;

namespace DeLivre.Models
{
    public struct LojaInfo
    {
        public String store;
        public TimeZoneInfo tz;
        public TimeSpan open;
        public TimeSpan close;

        public bool IsOpenNow()
        {
            return IsOpenAt(DateTime.Now.TimeOfDay);
        }

        public bool IsOpenAt(TimeSpan time)
        {
            TimeZoneInfo local = TimeZoneInfo.Local;
            TimeSpan offset = TimeZoneInfo.Local.BaseUtcOffset;

            // Is the store in the same time zone?
           
                TimeSpan delta = TimeSpan.Zero;
                TimeSpan storeDelta = TimeSpan.Zero;

                // Is it daylight saving time in either time zone?
                if (local.IsDaylightSavingTime(DateTime.Now.Date + time))
                    delta = local.GetAdjustmentRules()[local.GetAdjustmentRules().Length - 1].DaylightDelta;

                //if (tz.IsDaylightSavingTime(DateTime.Now.Date + time, local, tz))
                //    storeDelta = tz.GetAdjustmentRules()[local.GetAdjustmentRules().Length - 1].DaylightDelta;

                TimeSpan comparisonTime = time + (offset - tz.BaseUtcOffset).Negate() + (delta - storeDelta).Negate();
                return comparisonTime >= open & comparisonTime <= close;            
        }
    }
}