using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace TasksTracker.WebPortal.Frontend.Ui.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public string? TasksCreatedBy { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _logger.LogInformation($"OnPost triggered with TasksCreatedBy: {TasksCreatedBy}");

            if (!string.IsNullOrEmpty(TasksCreatedBy))
            {
                Response.Cookies.Append("TasksCreatedByCookie", TasksCreatedBy);
            }

            return RedirectToPage("/Tasks/IndexTask");
        }
    }
}
