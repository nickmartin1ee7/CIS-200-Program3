// Program 2
// CIS 200-75
// Fall 2022
// Due: 11/19/2022
// By: Nicholas Martin (5111752)


using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace UPVApp
{
    public partial class Prog3Form : Form
    {
        private const string DATA_FILE_FILTER = "Data files (*.dat)|*.dat";
        private UserParcelView upv; // The UserParcelView

        // Precondition:  None
        // Postcondition: The form's GUI is prepared for display. A few test addresses are
        //                added to the list of addresses
        public Prog3Form()
        {
            InitializeComponent();

            upv = new UserParcelView();
        }

        // Precondition:  File, About menu item activated
        // Postcondition: Information about author displayed in dialog box
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string NL = Environment.NewLine; // Newline shorthand

            MessageBox.Show($"Program 2{NL}By: Nicholas Martin{NL}CIS 200{NL}Fall 2022",
                "About Program 3");
        }

        // Precondition:  File, Exit menu item activated
        // Postcondition: The application is exited
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Precondition:  Insert, Address menu item activated
        // Postcondition: The Address dialog box is displayed. If data entered
        //                are OK, an Address is created and added to the list
        //                of addresses
        private void addressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddressForm addressForm = new AddressForm();    // The address dialog box form
            DialogResult result = addressForm.ShowDialog(); // Show form as dialog and store result
            int zip; // Address zip code

            if (result == DialogResult.OK) // Only add if OK
            {
                if (int.TryParse(addressForm.ZipText, out zip))
                {
                    upv.AddAddress(addressForm.AddressName, addressForm.Address1,
                        addressForm.Address2, addressForm.City, addressForm.State,
                        zip); // Use form's properties to create address
                }
                else // This should never happen if form validation works!
                {
                    MessageBox.Show("Problem with Address Validation!", "Validation Error");
                }
            }

            addressForm.Dispose(); // Best practice for dialog boxes
                                   // Alternatively, use with using clause as in Ch. 17
        }

        // Precondition:  Report, List Addresses menu item activated
        // Postcondition: The list of addresses is displayed in the addressResultsTxt
        //                text box
        private void listAddressesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder(); // Holds text as report being built
                                                        // StringBuilder more efficient than String
            string NL = Environment.NewLine;            // Newline shorthand

            result.Append("Addresses:");
            result.Append(NL); // Remember, \n doesn't always work in GUIs
            result.Append(NL);

            foreach (Address a in upv.AddressList)
            {
                result.Append(a.ToString());
                result.Append(NL);
                result.Append("------------------------------");
                result.Append(NL);
            }

            reportTxt.Text = result.ToString();

            // -- OR --
            // Not using StringBuilder, just use TextBox directly

            //reportTxt.Clear();
            //reportTxt.AppendText("Addresses:");
            //reportTxt.AppendText(NL); // Remember, \n doesn't always work in GUIs
            //reportTxt.AppendText(NL);

            //foreach (Address a in upv.AddressList)
            //{
            //    reportTxt.AppendText(a.ToString());
            //    reportTxt.AppendText(NL);
            //    reportTxt.AppendText("------------------------------");
            //    reportTxt.AppendText(NL);
            //}

            // Put cursor at start of report
            reportTxt.Focus();
            reportTxt.SelectionStart = 0;
            reportTxt.SelectionLength = 0;
        }

        // Precondition:  Insert, Letter menu item activated
        // Postcondition: The Letter dialog box is displayed. If data entered
        //                are OK, a Letter is created and added to the list
        //                of parcels
        private void letterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LetterForm letterForm; // The letter dialog box form
            DialogResult result;   // The result of showing form as dialog
            decimal fixedCost;     // The letter's cost

            if (upv.AddressCount < LetterForm.MIN_ADDRESSES) // Make sure we have enough addresses
            {
                MessageBox.Show("Need " + LetterForm.MIN_ADDRESSES + " addresses to create letter!",
                    "Addresses Error");
                return; // Exit now since can't create valid letter
            }

            letterForm = new LetterForm(upv.AddressList); // Send list of addresses
            result = letterForm.ShowDialog();

            if (result == DialogResult.OK) // Only add if OK
            {
                if (decimal.TryParse(letterForm.FixedCostText, out fixedCost))
                {
                    try
                    {
                        // For this to work, LetterForm's combo boxes need to be in same
                        // order as upv's AddressList
                        upv.AddLetter(upv.AddressAt(letterForm.OriginAddressIndex),
                            upv.AddressAt(letterForm.DestinationAddressIndex),
                            fixedCost); // Letter to be inserted
                    }
                    catch (ArgumentException ex)
                    {
                        ShowAddressValidationError(ex.Message);
                    }
                }
                else // This should never happen if form validation works!
                {
                    ShowAddressValidationError();
                }
            }

            letterForm.Dispose(); // Best practice for dialog boxes
                                  // Alternatively, use with using clause as in Ch. 17
        }

        // Precondition:  Report, List Parcels menu item activated
        // Postcondition: The list of parcels is displayed in the parcelResultsTxt
        //                text box
        private void listParcelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // This report is generated without using a StringBuilder, just to show an
            // alternative approach more like what most students will have done
            // Method AppendText is equivalent to using .Text +=

            decimal totalCost = 0;                      // Running total of parcel shipping costs
            string NL = Environment.NewLine;            // Newline shorthand

            reportTxt.Clear(); // Clear the textbox
            reportTxt.AppendText("Parcels:");
            reportTxt.AppendText(NL); // Remember, \n doesn't always work in GUIs
            reportTxt.AppendText(NL);

            foreach (Parcel p in upv.ParcelList)
            {
                reportTxt.AppendText(p.ToString());
                reportTxt.AppendText(NL);
                reportTxt.AppendText("------------------------------");
                reportTxt.AppendText(NL);
                totalCost += p.CalcCost();
            }

            reportTxt.AppendText(NL);
            reportTxt.AppendText($"Total Cost: {totalCost:C}");

            // Put cursor at start of report
            reportTxt.Focus();
            reportTxt.SelectionStart = 0;
            reportTxt.SelectionLength = 0;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = DATA_FILE_FILTER;

                if (openFileDialog.ShowDialog() != DialogResult.OK) return; // Return early

                try
                {
                    var binFormatter = new BinaryFormatter();
                    var fs = File.Open(openFileDialog.FileName, FileMode.Open);
                    upv = binFormatter.Deserialize(fs) as UserParcelView;

                    if (upv is null)
                        MessageBox.Show("The loaded file did not contain any content or was corrupt!");
                    else
                        MessageBox.Show($"Loaded {upv.AddressCount} addresses and {upv.ParcelCount} parcels from file", "Loaded successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load due to a {ex.GetType().Name}. Reason: {ex.Message}", "Failed to Open");
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = DATA_FILE_FILTER;

                if (saveFileDialog.ShowDialog() != DialogResult.OK) return; // Return early

                try
                {
                    var binFormatter = new BinaryFormatter();
                    var fs = File.Create(saveFileDialog.FileName);
                    binFormatter.Serialize(fs, upv);

                    MessageBox.Show($"Saved to {saveFileDialog.FileName}", "Saved successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to save due to a {ex.GetType().Name}. Reason: {ex.Message}", "Failed to Save");
                }
            }
        }

        // Precondition:  Edit, Address menu item activated
        // Postcondition: The Address dialog box is displayed. If data entered
        //                are OK, an Address is modified and replaces the original in the list
        //                of addresses
        private void editAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var addressEditForm = new AddressEditForm(upv.AddressList))    // The address dialog box form
            {
                DialogResult result = addressEditForm.ShowDialog(); // Show form as dialog and store result

                if (result == DialogResult.OK) // Only add if OK
                {
                    if (int.TryParse(addressEditForm.ZipText, out int zip))
                    {
                        try
                        {
                            upv.EditAddress(addressEditForm.OriginalAddressName, addressEditForm.AddressName, addressEditForm.Address1,
                                addressEditForm.Address2, addressEditForm.City, addressEditForm.State,
                                zip); // Use form's properties to edit existing address
                        }
                        catch (ArgumentException ex)
                        {
                            ShowAddressValidationError(ex.Message);
                        }
                    }
                    else // This should never happen if form validation works!
                    {
                        ShowAddressValidationError();
                    }
                }
            }
        }

        private void ShowAddressValidationError(string message = null) => _ = string.IsNullOrWhiteSpace(message)
            ? MessageBox.Show("Problem with Address Validation!", "Validation Error")
            : MessageBox.Show(message, "Validation Error");
    }
}