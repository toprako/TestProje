using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjesi
{
    class Api
    {
        private String Status, BigDiameter, SmallDiameter;
        public  string status
        {
            get
            {
                return Status;
            }
            set
            {
                Status = value;
            }
        }
        public string bigdiameter
        {
            get
            {
                return  BigDiameter;
            }
            set
            {
                BigDiameter = value;
            }
        }
        public string smalldiameter
        {
            get
            {
                return SmallDiameter;
            }
            set
            {
                SmallDiameter = value;
            }
        }
    }
}
