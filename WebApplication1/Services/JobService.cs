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

        public void Filter(Job job)
        {
            _jobs = _jobs.Where(p =>
                (string.IsNullOrEmpty(job.first_name) || p.first_name.Contains(job.first_name, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(job.last_name) || p.last_name.Contains(job.last_name, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(job.middle_name) || p.middle_name.Contains(job.middle_name, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(job.brigade) || p.brigade.Contains(job.brigade, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(job.gender) || p.gender.Contains(job.department, StringComparison.OrdinalIgnoreCase)) &&
                (job.birthday == default || p.birthday.Date == job.birthday.Date) &&
                (job.height == 0 || p.height == job.height) &&
                (string.IsNullOrEmpty(job.position) || p.position.Contains(job.position, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(job.department) || p.department.Contains(job.department, StringComparison.OrdinalIgnoreCase)) &&
                (job.hired == default || p.hired.Date == job.hired.Date) &&
                (job.salary == 0 || p.salary == job.salary) &&
                (job.children == 0 || p.children == job.children)
            ).ToList();
        }
    }
}