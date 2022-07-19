using System;

namespace PeriodsSum.Model {
    public class Period {
        public Period(string id, TimeSpan start, TimeSpan end) {
            Id = id;
            Start = start;
            End = end;
        }

        public string Id { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }

        public override bool Equals(Object obj) {
            if ((obj == null) || !this.GetType().Equals(obj.GetType())) {
                return false;
            } else {
                Period p = (Period)obj;
                return (this.Id == p.Id) && (this.Start == p.Start) && (this.End == p.End);
            }
        }

    }
}
