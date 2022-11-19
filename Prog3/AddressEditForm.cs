﻿// Program 2
// CIS 200-76
// File: AddressEditForm.cs
// This class extends the Address dialog box form GUI. It performs validation
// and provides String properties for each field. This solution uses one
// event handler for all required text textboxes Validating events and one
// event handler for all controls Validated events.
// Additionally, it prepopulates fields from a selected address in a combobox.

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace UPVApp
{
    public partial class AddressEditForm : AddressForm
    {
        private readonly Dictionary<string, Address> _namedAddresses;

        /// <summary>
        /// Holds the original address name in case it is edited.
        /// This is important, because we use it as a key to find the original.
        /// </summary>
        public string OriginalAddressName { get; internal set; }

        // Precondition:  None
        // Postcondition: The form's GUI is prepared for display.
        public AddressEditForm(List<Address> addresses) : base()
        {
            InitializeComponent();

            _namedAddresses = addresses
                .ToDictionary(address => address.Name);

            addressComboBox.Items.AddRange(_namedAddresses
                .Select(namedAddresses => namedAddresses.Key)
                .ToArray());
        }

        protected override void RequiredTextFields_Validating(object sender, CancelEventArgs e)
        {
            if (ShouldValidate())
                base.RequiredTextFields_Validating(sender, e);
        }

        protected override void stateCbo_Validating(object sender, CancelEventArgs e)
        {
            if (ShouldValidate())
                base.stateCbo_Validating(sender, e);
        }

        protected override void zipTxt_Validating(object sender, CancelEventArgs e)
        {
            if (ShouldValidate())
                base.zipTxt_Validating(sender, e);
        }

        private bool ShouldValidate() => addressComboBox.SelectedIndex != -1;

        private void addressComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var address = _namedAddresses[(string)addressComboBox.SelectedItem];
            OriginalAddressName = address.Name;
            AddressName = address.Name;
            Address1 = address.Address1;
            Address2 = address.Address2;
            City = address.City;
            State = address.State;
            ZipText = address.Zip.ToString();
        }
    }
}
