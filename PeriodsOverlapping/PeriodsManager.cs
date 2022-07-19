using PeriodsSum.Model;
using System;
using System.Collections.Generic;

namespace Periods {
   

    public class PeriodsManager {

        private void Process(List<Period> periods) {
            var outputPeriods = ProcessInputs(periods);

            Console.WriteLine("Input");
            PrintPeriods(periods);
            Console.WriteLine("Output");
            PrintPeriods(outputPeriods);
            Console.WriteLine("-------------------------------");

        }


        private void PrintPeriods(List<Period> periods) {
            foreach (var period in periods) {
                Console.WriteLine($"{period.Id} : {period.Start} -> {period.End}");
            }
        }

        private List<TimeEvent> GetTimeEvents(List<Period> periodList) {
            var timeEvents = new List<TimeEvent>();
            foreach (var period in periodList) {
                timeEvents.Add(new TimeEvent { Id = period.Id, Time = period.Start, Type = TimeEventType.START });
                timeEvents.Add(new TimeEvent { Id = period.Id, Time = period.End, Type = TimeEventType.END });
            }
            timeEvents.Sort((x, y) => x.Time.CompareTo(y.Time));
            return timeEvents;
        }

        private string ComposeIds(List<string> ids) {
            return string.Join("", ids);
        }

        public List<Period> ProcessInputs(List<Period> input) {

            var events = GetTimeEvents(input);

            var output = new List<Period>();
            var currentIds = new List<string>();
            TimeSpan? startTime = null;
            TimeSpan? endTime = null;

            foreach (var timeEvent in events) {

                if (timeEvent.Type == TimeEventType.START) {

                    if (startTime != null) {
                        if (startTime.Value != timeEvent.Time) {
                            endTime = timeEvent.Time;
                            var newId = ComposeIds(currentIds);
                            var newPeriod = new Period(newId, startTime.Value, endTime.Value);
                            output.Add(newPeriod);
                        }
                        startTime = null;
                        endTime = null;
                    }

                    currentIds.Add(timeEvent.Id);
                    startTime = timeEvent.Time;
                }

                if (timeEvent.Type == TimeEventType.END) {

                    if (startTime != null) {
                        if (startTime.Value != timeEvent.Time) {
                            endTime = timeEvent.Time;
                            var newId = ComposeIds(currentIds);
                            var newPeriod = new Period(newId, startTime.Value, endTime.Value);
                            output.Add(newPeriod);
                        }
                        startTime = null;
                        endTime = null;
                    }

                    currentIds.Remove(timeEvent.Id);

                    if (currentIds.Count > 0) {
                        startTime = timeEvent.Time;
                    }
                }

            }

            for (int i = 0; i < output.Count - 1; i++) {
                if (output[i].End == output[i + 1].Start) {
                    output[i].End = output[i].End.Subtract(TimeSpan.FromMinutes(1));
                }
            }

            return output;
        }
    }
}
