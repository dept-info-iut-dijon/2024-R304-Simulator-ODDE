﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public static class Constants
    {
        public static readonly int MATERIALS = 100;
        public static readonly int COST_MATERIALS = 400;
        public static readonly int BONUS = 10000;
        public static int TIME_SLICE = 1000;
        public static readonly int MAXSTOCK = 100;
        public static readonly int SALARY = 1500;
        public static int MONTH_TIME => 20*TIME_SLICE;
        public static int WEEK_TIME => MONTH_TIME/4;
    }
}
