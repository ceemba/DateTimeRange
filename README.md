# DateTimeRange
An .NET object to work with the date time ranges.

public string ToString():
        DTR1: [01/01/2019 00:00:00, 31/01/2019 23:59:59], duration: 2678399 second(s)
        DTR2: ]01/01/2019 00:00:00, 31/01/2019 23:59:59[, duration: 2678397 second(s)
        DTR3: [01/01/2019 00:00:00, 31/01/2019 23:59:59[, duration: 2678398 second(s)
        DTR4: ]01/01/2019 00:00:00, 31/01/2019 23:59:59], duration: 2678398 second(s)
        DTR5: [01/01/2019 00:00:00, [, duration: Infinite
        DTR6: ]01/01/2019 00:00:00, [, duration: Infinite
        DTR7: ] , 31/01/2019 23:59:59], duration: Infinite
        DTR8: ] , 31/01/2019 23:59:59[, duration: Infinite
        DTR9: [01/01/2018 00:00:00, 31/12/2018 23:59:59], duration: 31535999 second(s)
        DTR10: [01/02/2018 00:00:00, 28/02/2019 23:59:59], duration: 33955199 second(s)
        DTR11: ] , 31/12/2018 23:59:59], duration: Infinite
        DTR12: [01/02/2018 00:00:00, [, duration: Infinite

First date in the range DTR1 is 01/01/2019 00:00:00, the last is 31/01/2019 23:59:59.
First date in the range DTR2 is 01/01/2019 00:00:01, the last is 31/01/2019 23:59:58.
First date in the range DTR3 is 01/01/2019 00:00:00, the last is 31/01/2019 23:59:58.
First date in the range DTR4 is 01/01/2019 00:00:01, the last is 31/01/2019 23:59:59.
First date in the range DTR5 is 01/01/2019 00:00:00, the last is 31/12/9999 23:59:59.
First date in the range DTR6 is 01/01/2019 00:00:01, the last is 31/12/9999 23:59:59.
First date in the range DTR7 is 01/01/0001 00:00:00, the last is 31/01/2019 23:59:59.
First date in the range DTR8 is 01/01/0001 00:00:00, the last is 31/01/2019 23:59:58.
First date in the range DTR9 is 01/01/2018 00:00:00, the last is 31/12/2018 23:59:59.
First date in the range DTR10 is 01/02/2018 00:00:00, the last is 28/02/2019 23:59:59.
First date in the range DTR11 is 01/01/0001 00:00:00, the last is 31/12/2018 23:59:59.
First date in the range DTR12 is 01/02/2018 00:00:00, the last is 31/12/9999 23:59:59.

public bool IsInRange(DateTime date):
31/12/2018 23:59:59:
        is in DTR1: False
        is in DTR2: False
        is in DTR3: False
        is in DTR4: False
        is in DTR5: False
        is in DTR6: False
        is in DTR7: True
        is in DTR8: True
        is in DTR9: True
        is in DTR10: True
        is in DTR11: True
        is in DTR12: True
15/01/2019 23:59:59:
        is in DTR1: True
        is in DTR2: True
        is in DTR3: True
        is in DTR4: True
        is in DTR5: True
        is in DTR6: True
        is in DTR7: True
        is in DTR8: True
        is in DTR9: False
        is in DTR10: True
        is in DTR11: False
        is in DTR12: True
01/02/2019 00:00:00:
        is in DTR1: False
        is in DTR2: False
        is in DTR3: False
        is in DTR4: False
        is in DTR5: True
        is in DTR6: True
        is in DTR7: False
        is in DTR8: False
        is in DTR9: False
        is in DTR10: True
        is in DTR11: False
        is in DTR12: True
01/01/2019 00:00:00:
        is in DTR1: True
        is in DTR2: False
        is in DTR3: True
        is in DTR4: False
        is in DTR5: True
        is in DTR6: False
        is in DTR7: True
        is in DTR8: True
        is in DTR9: False
        is in DTR10: True
        is in DTR11: False
        is in DTR12: True
31/01/2019 23:59:59:
        is in DTR1: True
        is in DTR2: False
        is in DTR3: False
        is in DTR4: True
        is in DTR5: True
        is in DTR6: True
        is in DTR7: True
        is in DTR8: False
        is in DTR9: False
        is in DTR10: True
        is in DTR11: False
        is in DTR12: True

public Intersection GetIntersectionType(DateTimeRange range):
DTR1 Equals DTR1: [01/01/2019 00:00:00, 31/01/2019 23:59:59]
DTR2 IsContained DTR1: [01/01/2019 00:00:01, 31/01/2019 23:59:58]
DTR3 PartiallyContains DTR1: [01/01/2019 00:00:00, 31/01/2019 23:59:58]
DTR4 PartiallyContains DTR1: [01/01/2019 00:00:01, 31/01/2019 23:59:59]
DTR5 Contains DTR1: [01/01/2019 00:00:00, 31/01/2019 23:59:59]
DTR6 PartiallyContains DTR1: [01/01/2019 00:00:01, 31/01/2019 23:59:59]
DTR7 Contains DTR1: [01/01/2019 00:00:00, 31/01/2019 23:59:59]
DTR8 PartiallyContains DTR1: [01/01/2019 00:00:00, 31/01/2019 23:59:58]
DTR9 None DTR1:
DTR10 Contains DTR1: [01/01/2019 00:00:00, 31/01/2019 23:59:59]
DTR11 None DTR1:
DTR12 Contains DTR1: [01/01/2019 00:00:00, 31/01/2019 23:59:59]

DTR1 Contains DTR2: [01/01/2019 00:00:01, 31/01/2019 23:59:58]
DTR2 Equals DTR2: ]01/01/2019 00:00:00, 31/01/2019 23:59:59[
DTR3 Contains DTR2: [01/01/2019 00:00:01, 31/01/2019 23:59:58]
DTR4 Contains DTR2: [01/01/2019 00:00:01, 31/01/2019 23:59:58]
DTR5 Contains DTR2: [01/01/2019 00:00:01, 31/01/2019 23:59:58]
DTR6 Contains DTR2: [01/01/2019 00:00:01, 31/01/2019 23:59:58]
DTR7 Contains DTR2: [01/01/2019 00:00:01, 31/01/2019 23:59:58]
DTR8 Contains DTR2: [01/01/2019 00:00:01, 31/01/2019 23:59:58]
DTR9 None DTR2:
DTR10 Contains DTR2: [01/01/2019 00:00:01, 31/01/2019 23:59:58]
DTR11 None DTR2:
DTR12 Contains DTR2: [01/01/2019 00:00:01, 31/01/2019 23:59:58]

DTR1 Contains DTR3: [01/01/2019 00:00:00, 31/01/2019 23:59:58]
DTR2 PartiallyContains DTR3: [01/01/2019 00:00:01, 31/01/2019 23:59:58]
DTR3 Equals DTR3: [01/01/2019 00:00:00, 31/01/2019 23:59:59[
DTR4 PartiallyContains DTR3: [01/01/2019 00:00:01, 31/01/2019 23:59:58]
DTR5 Contains DTR3: [01/01/2019 00:00:00, 31/01/2019 23:59:58]
DTR6 PartiallyContains DTR3: [01/01/2019 00:00:01, 31/01/2019 23:59:58]
DTR7 Contains DTR3: [01/01/2019 00:00:00, 31/01/2019 23:59:58]
DTR8 Contains DTR3: [01/01/2019 00:00:00, 31/01/2019 23:59:58]
DTR9 None DTR3:
DTR10 Contains DTR3: [01/01/2019 00:00:00, 31/01/2019 23:59:58]
DTR11 None DTR3:
DTR12 Contains DTR3: [01/01/2019 00:00:00, 31/01/2019 23:59:58]

DTR1 Contains DTR4: [01/01/2019 00:00:01, 31/01/2019 23:59:59]
DTR2 PartiallyContains DTR4: [01/01/2019 00:00:01, 31/01/2019 23:59:58]
DTR3 PartiallyContains DTR4: [01/01/2019 00:00:01, 31/01/2019 23:59:58]
DTR4 Equals DTR4: ]01/01/2019 00:00:00, 31/01/2019 23:59:59]
DTR5 Contains DTR4: [01/01/2019 00:00:01, 31/01/2019 23:59:59]
DTR6 Contains DTR4: [01/01/2019 00:00:01, 31/01/2019 23:59:59]
DTR7 Contains DTR4: [01/01/2019 00:00:01, 31/01/2019 23:59:59]
DTR8 PartiallyContains DTR4: [01/01/2019 00:00:01, 31/01/2019 23:59:58]
DTR9 None DTR4:
DTR10 Contains DTR4: [01/01/2019 00:00:01, 31/01/2019 23:59:59]
DTR11 None DTR4:
DTR12 Contains DTR4: [01/01/2019 00:00:01, 31/01/2019 23:59:59]

DTR1 PartiallyContains DTR5: [01/01/2019 00:00:00, 31/01/2019 23:59:59]
DTR2 IsContained DTR5: [01/01/2019 00:00:01, 31/01/2019 23:59:58]
DTR3 PartiallyContains DTR5: [01/01/2019 00:00:00, 31/01/2019 23:59:58]
DTR4 IsContained DTR5: [01/01/2019 00:00:01, 31/01/2019 23:59:59]
DTR5 Equals DTR5: [01/01/2019 00:00:00, [
DTR6 IsContained DTR5: [01/01/2019 00:00:01, [
DTR7 PartiallyContains DTR5: [01/01/2019 00:00:00, 31/01/2019 23:59:59]
DTR8 PartiallyContains DTR5: [01/01/2019 00:00:00, 31/01/2019 23:59:58]
DTR9 None DTR5:
DTR10 PartiallyContains DTR5: [01/01/2019 00:00:00, 28/02/2019 23:59:59]
DTR11 None DTR5:
DTR12 Contains DTR5: [01/01/2019 00:00:00, [

DTR1 PartiallyContains DTR6: [01/01/2019 00:00:01, 31/01/2019 23:59:59]
DTR2 PartiallyContains DTR6: [01/01/2019 00:00:01, 31/01/2019 23:59:58]
DTR3 PartiallyContains DTR6: [01/01/2019 00:00:01, 31/01/2019 23:59:58]
DTR4 PartiallyContains DTR6: [01/01/2019 00:00:01, 31/01/2019 23:59:59]
DTR5 Contains DTR6: [01/01/2019 00:00:01, [
DTR6 Equals DTR6: ]01/01/2019 00:00:00, [
DTR7 PartiallyContains DTR6: [01/01/2019 00:00:01, 31/01/2019 23:59:59]
DTR8 PartiallyContains DTR6: [01/01/2019 00:00:01, 31/01/2019 23:59:58]
DTR9 None DTR6:
DTR10 PartiallyContains DTR6: [01/01/2019 00:00:01, 28/02/2019 23:59:59]
DTR11 None DTR6:
DTR12 Contains DTR6: [01/01/2019 00:00:01, [

DTR1 PartiallyContains DTR7: [01/01/2019 00:00:00, 31/01/2019 23:59:59]
DTR2 IsContained DTR7: [01/01/2019 00:00:01, 31/01/2019 23:59:58]
DTR3 IsContained DTR7: [01/01/2019 00:00:00, 31/01/2019 23:59:58]
DTR4 PartiallyContains DTR7: [01/01/2019 00:00:01, 31/01/2019 23:59:59]
DTR5 PartiallyContains DTR7: [01/01/2019 00:00:00, 31/01/2019 23:59:59]
DTR6 PartiallyContains DTR7: [01/01/2019 00:00:01, 31/01/2019 23:59:59]
DTR7 Equals DTR7: ] , 31/01/2019 23:59:59]
DTR8 IsContained DTR7: ] , 31/01/2019 23:59:58]
DTR9 IsContained DTR7: [01/01/2018 00:00:00, 31/12/2018 23:59:59]
DTR10 PartiallyContains DTR7: [01/02/2018 00:00:00, 31/01/2019 23:59:59]
DTR11 IsContained DTR7: ] , 31/12/2018 23:59:59]
DTR12 PartiallyContains DTR7: [01/02/2018 00:00:00, 31/01/2019 23:59:59]

DTR1 PartiallyContains DTR8: [01/01/2019 00:00:00, 31/01/2019 23:59:58]
DTR2 PartiallyContains DTR8: [01/01/2019 00:00:01, 31/01/2019 23:59:58]
DTR3 PartiallyContains DTR8: [01/01/2019 00:00:00, 31/01/2019 23:59:58]
DTR4 PartiallyContains DTR8: [01/01/2019 00:00:01, 31/01/2019 23:59:58]
DTR5 PartiallyContains DTR8: [01/01/2019 00:00:00, 31/01/2019 23:59:58]
DTR6 PartiallyContains DTR8: [01/01/2019 00:00:01, 31/01/2019 23:59:58]
DTR7 Contains DTR8: ] , 31/01/2019 23:59:58]
DTR8 Equals DTR8: ] , 31/01/2019 23:59:59[
DTR9 IsContained DTR8: [01/01/2018 00:00:00, 31/12/2018 23:59:59]
DTR10 PartiallyContains DTR8: [01/02/2018 00:00:00, 31/01/2019 23:59:58]
DTR11 IsContained DTR8: ] , 31/12/2018 23:59:59]
DTR12 PartiallyContains DTR8: [01/02/2018 00:00:00, 31/01/2019 23:59:58]

DTR1 None DTR9:
DTR2 None DTR9:
DTR3 None DTR9:
DTR4 None DTR9:
DTR5 None DTR9:
DTR6 None DTR9:
DTR7 Contains DTR9: [01/01/2018 00:00:00, 31/12/2018 23:59:59]
DTR8 Contains DTR9: [01/01/2018 00:00:00, 31/12/2018 23:59:59]
DTR9 Equals DTR9: [01/01/2018 00:00:00, 31/12/2018 23:59:59]
DTR10 PartiallyContains DTR9: [01/02/2018 00:00:00, 31/12/2018 23:59:59]
DTR11 Contains DTR9: [01/01/2018 00:00:00, 31/12/2018 23:59:59]
DTR12 PartiallyContains DTR9: [01/02/2018 00:00:00, 31/12/2018 23:59:59]

DTR1 IsContained DTR10: [01/01/2019 00:00:00, 31/01/2019 23:59:59]
DTR2 IsContained DTR10: [01/01/2019 00:00:01, 31/01/2019 23:59:58]
DTR3 IsContained DTR10: [01/01/2019 00:00:00, 31/01/2019 23:59:58]
DTR4 IsContained DTR10: [01/01/2019 00:00:01, 31/01/2019 23:59:59]
DTR5 PartiallyContains DTR10: [01/01/2019 00:00:00, 28/02/2019 23:59:59]
DTR6 PartiallyContains DTR10: [01/01/2019 00:00:01, 28/02/2019 23:59:59]
DTR7 PartiallyContains DTR10: [01/02/2018 00:00:00, 31/01/2019 23:59:59]
DTR8 PartiallyContains DTR10: [01/02/2018 00:00:00, 31/01/2019 23:59:58]
DTR9 PartiallyContains DTR10: [01/02/2018 00:00:00, 31/12/2018 23:59:59]
DTR10 Equals DTR10: [01/02/2018 00:00:00, 28/02/2019 23:59:59]
DTR11 PartiallyContains DTR10: [01/02/2018 00:00:00, 31/12/2018 23:59:59]
DTR12 Contains DTR10: [01/02/2018 00:00:00, 28/02/2019 23:59:59]

DTR1 None DTR11:
DTR2 None DTR11:
DTR3 None DTR11:
DTR4 None DTR11:
DTR5 None DTR11:
DTR6 None DTR11:
DTR7 Contains DTR11: ] , 31/12/2018 23:59:59]
DTR8 Contains DTR11: ] , 31/12/2018 23:59:59]
DTR9 PartiallyContains DTR11: [01/01/2018 00:00:00, 31/12/2018 23:59:59]
DTR10 PartiallyContains DTR11: [01/02/2018 00:00:00, 31/12/2018 23:59:59]
DTR11 Equals DTR11: ] , 31/12/2018 23:59:59]
DTR12 PartiallyContains DTR11: [01/02/2018 00:00:00, 31/12/2018 23:59:59]

DTR1 IsContained DTR12: [01/01/2019 00:00:00, 31/01/2019 23:59:59]
DTR2 IsContained DTR12: [01/01/2019 00:00:01, 31/01/2019 23:59:58]
DTR3 IsContained DTR12: [01/01/2019 00:00:00, 31/01/2019 23:59:58]
DTR4 IsContained DTR12: [01/01/2019 00:00:01, 31/01/2019 23:59:59]
DTR5 IsContained DTR12: [01/01/2019 00:00:00, [
DTR6 IsContained DTR12: [01/01/2019 00:00:01, [
DTR7 PartiallyContains DTR12: [01/02/2018 00:00:00, 31/01/2019 23:59:59]
DTR8 PartiallyContains DTR12: [01/02/2018 00:00:00, 31/01/2019 23:59:58]
DTR9 PartiallyContains DTR12: [01/02/2018 00:00:00, 31/12/2018 23:59:59]
DTR10 PartiallyContains DTR12: [01/02/2018 00:00:00, 28/02/2019 23:59:59]
DTR11 PartiallyContains DTR12: [01/02/2018 00:00:00, 31/12/2018 23:59:59]
DTR12 Equals DTR12: [01/02/2018 00:00:00, [
