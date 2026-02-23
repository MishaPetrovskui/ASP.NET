using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class JobService
    {
        private List<Job> _jobs = new List<Job>();
        private int _nextId = 1;

        public List<Job> GetAll()
        {
            return _jobs;
        }

        public void Add(Job job)
        {
            job.Id = _nextId++;
            _jobs.Add(job);
        }

        public void Update(int id, Job updatedJob)
        {
            var job = _jobs.FirstOrDefault(p => p.Id == id);
            if (job != null)
            {
                job.birthday = updatedJob.birthday;
                job.brigade = updatedJob.brigade;
                job.children = updatedJob.children;
                job.department = updatedJob.department;
                job.first_name = updatedJob.first_name;
                job.gender = updatedJob.gender;
                job.hired = updatedJob.hired;
                job.height = updatedJob.height;
                job.last_name = updatedJob.last_name;
                job.middle_name = updatedJob.middle_name;
                job.position = updatedJob.position;
                job.salary = updatedJob.salary;
            }
        }

        public void Delete(int id)
        {
            var job = _jobs.FirstOrDefault(p => p.Id == id);
            if (job != null)
            {
                _jobs.Remove(job);
            }
        }

        public List<Job> Filter(
            string? department = null,
            string? position = null,
            string? last_name = null,
            string? gender = null,
            string? brigade = null,
            decimal? salaryMin = null,
            decimal? salaryMax = null,
            int? heightMin = null,
            int? children = null)
        {
            return _jobs.Where(p =>
                (string.IsNullOrEmpty(department) || p.department.Contains(department, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(position) || p.position.Contains(position, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(last_name) || p.last_name.Contains(last_name, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(gender) || p.gender.Equals(gender, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(brigade) || p.brigade.Contains(brigade, StringComparison.OrdinalIgnoreCase)) &&
                (salaryMin == null || p.salary >= salaryMin) &&
                (salaryMax == null || p.salary <= salaryMax) &&
                (heightMin == null || p.height >= heightMin) &&
                (children == null || p.children == children)
            ).ToList();
        }
    }
}
