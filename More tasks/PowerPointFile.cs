﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace More_tasks
{
     class PowerPointFile : File
    {
        public string fileName { get; set; }
        public int size { get; set; }
        public DateTime createdOn { get; set; }

        public void Compress()
        {
            Console.WriteLine("Compressing PowerPointFile!");
        }
    }
}