using System;

namespace PeriodsSum.Model {
    public class TimeEvent {
        public string Id { get; set; }
        public TimeSpan Time { get; set; }
        public TimeEventType Type { get; set; }
    }

}
