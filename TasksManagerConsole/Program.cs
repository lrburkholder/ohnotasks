using TasksManagerConsole;

// Display welcome message and initialize task manager
Console.WriteLine("Welcome to the Task Manager Demo!");
var taskManager = new TaskManager();

// Main application loop
while (true)
{
    ShowMenu();
    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            AddTask(taskManager);
            break;
        case "2":
            ListTasks(taskManager);
            break;
        case "3":
            MarkTaskComplete(taskManager);
            break;
        case "4":
            DeleteTask(taskManager);
            break;
        case "5":
            return;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}

/// <summary>
/// Displays the main menu options to the user.
/// </summary>
static void ShowMenu()
{
    Console.WriteLine("\n" + new string('=', 25));
    Console.WriteLine("Please select an option:");
    Console.WriteLine("1. Add new task");
    Console.WriteLine("2. List all tasks");
    Console.WriteLine("3. Mark task as complete");
    Console.WriteLine("4. Delete task");
    Console.WriteLine("5. Exit");
    Console.WriteLine(new string('=', 25));
}

/// <summary>
/// Prompts the user for a task description and adds it to the task manager.
/// </summary>
/// <param name="manager">The task manager instance.</param>
static void AddTask(TaskManager manager)
{
    Console.Write("Enter task description: ");
    var description = Console.ReadLine();
    manager.AddTask(description!);
    Console.WriteLine("\nTask added successfully!");
}

/// <summary>
/// Displays all tasks in the task manager with their completion status.
/// If no tasks exist, displays a message indicating so.
/// </summary>
/// <param name="manager">The task manager instance.</param>
static void ListTasks(TaskManager manager)
{
    var tasks = manager.GetTasks();
    if (!tasks.Any())
    {
        Console.WriteLine("No tasks found.");
        return;
    }

    for (int i = 0; i < tasks.Count; i++)
    {
        Console.WriteLine($"{i + 1}. [{(tasks[i].IsCompleted ? "X" : " ")}] {tasks[i].Description}");
    }
}

/// <summary>
/// Prompts the user to select a task to mark as complete.
/// Displays the current task list and validates user input.
/// </summary>
/// <param name="manager">The task manager instance.</param>
static void MarkTaskComplete(TaskManager manager)
{
    ListTasks(manager);
    Console.Write("Enter task number to mark as complete: ");
    if (int.TryParse(Console.ReadLine(), out int taskNumber))
    {
        manager.MarkTaskComplete(taskNumber - 1);
        Console.WriteLine("\nTask marked as complete!");
    }
    else
    {
        Console.WriteLine("Invalid task number.");
    }
}

/// <summary>
/// Prompts the user to select a task to delete.
/// Displays the current task list and validates user input.
/// </summary>
/// <param name="manager">The task manager instance.</param>
static void DeleteTask(TaskManager manager)
{
    var tasks = manager.GetTasks();
    if (!tasks.Any())
    {
        Console.WriteLine("No tasks to delete.");
        return;
    }

    ListTasks(manager);
    Console.Write("Enter task number to delete: ");
    if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
    {
        if (manager.DeleteTask(taskNumber - 1))
        {
            Console.WriteLine("\nTask deleted successfully!");
        }
        else
        {
            Console.WriteLine("Failed to delete task.");
        }
    }
    else
    {
        Console.WriteLine("Invalid task number.");
    }
}