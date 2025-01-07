using LogicLayer.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    /// A production of the workshop
    /// </summary>
    public class Production : Subject
    {
        private Product product;
        private bool done;
        /// <summary>
        /// Init the production
        /// </summary>
        /// <param name="product">the product to build</param>
        /// <param name="time_slice">time slice, en ms</param>
        public Production(Product product, int time_slice)
        {
            this.product = product;
            base.NotifyProductionStart(product);
            done=false;
            Timer timer = new Timer(ProdDone);
            timer.Change(product.TimeToBuild*time_slice, Timeout.Infinite);
        }

        private void ProdDone(object? state)
        {
            done = true;
            base.NotifyProductionDone(product);
        }

        /// <summary>
        /// Tell if the production is done
        /// </summary>
        public bool IsDone { get => done; }

        /// <summary>
        /// Gets the product 
        /// </summary>
        public Product Product { get => product; }
        
    }
}
