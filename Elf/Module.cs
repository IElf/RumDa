using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elf
{
    public class Module
    {
        public string Id { get { return Guid.NewGuid().ToString(); } }
        public string ModuleCh { get; set; }
        public string ModuleEn { get; set; }

        public string InvolveTable { get; set; }

        public string Description { get; set; }
    }
}
