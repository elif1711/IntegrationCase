using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationCase.Service
{
    public class SingleItemService
    {
        private static ConcurrentDictionary<string, bool> items = new ConcurrentDictionary<string, bool>();

        public async Task<string> AddItemAsync(string itemContent)
        {
            await Task.Delay(2000);

            if (items.ContainsKey(itemContent))
            {
                return "Duplicate item.";
            }

            items.TryAdd(itemContent, true);

            return $"{items.Count} items added.";
        }
    }
}
