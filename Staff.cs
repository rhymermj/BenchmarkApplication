using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkApplication
{
    public class Staff
    {   
        // Attributes
        private string staffName;
        private int staffId;
        private string staffDoB;
        private string staffEmail;
        private string staffPosition;
        private int staffSalary;
    
        // Getters and setters
        public string StaffName
        {
            get { return staffName; }
            set { staffName = value; }
        }

        public int StaffId
        {
            get { return staffId; }
            set { staffId = value; }
        }

        public string StaffDoB
        {
            get { return staffDoB; }
            set { staffDoB = value; }
        }

        public string StaffEmail
        {
            get { return staffEmail; }
            set { staffEmail = value; }
        }

        public string StaffPosition
        {
            get { return staffPosition; }
            set { staffPosition = value; }
        }

        public int StaffSalary
        {
            get { return staffSalary; }
            set { staffSalary = value; }
        }

        // Constructor with default values
        public Staff()
        {      
            StaffName = "NA";
            StaffId = 0;
            StaffDoB = "NA";
            StaffEmail = "NA";
            StaffPosition = "NA";
            StaffSalary = 0;
        }

        // Override ToString() method to display
        public override string ToString()
        {
            return StaffName + " ID: " + StaffId + " DoB: " + StaffDoB + " Email: " + StaffEmail
                + " Position: " + StaffPosition + " Salary: $" + StaffSalary;
        }
    }
}
