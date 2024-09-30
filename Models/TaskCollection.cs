namespace ST10361554_PROG6212_ICE_Task__4.Models
{
    public class TaskCollection
    {
        // This class is used to store a collection of tasks
        public List<TaskModel> Tasks = new List<TaskModel>();

        // Add a task to the collection
        public void AddTask(TaskModel task)
        {
            try
            {
                Tasks.Add(task);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Remove a task from the collection
        public void RemoveTask(string id)
        {
            try
            {
                Tasks.RemoveAll(t => t.Id.Equals(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Get a task from the collection by its unique identifier
        public TaskModel GetTask(string id)
        {
            try
            {
                return Tasks.FirstOrDefault(t => t.Id.Equals(id))!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Update a task in the collection
        public void UpdateTask(TaskModel task)
        {
            try
            {
                var index = Tasks.FindIndex(t => t.Id.Equals(task.Id));
                Tasks[index] = task;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Get all tasks in the collection
        public List<TaskModel> GetAllTasks()
        {
            return Tasks;
        }

        // Get all completed tasks in the collection
        public List<TaskModel> GetCompletedTasks()
        {
            try
            {
                return Tasks.Where(t => t.IsComplete).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Get all incomplete tasks in the collection
        public List<TaskModel> GetIncompleteTasks()
        {
            try
            {
                return Tasks.Where(t => !t.IsComplete).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Get all tasks close to a specific deadline
        public List<TaskModel> GetTasksCloseToDeadline(DateTime deadline)
        {
            try
            {
                return Tasks.Where(t => t.DeadLine.Date == deadline.Date).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
