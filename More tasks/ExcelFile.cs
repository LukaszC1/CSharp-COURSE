using System;
using System.Collections.Generic;
using System.Linq;

namespace More_tasks
{
     class ExcelFile : File
    {
        public string fileName { get; set; }
        public int size { get; set; }
        public DateTime createdOn { get; set; }

        public void Compress()
        {
            Console.WriteLine("Compressing ExcelFile!");
        }
    }
}
