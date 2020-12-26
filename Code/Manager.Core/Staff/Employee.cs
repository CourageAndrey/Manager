using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;

namespace Manager.Core.Staff
{
	public class Employee : INotifyPropertyChanged
	{
		private DateTime? _birthday;
		private IDictionary<ClassificationMethod, Class> _classification;

		public string Name
		{ get; set; }

		public DateTime? Birthday
		{
			get { return _birthday; }
			set
			{
				_birthday = value;
				raiseChanged(nameof(AgeString));
			}
		}

		public IDictionary<ClassificationMethod, Class> Classification
		{
			get { return _classification; }
			set
			{
				_classification = value;
				raiseChanged(nameof(ClassificationString));
			}
		}

		public string AgeString
		{
			get
			{
				if (Birthday.HasValue)
				{
					var age = DateTime.Now.Year - Birthday.Value.Year;
					if (DateTime.Now.DayOfYear < Birthday.Value.DayOfYear)
					{
						age--;
					}
					return age.ToString();
				}
				else
				{
					return string.Empty;
				}
			}
		}

		public string ClassificationString
		{
			get
			{
				return string.Join(", ", Classification.Where(@class => @class.Value != null).Select(@class => $"{@class.Key.Name}: {@class.Value.Name}"));
			}
		}

		public Employee()
		{
			Classification = ClassificationMethod.All.ToDictionary(
				method => method,
				method => null as Class);
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void raiseChanged(string propertyName)
		{
			var handler = Volatile.Read(ref PropertyChanged);
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
