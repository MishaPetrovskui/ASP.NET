using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Pages
{
    public class JobsModel : PageModel
    {
        private readonly JobService _job;

        public List<Job> Jobs => _job.GetAll();

        [BindProperty]
        public Job CurrentJob { get; set; } = new Job();

        public JobsModel(JobService jobs)
        {
            _job = jobs;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostAdd()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _job.Add(CurrentJob);
            return RedirectToPage();
        }

        public IActionResult OnPostUpdate(int id)
        {
            ModelState.Clear();

            if (string.IsNullOrWhiteSpace(CurrentJob.last_name) ||
                string.IsNullOrWhiteSpace(CurrentJob.first_name))
            {
                return new JsonResult(new { success = false, error = "Required fields missing" });
            }

            _job.Update(id, CurrentJob);
            return new JsonResult(new { success = true });
        }

        public IActionResult OnPostDelete(int id)
        {
            _job.Delete(id);
            return new JsonResult(new { success = true });
        }
    }
}
