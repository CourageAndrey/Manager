using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

using Manager.Core.Staff;

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
			gridEmployees.ItemsSource = new List<Employee>
			{
				new Employee
				{
					Name = "Тест",
					Birthday = new DateTime(1987, 03, 12),
					Classification =
					{
						{ ClassificationMethod.Adizes, ClassificationMethod.Adizes.Classes.First() },
						{ ClassificationMethod.Disk, ClassificationMethod.Disk.Classes.First() },
						{ ClassificationMethod.Litvak, ClassificationMethod.Litvak.Classes.First() },
						{ ClassificationMethod.SevenRadicals, ClassificationMethod.SevenRadicals.Classes.First() },
					},
				},
			};
		}
	}
}
