# overlapping-periods-kata-dotnet

## Problem description 

Given a set of N periods, calculate the sum of these periods, taking into account the following:

- A period is identified by a unique id, and has a start time (greater than or equal to 00:00) and an end time (less than or equal to 23:59).

- We will assume that the start time will always be less than the end time.

- The sum of 2 periods is calculated as follows: the overlapping periods are combined into a new one, as follows are combined into a new one, so that the final result is another set of non-overlapping periods.



## Example
In the following example the sum of Period 1 and Period 2 results in three periods:

Input: 
  - Period 1 [id=A, ini=03:00, fin=08:00]
  - Period 2 [id=B, ini=06:00, fin=09:00]

Output:
  - [id=A, ini=03:00, fin=05:59]
  - [id=AB, ini=06:00, fin=07:59]
  - [id=B, ini=08:00, fin=09:00]

