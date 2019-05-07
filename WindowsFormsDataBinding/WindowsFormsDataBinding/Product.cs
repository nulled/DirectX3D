using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsDataBinding
{
    public class Product
    {
        private string modelNumber;
        public string ModelNumber
        {
            get { return modelNumber; }
            set { modelNumber = value; }
        }

        private string modelName;
        public string ModelName
        {
            get; set; // C# 3.0 shorthand set/get
        }
        private decimal unitCost;
        public decimal UnitCost
        {
            get { return unitCost; }
            set { unitCost = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public Product(string modelNumber, string modelName, decimal unitCost, string description)
        {
            ModelNumber = modelNumber;
            ModelName = modelName;
            UnitCost = unitCost;
            Description = description;
        }

        public override string ToString()
        {
            //System.Windows.Forms.MessageBox.Show(string.Format("{0} ({1})", ModelName, ModelNumber));
            return string.Format("{0} {1}", ModelName.Trim(), ModelNumber.Trim());
        }
    }

}
