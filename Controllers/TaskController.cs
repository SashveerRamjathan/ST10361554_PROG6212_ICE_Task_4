using Microsoft.AspNetCore.Mvc;
using ST10361554_PROG6212_ICE_Task__4.Models;

namespace ST10361554_PROG6212_ICE_Task__4.Controllers
{
    public class TaskController : Controller
    {
        private readonly TaskCollection _taskCollection; 
        private readonly ILogger<TaskController> _logger;

        public TaskController(ILogger<TaskController> logger, TaskCollection taskCollection)
        {
            _logger = logger;
            _taskCollection = taskCollection;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                // Get all tasks
                var tasks = _taskCollection.GetAllTasks();

                // Check if the list is null or empty
                if (tasks == null || tasks.Count == 0)
                {
                    _logger.LogWarning("The list is null or count = 0.");

                    return View(_taskCollection.Tasks);
                }

                // Display success or error messages
                ViewData["SuccessMessage"] = TempData["SuccessMessage"];
                ViewData["ErrorMessage"] = TempData["ErrorMessage"];

                return View(tasks);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError($"An error occurred while getting tasks: {ex.Message}");
                TempData["ErrorMessage"] = "An error occurred while getting tasks.";

                return View(_taskCollection.Tasks);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TaskModel task)
        {
            try
            {
                // Check if the model is valid
                if (ModelState.IsValid)
                {
                    // Add the task to the collection
                    _taskCollection.AddTask(task);

                    // Display success message
                    TempData["SuccessMessage"] = "Task created successfully.";

                    // Log the success message
                    _logger.LogInformation($"Task {task.Title} created successfully.");

                    return RedirectToAction(nameof(Index));
                }

                return View(task);
            }
            catch (Exception ex)
            {
                //  log the exception
                _logger.LogError($"An error occurred while creating a task: {ex.Message}");
                TempData["ErrorMessage"] = "An error occurred while creating a task.";

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            try
            {
                // Get the task by its unique identifier
                var task = _taskCollection.GetTask(id);

                // Check if the task is null
                if (task == null)
                {
                    TempData["ErrorMessage"] = "Task not found."; // Display error message
                    _logger.LogError($"Task with id {id} not found."); // Log the error message
                    return RedirectToAction(nameof(Index));
                }

                return View(task);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError($"An error occurred while getting the task: {ex.Message}");
                TempData["ErrorMessage"] = "An error occurred while getting the task.";

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TaskModel task)
        {
            try
            {
                // Check if the model is valid
                if (ModelState.IsValid)
                {
                    // Update the task in the collection
                    _taskCollection.UpdateTask(task);

                    TempData["SuccessMessage"] = "Task updated successfully."; // Display success message
                    _logger.LogInformation($"Task {task.Title} updated successfully."); // Log the success message

                    return RedirectToAction(nameof(Index));
                }

                return View(task);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError($"An error occurred while updating the task: {ex.Message}");
                TempData["ErrorMessage"] = "An error occurred while updating the task.";

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            try
            {
                // Get the task by its unique identifier
                var task = _taskCollection.GetTask(id);

                // Check if the task is null
                if (task == null)
                {
                    TempData["ErrorMessage"] = "Task not found."; // Display error message
                    _logger.LogError($"Task with id {id} not found."); // Log the error message
                    return RedirectToAction(nameof(Index));
                }

                return View(task);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError($"An error occurred while getting the task: {ex.Message}");
                TempData["ErrorMessage"] = "An error occurred while getting the task.";

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(TaskModel task)
        {
            try
            {
                // Remove the task from the collection
                _taskCollection.RemoveTask(task.Id);

                TempData["SuccessMessage"] = "Task deleted successfully."; // Display success message
                _logger.LogInformation($"Task {task.Title} deleted successfully."); // Log the success message

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError($"An error occurred while deleting the task: {ex.Message}");
                TempData["ErrorMessage"] = "An error occurred while deleting the task.";

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            try
            {
                // Get the task by its unique identifier
                var task = _taskCollection.GetTask(id);

                // Check if the task is null
                if (task == null)
                {
                    TempData["ErrorMessage"] = "Task not found."; // Display error message
                    _logger.LogError($"Task with id {id} not found."); // Log the error message
                    return RedirectToAction(nameof(Index));
                }

                return View(task);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError($"An error occurred while getting the task: {ex.Message}");
                TempData["ErrorMessage"] = "An error occurred while getting the task.";
                return RedirectToAction(nameof(Index));
            }
        }

    }
}
