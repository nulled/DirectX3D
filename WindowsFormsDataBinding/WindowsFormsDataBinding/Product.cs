using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsDataBinding
{
    public class Product
    {
        public string modelNumber;
        public string modelName;
        public decimal unitCost;
        public string description;

        public Product(string modelNumber, string modelName, decimal unitCost, string description)
        {
            this.modelNumber = modelNumber;
            this.modelName = modelName;
            this.unitCost = unitCost;
            this.description = description;
        }

        public override string ToString()
        {
            return String.Format("{0}, ({1})", modelName, modelNumber);
        }
    }

}
