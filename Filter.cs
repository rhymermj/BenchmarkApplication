using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkApplication
{
    public class Filter
    {
        // Return a list of Staff objects that has been read from the file
        public List<Staff> SortAZ(List<Staff> sList)
        {
            // Sort the unordered list A to Z by StaffName and overwrite sList
            // Call OrderBy method and pass a lambda expression as a parameter
            // Any LINQ method that returns a sequence of elements returns it as an IEnumerable<T>. 
            // ToList() converts an IEnumerable<T> to a List<T>
            sList = sList.OrderBy(x => x.StaffName).ToList();   

            return sList;
        }

        // Sort the list Z to A using LINQquery expression
        public List<Staff> SortZA(List<Staff> sList)
        {
            sList = (from x in sList
                     orderby x.StaffName descending
                     select x).ToList();

            return sList;
        }

        public List<Staff> Search(List<Staff> sList, string term)
        {
            // Declare and instantiate a new list of Staff objects called results 
            List<Staff> results = new List<Staff>();

            // Loop through the list of staff examining each one
            foreach (Staff s in sList)
            {
                // If the StaffName matches the search term, add it to the results list
                // Contains() method retuns true if the first string contains the parameter string term (the search term)
                if (s.StaffName.ToLower().Contains(term.ToLower()))
                {
                    results.Add(s);
                }
            }
            // Return the list, results, populated with matching search results
            return results;
        }
    }
}
