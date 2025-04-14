public class Module2_1
{
    public class ToDoList
    {
        private string[] _tasks = new string[3];
        private int _taskCount = 0;

        public void AddTask()
        {
            Console.WriteLine("Enter task name: ");
            _tasks[_taskCount] = Console.ReadLine();
            _taskCount++;
        }

        public void ViewTasks()
        {
            for (var i=0; i < _taskCount; i++)
                Console.WriteLine((i + 1) + ". " + _tasks[i]);
        }

        public void CompleteTask()
        {
            Console.WriteLine("Select a task number to complete: ");

            var taskNumber = int.Parse(Console.ReadLine()) - 1;
            Console.WriteLine("Task number is: " + taskNumber); // debugging;

            if (taskNumber < 0 || taskNumber >= _taskCount)
            {
                Console.WriteLine("Selected task is out of range.");
                return;
            }

            for (var i=0; i < _taskCount; i++)
                if (taskNumber == i)
                {
                    if (!_tasks[i].EndsWith("(Completed)"))
                        _tasks[i] = _tasks[i] + "(Completed)";

                    break;
                }
        }

        public void Run()
        {
            var isRunning = true;
            var todo = new ToDoList();

            while (isRunning)
            {
                Console.WriteLine("Enter command: 1. Add, 2. View, 3., 4. Exit");
                var command = Console.ReadLine();
                switch(command)
                {
                    case "1": todo.AddTask(); break;
                    case "2": todo.ViewTasks(); break;
                    case "3": todo.CompleteTask(); break;
                    case "4":
                    default:
                        isRunning = false;
                    break;
                }
            }
        }
    }

    public static void Main()
    {
        var todoList = new ToDoList();
        todoList.Run();
    }
}

