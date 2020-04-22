using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BenchmarkApplication
{
    public class FileManager
    {
        // Return a list of staff objects that has been read from file
        public List<Staff> LoadStaff()
        {
            try
            {
                // Declare and instantiate a list of Staff objects
                List<Staff> staffList = new List<Staff>();

                // Declare and instantiate a StreamReader object to read Staff data from Staff.txt file
                StreamReader sr = new StreamReader("Staff.txt");

                // Read a new line while not at the end of the file
                while (!sr.EndOfStream)
                {
                    // Read a line of stsaff data from the file and store in a string variable called temp
                    string temp = sr.ReadLine();
                    // Split the staff string into separate parts and store in a string array variable
                    string[] values = temp.Split(',');

                    // Declare and instantiate a Staff object
                    Staff s = new Staff();

                    // Set the property of the staff object to the value read from file according to their array index
                    s.StaffName = values[0];
                    s.StaffId = int.Parse(values[1]);   // Convert string to int
                    s.StaffDoB = values[2];
                    s.StaffEmail = values[3];
                    s.StaffPosition = values[4];
                    s.StaffSalary = int.Parse(values[5]);

                    // Add the new Staff object to the staffList
                    staffList.Add(s);
                }

                // Close the StreamReader and release the Staff.txt file
                sr.Dispose();

                // Return the list of Staff objects that has been populated reading from the file
                return staffList;
            }
            /*
             * Catch exception (if the text file is out of order, an extra space is entered,
             * FileIO read/write permission, or File is not found) and return null
             */
            catch (Exception)
            {
                return null;
            }
        }

        // Return a boolean value where it returns true if save is successful, or returns false if there is an error
        // two parameters, a Staff object to save and fileName, a string of the file name to save to
        public bool SaveStaff(Staff s, string fileName)
        {
            using (StreamWriter sw = File.AppendText(fileName))

                try
                {
                    // Declare and instantiate a StreamWriter object to write to a file
                    //                  StreamWriter sw = new StreamWriter(fileName);

                    // Write a header to file
                    sw.WriteLine("STAFF DETAILS");
                    // Write Staff object data to file
                    sw.WriteLine("Staff ID: " + s.StaffId);
                    sw.WriteLine("Staff Name: " + s.StaffName);
                    sw.WriteLine("Staff Date of Birth: " + s.StaffDoB);
                    sw.WriteLine("Staff Email: " + s.StaffEmail);
                    sw.WriteLine("Staff Position: " + s.StaffPosition);
                    sw.WriteLine("Staff Salary: " + s.StaffSalary);
                    sw.WriteLine("");

                    // Close the StreamWriter and release the newly created file
                    sw.Dispose();

                    // If save operation is successful, return true
                    return true;
                }
                // Throw an exception if something has gone wrong and return false
                catch (Exception)
                {
                    return false;
                }
        }
    }
}

