using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    /// Store all constants of the simulation
    /// </summary>
    public class Parameters
    {
        private int materials=100;
        private int cost_materials=400;
        private int bonus=1000;
        private int time_slice=1000;
        private int maxstock=100;
        private int salary=1500;
        private int month_time=20000;
        private int week_time=5000;
       
        /// <summary>
        /// Gets or sets initial quantity of materials
        /// </summary>
        public int Materials {get => materials;set => materials = value; }

        /// <summary>
        /// Gets or sets the cost of materials
        /// </summary>
        public int CostOfMaterials { get=>cost_materials;set => cost_materials = value; }
        /// <summary>
        /// Gets or sets the bonus
        /// </summary>
        public int Bonus { get => bonus; set => bonus = value; }

        /// <summary>
        /// Gets or sets TIME_SLICE (atom of time)
        /// </summary>
        public int TimeSlice {get=>time_slice;set => time_slice = value; }


        /// <summary>
        /// Gets or sets the amount max of stock
        /// </summary>
        public int MaxStock { get=>maxstock;set => maxstock = value; }

        /// <summary>
        /// Gets or sets salary of each employee
        /// </summary>
        public int Salary { get=>salary;set => salary = value; }


        /// <summary>
        /// Gets or sets the simulated time for a month, in milliseconds
        /// </summary>
        public int MonthTime { get => month_time; set => month_time = value; }
        
        /// <summary>
        /// Gets or sets the simulated time for a week, in milliseconds
        /// </summary>
        public int WeekTime { get => week_time; set => week_time = value; }
    }
}
