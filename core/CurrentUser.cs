﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demonewkakaxi.core
{
    public static class CurrentUser
    {
        public static int Id { get; set; }
        public static string Name { get; set; }
        public static string Email { get; set; }
        public static Role Role { get; set; }
    }
}
