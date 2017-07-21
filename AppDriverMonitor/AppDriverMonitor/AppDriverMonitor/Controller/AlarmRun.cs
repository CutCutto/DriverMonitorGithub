using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDriverMonitor.Controller
{
    public class AlarmRun
    {
        public event EventHandler AlarmRunInterval;
        public Func<Task<string>> GetStatusCallback { get; set; }
        public string StatusLevel { get; set; }
        public AlarmRun(string status)
        {
            this.StatusLevel = status;
            this.GetStatusCallback = () => Task.FromResult<string>(this.StatusLevel);
        }



    }
}
