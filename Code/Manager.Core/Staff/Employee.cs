using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manager.Core.Staff
{
	public class Employee
	{
		public string Name
		{ get; set; }

		public DateTime? Birthday
		{ get; set; }

		public IDictionary<ClassificationMethod, Class> Classification
		{ get; } = new Dictionary<ClassificationMethod, Class>();

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
				return string.Join(", ", Classification.Select(@class => $"{@class.Key.Name}: {@class.Value.Name}"));
			}
		}
	}
}
