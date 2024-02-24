using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeInventoryAndLog
{
    public partial class Mainfrm : Form
    {
        List<string> itemsForHome = new List<string>();

        // test file
        //private const string path = @"C:\Users\corsi\Documents\MyFilesVS2022\HomeInventory.txt";

        // a universal default path that can be used by any users on any computer
        private const string projectFile = "Inventory.txt";
        private const string projectPath = @"C:";

        public Mainfrm()
        {
            InitializeComponent();
        }

        // Load items from save file
        // display items with the format => Item name : Count
        private void Main_Load(object sender, EventArgs e)
        {
            LoadItems();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SubmitEntry();
            clearTextBox();
        }

        // method for Add button
        private void SubmitEntry()
        {
            string entry = txtEntry.Text + " : " + txtQuantity.Text;

            // check if the txtboxes are empty, if they are, create an error message

            itemsForHome.Add(entry);
            lbInventoryList.Items.Add(entry);

            // write to save file
            SaveItems(itemsForHome);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // delete from list structure
            // CHECK if an index is selected
            if (lbInventoryList.SelectedIndex >= 0 | 
                lbInventoryList.SelectedIndex < lbInventoryList.Items.Count)
            {
                itemsForHome.RemoveAt(lbInventoryList.SelectedIndex);

                // delete from list box
                lbInventoryList.Items.RemoveAt(lbInventoryList.SelectedIndex);

                // write to save file
                SaveItems(itemsForHome);
            }

            clearTextBox();
        }

        // used in Add and Delete methods
        private void clearTextBox()
        {
            txtEntry.Text = "";
            txtQuantity.Text = string.Empty;
            txtEntry.Focus();
        }

        // write to file
        private void SaveItems(List<string> items)
        {
            StreamWriter textOut =
                new StreamWriter(new FileStream(projectPath + projectFile, FileMode.Create, FileAccess.Write));

            foreach (string item in items)
            {
                textOut.WriteLine(item);
            }
            textOut.Close();
        }

        // read from file
        private List<string> LoadItems()
        {
            StreamReader textIn =
                new StreamReader(new FileStream(projectPath + projectFile, FileMode.OpenOrCreate, FileAccess.Read));

            List<string> items = new List<string>();
            while (textIn.Peek() != -1)
            {
                string item = textIn.ReadLine();
                itemsForHome.Add(item);

                // check for null value, cannot add null to listbox
                if (item != null)
                {
                    lbInventoryList.Items.Add(item);
                }
            }
            textIn.Close();

            return items;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
