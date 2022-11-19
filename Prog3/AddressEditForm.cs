// Program 2
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
        private bool _isEditable = true;
        /// <summary>
        /// Holds the original address name in case it is edited.
        /// This is important, because we use it as a key to find the original.
        /// </summary>
        public string OriginalAddressName { get; internal set; }

        // Precondition:  Must be provided an instance of addresses, can be null or empty.
        // Postcondition: The form's GUI is prepared for display.
        public AddressEditForm(List<Address> addresses) : base()
        {
            InitializeComponent();

            ToggleTextEditableInputs();

            if (addresses is null || !addresses.Any()) return;

            _namedAddresses = addresses
                .ToDictionary(address => address.Name);

            addressComboBox.Items.AddRange(_namedAddresses
                .Select(namedAddresses => namedAddresses.Key)
                .ToArray());
        }

        /// <summary>
        /// Toggles the Enabled status on most editable fields and Ok button in form.
        /// </summary>
        private void ToggleTextEditableInputs()
        {
            _isEditable = !_isEditable;

            nameTxt.Enabled = _isEditable;
            address1Txt.Enabled = _isEditable;
            address2Txt.Enabled = _isEditable;
            cityTxt.Enabled = _isEditable;
            stateCbo.Enabled = _isEditable;
            zipTxt.Enabled = _isEditable;
            okBtn.Enabled = _isEditable;
        }

        /// <summary>
        /// Overrides the original inherited behavior to prevent validation if no selected address.
        /// </summary>
        protected override void RequiredTextFields_Validating(object sender, CancelEventArgs e)
        {
            if (_isEditable)
                base.RequiredTextFields_Validating(sender, e);
        }

        /// <summary>
        /// Overrides the original inherited behavior to prevent validation if no selected address.
        /// </summary>
        protected override void stateCbo_Validating(object sender, CancelEventArgs e)
        {
            if (_isEditable)
                base.stateCbo_Validating(sender, e);
        }

        /// <summary>
        /// Overrides the original inherited behavior to prevent validation if no selected address.
        /// </summary>
        protected override void zipTxt_Validating(object sender, CancelEventArgs e)
        {
            if (_isEditable)
                base.zipTxt_Validating(sender, e);
        }

        /// <summary>
        /// When the address index changes, make UI editable and load values into text boxes, while storing original name (key).
        /// </summary>
        private void addressComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (!_isEditable)
                ToggleTextEditableInputs();

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
