using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

using Manager.Core.Staff;
using Manager.UI.Dialogs;

namespace Manager.UI
{
	public partial class MainWindow
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void mainWindowLoaded(object sender, RoutedEventArgs e)
		{
			var testEmployee = new Employee
			{
				Name = "Тест",
				Birthday = new DateTime(1987, 03, 12),
			};
			testEmployee.Classification[ClassificationMethod.Adizes] = ClassificationMethod.Adizes.Classes.First();
			//testEmployee.Classification[ClassificationMethod.Disk] = ClassificationMethod.Disk.Classes.First();
			//testEmployee.Classification[ClassificationMethod.Litvak] = ClassificationMethod.Litvak.Classes.First();
			testEmployee.Classification[ClassificationMethod.SevenRadicals] = ClassificationMethod.SevenRadicals.Classes.First();

			_gridEmployees.ItemsSource = new List<Employee>
			{
				testEmployee,
			};

		}

		private void editAgeClick(object sender, RoutedEventArgs e)
		{
			var row = getActiveRow(sender);
			var employee = row.DataContext as Employee;
			if (employee != null)
			{
				var dialog = new SelectDateDialog
				{
					Owner = this,
					SelectedDate = employee.Birthday,
				};
				if (dialog.ShowDialog() == true)
				{
					employee.Birthday = dialog.SelectedDate;
				}
			}
		}

		private void editClassificationClick(object sender, RoutedEventArgs e)
		{
			var row = getActiveRow(sender);
			var employee = row.DataContext as Employee;
			if (employee != null)
			{
				var dialog = new EditClassificationDialog
				{
					Owner = this,
					Classification = employee.Classification,
				};
				if (dialog.ShowDialog() == true)
				{
					employee.Classification = dialog.Classification;
				}
			}
		}

		private static DataGridRow getActiveRow(object sender)
		{
			for (var visual = sender as Visual; visual != null; visual = VisualTreeHelper.GetParent(visual) as Visual)
			{
				var row = visual as DataGridRow;
				if (row != null)
				{
					return row;
				}
			}
			return null;
		}
	}
}
