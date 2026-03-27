#!/usr/bin/env dotnet run

Test([], "");
Test([5, 3, 17, 8], "3,5,8,17");
Test([1, 3, 3, 3, 5, 7, 3, 3, 5], "1,3,5,7");
Test([10, 21, 4, 8, 3, 22, 5, 7, 13, 6, 20, 1], "1,3-8,10,13,20-22");

static void Test(int[] numbers, string expected)
{
    var result = SortAndGroup(numbers);

    Console.WriteLine("Input:    [{0}]", string.Join(",", numbers));
    Console.WriteLine("Output:   {0}", result);
    Console.WriteLine("Expected: {0}", expected);
    Console.WriteLine("Result:   {0}", result == expected ? "Success" : "Failure");
    Console.WriteLine();
}

static string SortAndGroup(int[] numbers)
{
    var ordered = numbers.Order().Distinct().ToList();
    var result = new List<string>();

    for (var i = 0; i < ordered.Count; i++)
    {
        var start = ordered[i];

        while (i < ordered.Count - 1 && ordered[i + 1] == ordered[i] + 1)
            i++;

        result.Add(start == ordered[i] ? start.ToString() : $"{start}-{ordered[i]}");
    }

    return string.Join(",", result);
}