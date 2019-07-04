using System;
using System.Collections.Generic;

namespace PracticeInfoSystem
{
    public partial class Language
    {
        public Language()
        {
            Doctor = new HashSet<Doctor>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<Doctor> Doctor { get; set; }
    }
}
