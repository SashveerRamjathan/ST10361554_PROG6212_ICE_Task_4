using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ST10361554_PROG6212_ICE_Task__4.Models
{
    public class TaskModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString(); // unique identifier for each task

        [Required]
        [MaxLength(100, ErrorMessage = "The title is required and must not exceed 100 characters.")]
        [DisplayName("Task Title")]
        public string Title { get; set; } // title of the task

        [MaxLength(500, ErrorMessage = "The description must not exceed 500 characters.")]
        [DisplayName("Task Description")]
        public string? Description { get; set; } // description of is task optional

        [Required]
        [DisplayName("Task Deadline")]
        public DateTime DeadLine { get; set; } // deadline for the task

        [DisplayName("Task Status")]
        public bool IsComplete { get; set; } // status of the task
    }
}
