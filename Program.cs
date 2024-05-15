List<string> list =
[
    "one",
    "two",
    "three",
];

string[] array = list.ToArray();

foreach (string item in array)
{
    Console.WriteLine(item);
}