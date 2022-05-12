namespace ClassScheduleApi.Models;

public record ClassInstanceModel(DateTime startDate, DateTime endDate, int numberOfDays);

public record ClassListModel(Dictionary<string, List<ClassInstanceModel>> data);