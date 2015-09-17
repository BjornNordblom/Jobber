using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobber
{
    public sealed class JobManager
    {
        private static readonly JobManager jobmanager = new JobManager();
        private static Dictionary<Guid, Job> jobs = new Dictionary<Guid, Job>();

        static JobManager() { }
        private JobManager() { }

        public IEnumerable<Job> Jobs { get { return jobs.Select(x => x.Value); } }
        public static JobManager Instance { get { return jobmanager; } }

        public Job Get(Guid id)
        {
            return jobs[id];
        }
        public Job Add(Guid id)
        {
            if (jobs.ContainsKey(id))
            {
                throw new ArgumentException(String.Format("JobManager already contains job {0}", id));
            }
            Job job = new Job() { Id = id, Name = "" };
            jobs.Add(id, job);
            return job;
        }
    }
}
