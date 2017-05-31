namespace Kopstt.Core.Database.Models
{
    using System;

    public class Job
    {
        public virtual int id { get; set; }
        public virtual string name { get; set; }
        public virtual long category { get; set; }
		public virtual DateTime added { get; set; }
		public virtual DateTime execution { get; set;}
		public virtual int priority { get; set; }
		public virtual bool done { get; set; }
		public virtual bool archived { get; set; }
    }
}
