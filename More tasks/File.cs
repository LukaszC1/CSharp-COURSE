using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace More_tasks
{
    interface File
    {
        string fileName { get; set;}
        int size { get; set; }
        DateTime createdOn { get; set; }
        void Compress();

    }
}
