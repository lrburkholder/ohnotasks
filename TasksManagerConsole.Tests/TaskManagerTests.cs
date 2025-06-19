using Xunit;

namespace TasksManagerConsole.Tests;

/// <summary>
/// Contains unit tests for the TaskManager class.
/// </summary>
public class TaskManagerTests
{
    /// <summary>
    /// Tests that adding a task correctly creates a new task in the list
    /// with the specified description and default completion status.
    /// </summary>
    [Fact]
    public void AddTask_ShouldAddNewTaskToList()
    {
        // Arrange
        var taskManager = new TaskManager();
        string description = "Test task";

        // Act
        taskManager.AddTask(description);
        var tasks = taskManager.GetTasks();

        // Assert
        Assert.Single(tasks);
        Assert.Equal(description, tasks[0].Description);
        Assert.False(tasks[0].IsCompleted);
    }

    /// <summary>
    /// Tests that GetTasks returns an empty list when no tasks have been added.
    /// </summary>
    [Fact]
    public void GetTasks_WhenEmpty_ShouldReturnEmptyList()
    {
        // Arrange
        var taskManager = new TaskManager();

        // Act
        var tasks = taskManager.GetTasks();

        // Assert
        Assert.Empty(tasks);
    }

    /// <summary>
    /// Tests that marking a task as complete with a valid index
    /// correctly updates the task's completion status.
    /// </summary>
    [Fact]
    public void MarkTaskComplete_WithValidIndex_ShouldMarkTaskAsComplete()
    {
        // Arrange
        var taskManager = new TaskManager();
        taskManager.AddTask("Test task");

        // Act
        taskManager.MarkTaskComplete(0);
        var tasks = taskManager.GetTasks();

        // Assert
        Assert.True(tasks[0].IsCompleted);
    }

    /// <summary>
    /// Tests that attempting to mark a task as complete with invalid indices
    /// does not throw exceptions and handles the error gracefully.
    /// </summary>
    [Fact]
    public void MarkTaskComplete_WithInvalidIndex_ShouldNotThrowException()
    {
        // Arrange
        var taskManager = new TaskManager();
        taskManager.AddTask("Test task");

        // Act & Assert
        taskManager.MarkTaskComplete(-1); // Should not throw
        taskManager.MarkTaskComplete(1);  // Should not throw
    }

    /// <summary>
    /// Tests that deleting a task with a valid index successfully
    /// removes the task from the list.
    /// </summary>
    [Fact]
    public void DeleteTask_WithValidIndex_ShouldRemoveTask()
    {
        // Arrange
        var taskManager = new TaskManager();
        taskManager.AddTask("Task 1");
        taskManager.AddTask("Task 2");

        // Act
        bool result = taskManager.DeleteTask(0);
        var tasks = taskManager.GetTasks();

        // Assert
        Assert.True(result);
        Assert.Single(tasks);
        Assert.Equal("Task 2", tasks[0].Description);
    }

    /// <summary>
    /// Tests that attempting to delete tasks with invalid indices
    /// returns false and does not modify the task list.
    /// </summary>
    /// <param name="invalidIndex">The invalid index to test.</param>
    [Theory]
    [InlineData(-1)]
    [InlineData(1)]
    public void DeleteTask_WithInvalidIndex_ShouldReturnFalse(int invalidIndex)
    {
        // Arrange
        var taskManager = new TaskManager();
        taskManager.AddTask("Task 1");

        // Act
        bool result = taskManager.DeleteTask(invalidIndex);

        // Assert
        Assert.False(result);
        Assert.Single(taskManager.GetTasks());
    }

    /// <summary>
    /// Tests that the TaskItem constructor correctly initializes
    /// a new task with the given description and default completion status.
    /// </summary>
    [Fact]
    public void TaskItem_Constructor_ShouldInitializeCorrectly()
    {
        // Arrange & Act
        string description = "Test task";
        var taskItem = new TaskItem(description);

        // Assert
        Assert.Equal(description, taskItem.Description);
        Assert.False(taskItem.IsCompleted);
    }
}