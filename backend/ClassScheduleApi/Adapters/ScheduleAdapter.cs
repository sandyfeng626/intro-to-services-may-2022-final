using System.Text.Json;

namespace ClassScheduleApi.Adapters;

public class ScheduleAdapter
{
    private readonly Dictionary<string, List<ScheduleItem>> _items = new Dictionary<string, List<ScheduleItem>>();
    public ScheduleAdapter()
    {
        var file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Schedule", "schedule.json");
        using (var sr = new StreamReader(file))
        {
            string json = sr.ReadToEnd();
            var items = JsonSerializer.Deserialize<List<StoreScheduleItem>>(json);
            foreach (var item in items!)
            {
                if (!_items.ContainsKey(item.id))
                {
                    _items.Add(item.id, new List<ScheduleItem>());

                }
                var newItem = new ScheduleItem(DateTime.Parse(item.StartDate), DateTime.Parse(item.EndDate));
                _items[item.id].Add(newItem);

            }
        }
    }

    public Dictionary<string, List<ScheduleItem>> GetSchedule()
    {
        return _items;
    }
    public List<ScheduleItem>? GetForClass(string id)
    {
        return _items[id];
    }
}



public class StoreScheduleItem
{
    public string id { get; set; } = string.Empty;
    public string title { get; set; } = string.Empty;
    public string StartDate { get; set; } = String.Empty;
    public string EndDate { get; set; } = String.Empty;
}


public record ScheduleItem(DateTime startDate, DateTime endDate);