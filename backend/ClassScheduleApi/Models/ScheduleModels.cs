namespace ClassScheduleApi.Models;


public record ScheduleItem(string id, string title, DateTime startDate, DateTime endDate);