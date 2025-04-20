namespace ClassLibrary.MsBackend.Basics;

/// <summary>
/// You will create a basic task manager program that stores and displays 
// up to three tasks using individual string variables. The tasks can be marked 
// as completed using Boolean flags, and the program will display which tasks 
// are completed or still pending.
/// </summary>
public static class Practice6
{
    public static void Program()
    {
        var taskList = new List<string>();
        var taskStatusList = new List<bool>();
        while (true)
        {
            var action = GetInput<int>("Enter action [1 - Add, 2 - Complete, 3 - List]:");
            switch (action)
            {
                case 1: AddTask(taskList, taskStatusList); break;
                case 2: CompleteTask(taskStatusList); break;
                case 3: DisplayTasksStatus(taskList, taskStatusList); break;
                default: {
                    Console.WriteLine("Exit application.");
                    return;
                };
            }

        }
    }

    public static void AddTask(List<string> tasks, List<bool> taskStatuses)
    {
        if (tasks.Count == 3)
        {
            Console.WriteLine("Max 3 tasks can be created.");
        }
        else 
        {
            var task = GetInput<string>("Enter task name:");
            tasks.Add(task);
            taskStatuses.Add(false);
        }
    }

    public static void CompleteTask(List<bool> taskStatuses)
    {
        var taskId = GetInput<int>("Enter task ID to complete:");
        if (taskId >= 0 && taskId < taskStatuses.Count)
        {
            taskStatuses[taskId] = true;
        }
    }

    public static void DisplayTasksStatus(List<string> tasks, List<bool> taskStatuses)
    {
        for (var i=0; i < tasks.Count; i++)
        {
            var status = $"Task {i} '{tasks[i]}': ";
            if (taskStatuses[i]) status += "Complete";
            else status += "Pending";
            Console.WriteLine(status);
        }
    }

    public static T GetInput<T>(string message)
    {
        Console.WriteLine(message);
        var input = Console.ReadLine();
        if (typeof(T).Name.ToLower().Equals("string")) return (T)(input as object);
        return (T)Convert.ChangeType(input, typeof(T));
    }
}