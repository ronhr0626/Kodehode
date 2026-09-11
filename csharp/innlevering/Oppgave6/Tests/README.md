# Tests — Repository<T> (Oppgave 6)

Unit tests (xUnit) for the generic `Repository<T>` class from the TrollMix
catalog project.

## Note: extending the program

The original program (Oppgave 5) only had Add, Get, GetAll and Count. To
complete this test assignment we extended `Repository<T>` with two extra
methods, **Remove** and **Clear**, because the assignment asks us to verify that
Count changes correctly on Add, Remove and Clear. You cannot test a method that
does not exist, so these two methods were added to the main program first, and
are tested here.

The tests follow the Arrange–Act–Assert pattern and each test uses its own
small, controlled data so it can run independently of the others.

## How to run

From the `Oppgave6` folder:

    dotnet test Tests

## What is tested

**A. Basic functionality**
- `Add_IncreasesCount_And_ItemIsRetrievable` — adding an item raises Count and the item can be read back with Get.
- `Remove_RemovesTheItalianSong_And_DecreasesCount` — removing one specific song (the Italian one) lowers Count and leaves the other song in place.
- `Clear_EmptiesTheRepository` — Clear removes all items so Count becomes 0.

**B. Generic contract (works for several types)**
- `Repository_WorksWithStrings_NotJustSongs` — the same generic class works with `string`, not only `Song`, which is the whole point of using generics.

**C. Edge case / error handling**
- `Get_WithInvalidIndex_ThrowsException` — asking for an index that does not exist throws `ArgumentOutOfRangeException` (verified with `Assert.Throws`).

## Reflection

**Why these tests?**
The class has six operations (Add, Get, GetAll, Count, Remove, Clear), so the tests cover the state-changing ones — Add, Remove and Clear — plus retrieval and one error case. That is the core behaviour: if these work, the repository does what it promises. I also added a test with `string` to prove the class is truly generic and not tied to `Song`.

**Do I feel I covered all the basic functionality?**
Yes, for the current class. Add, Remove, Clear and Get are all tested, both on the happy path and with one out-of-range case.

**Could another developer understand how to use the class from the tests?**
I think so. Each test name says what it does and what the expected result is (`MethodName_Condition_ExpectedResult`), and the Arrange–Act–Assert layout shows exactly how to create the repository, call a method, and what to expect back.