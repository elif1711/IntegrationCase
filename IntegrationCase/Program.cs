using IntegrationCase.Service;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var itemService = new SingleItemService();
        var tasks = new List<Task<string>>
        {
            itemService.AddItemAsync("a"),
            itemService.AddItemAsync("b"),
            itemService.AddItemAsync("c"),
            itemService.AddItemAsync("b")
        };

        var results = await Task.WhenAll(tasks);

        foreach (var result in results)
        {
            Console.WriteLine(result);
        }
    }
}