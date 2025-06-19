namespace TasksManagerConsole
{
    /// <summary>
    /// Manages a collection of tasks and provides operations for task manipulation.
    /// </summary>
    public class TaskManager
    {
        /// <summary>
        /// Internal list to store tasks.
        /// </summary>
        private List<TaskItem> _tasks = new();

        /// <summary>
        /// Adds a new task with the specified description to the task list.
        /// </summary>
        /// <param name="description">The description of the task to add.</param>
        public void AddTask(string description)
        {
            _tasks.Add(new TaskItem(description));
        }

        /// <summary>
        /// Retrieves all tasks in the list.
        /// </summary>
        /// <returns>A list of all tasks.</returns>
        public List<TaskItem> GetTasks()
        {
            return _tasks;
        }

        /// <summary>
        /// Marks a task as complete at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the task to mark as complete.</param>
        /// <remarks>
        /// If the index is out of range, the method will silently fail.
        /// </remarks>
        public void MarkTaskComplete(int index)
        {
            if (index >= 0 && index < _tasks.Count)
            {
                _tasks[index].IsCompleted = true;
            }
        }

        /// <summary>
        /// Deletes a task at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the task to delete.</param>
        /// <returns>true if the task was successfully deleted; otherwise, false.</returns>
        public bool DeleteTask(int index)
        {
            if (index >= 0 && index < _tasks.Count)
            {
                _tasks.RemoveAt(index);
                return true;
            }
            return false;
        }
    }

    /// <summary>
    /// Represents a single task item with a description and completion status.
    /// </summary>
    public class TaskItem
    {
        /// <summary>
        /// Gets or sets the description of the task.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the task is completed.
        /// </summary>
        public bool IsCompleted { get; set; }

        /// <summary>
        /// Initializes a new instance of the TaskItem class.
        /// </summary>
        /// <param name="description">The description of the task.</param>
        public TaskItem(string description)
        {
            Description = description;
            IsCompleted = false;
        }
    }
}