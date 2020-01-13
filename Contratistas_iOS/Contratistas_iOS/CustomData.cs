using System;
using System.Collections.Generic;
using System.Text;

namespace Contratistas_iOS
{
    public class CustomData
    {
        public CustomData(string image)
        {
            Image = image;
        }
        public string Image
        {
            get;
            set;
        }
        public CustomData()
        {

        }
    }
}
