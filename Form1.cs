using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BenchmarkApplication
{
    public partial class Form1 : Form
    {
        // Declare and instantiate a list of Staff objects
        List<Staff> staff = new List<Staff>();

        // Declare and instantiate a list of Staff objects returned from search results
        List<Staff> results = new List<Staff>();

        public Form1()
        {
            // InitializeComponent() method is automatically created and managed by Windows Forms
            // and defines everything we see on the form.
            InitializeComponent();
        }
    
        private void btnLoad_Click(object sender, EventArgs e)
        {
            // Clear the master staff list
            staff.Clear();

            // Create a FileManager object
            FileManager fm = new FileManager();

            // Load the staff and store it to the list
            staff = fm.LoadStaff();

            // If a null list was returned in case something went wrong, display a message
            if (staff == null)
            {
                MessageBox.Show("Error Loading Staff", "File IO Error");
            }
            else
            {
                // Update the listbox
                lbxStaff.Items.Clear();
                lbxStaff.Items.AddRange(staff.ToArray());
            }
        }

        private void SortAZ_Click(object sender, EventArgs e)
        {
            // Create a Filter object
            Filter sFilter = new Filter();

            // Set the staff list to the results from the SortAZ method
            staff = sFilter.SortAZ(staff);

            // Update the listbox
            lbxStaff.Items.Clear();
            lbxStaff.Items.AddRange(staff.ToArray());
        }

        private void SortZA_Click(object sender, EventArgs e)
        {
            Filter sFilter = new Filter();

            // Set the staff list to the results from the SortZA method
            staff = sFilter.SortZA(staff);

            // Update the listbox
            lbxStaff.Items.Clear();
            lbxStaff.Items.AddRange(staff.ToArray());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
 //           List<Staff> results = new List<Staff>();

            Filter sFilter = new Filter();

            // Get the search term from textbox
            string term = tbxSearch.Text;

            // Set the results list to what is returned from the search method
            results = sFilter.Search(staff, term);

            // Update the search results listbox
            lbxSearchResults.Items.Clear();
            lbxSearchResults.Items.AddRange(results.ToArray());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                FileManager fm = new FileManager();

                // Get the selected staff to save
                Staff s = (Staff)lbxSearchResults.SelectedItem;

                // Create a file name
                string fileName = "Saved.txt";

                // Save Staff object to the file 
                bool result = fm.SaveStaff(s, fileName);

                // If something went wrong and didn't save, display a message
                if (result == false)    
                {
                    MessageBox.Show("Error Saving Staff", "File IO Error");
                }
                else
                {
                    // Display a message if save was successful and ask the user if they want to view the saved file
                    DialogResult dr = MessageBox.Show("View File?", "Save Successful", MessageBoxButtons.YesNo);

                    // If user wants to view, show the file
                    if (dr.Equals(DialogResult.Yes))
                    {
                        System.Diagnostics.Process.Start(fileName);
                    }
                }
            }
            // Throw an exception if a staff has not been selected from the search results listbox
            catch (Exception)
            {
                MessageBox.Show("Please select a staff", "Error");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the selected staff to delete
                Staff s = (Staff)lbxSearchResults.SelectedItem;

                // Delete the selected staff from staff list box
                staff.Remove(s);

                // Update the listbox
                lbxStaff.Items.Clear();
                lbxStaff.Items.AddRange(staff.ToArray());

                // Delete the selected staff from search results list box
                results.Remove(s);

                // Update the listbox
                lbxSearchResults.Items.Clear();
                lbxSearchResults.Items.AddRange(results.ToArray());
            }

            // Throw an exception if a staff has not been selected from the search results listbox
            catch (Exception)
            {
                MessageBox.Show("Please select a staff", "Error");
            }
        }

        private void lbxSearchResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Display the details of the selected staff when save button is pressed
            try
            {
                // Get the selected staff
                Staff s = (Staff)lbxSearchResults.SelectedItem;
                
                // Update textboxes
                tbxName.Text = s.StaffName;
                tbxID.Text = s.StaffId.ToString();
                tbxDoB.Text = s.StaffDoB;
                tbxEmail.Text = s.StaffEmail;
                tbxPosition.Text = s.StaffPosition;
                tbxSalary.Text = s.StaffSalary.ToString();
            }
            // Throw an exception and display a message when delete button is pressed
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }
    }
}
