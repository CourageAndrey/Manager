using System;
using System.Windows;

namespace Manager.UI.Dialogs
{
	public partial class SelectDateDialog
	{
		public SelectDateDialog()
		{
			InitializeComponent();
		}

		public DateTime? SelectedDate
		{
			get { return _datePicker.SelectedDate; }
			set { _datePicker.SelectedDate = value; }
		}

		private void buttonOkClick(object sender, RoutedEventArgs e)
		{
			DialogResult = true;
		}

		private void buttonCancelClick(object sender, RoutedEventArgs e)
		{
			DialogResult = false;
		}
	}
}
