using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using Manager.Core.Staff;

namespace Manager.UI.Dialogs
{
	public partial class EditClassificationDialog
	{
		public EditClassificationDialog()
		{
			InitializeComponent();
		}

		public IDictionary<ClassificationMethod, Class> Classification
		{
			get
			{
				return _classificationGrid.Children.OfType<ComboBox>().ToDictionary(
					comboBox => comboBox.Tag as ClassificationMethod,
					comboBox => comboBox.SelectedItem as Class);
			}
			set
			{
				_classificationGrid.RowDefinitions.Clear();
				_classificationGrid.Children.Clear();
				int rowNumber = 0;
				foreach (var @class in value)
				{
					var row = new RowDefinition { Height = GridLength.Auto };
					_classificationGrid.RowDefinitions.Add(row);

					var titleControl = new TextBlock
					{
						Text = @class.Key.Name,
						Margin = new Thickness(5, 2, 5, 2),
					};
					titleControl.SetValue(Grid.RowProperty, rowNumber);
					titleControl.SetValue(Grid.ColumnProperty, 0);
					_classificationGrid.Children.Add(titleControl);

					var valueControl = new ComboBox
					{
						Margin = new Thickness(1),
						Tag = @class.Key,
						ItemsSource = @class.Key.Classes,
						SelectedItem = @class.Value,
					};
					valueControl.SetValue(Grid.RowProperty, rowNumber);
					valueControl.SetValue(Grid.ColumnProperty, 1);
					_classificationGrid.Children.Add(valueControl);

					rowNumber++;
				}
			}
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
