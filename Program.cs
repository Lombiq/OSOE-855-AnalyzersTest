var list = new List<string>
{
    "one",
    "two",
    "three"
};

var array = list.ToArray();

foreach (var item in array)
{
    Console.WriteLine(item);
}