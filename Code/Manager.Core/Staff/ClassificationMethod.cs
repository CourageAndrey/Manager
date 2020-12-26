using System.Collections.Generic;
using System.Linq;

namespace Manager.Core.Staff
{
	public class ClassificationMethod
	{
		public string Name
		{ get; }

		public IReadOnlyCollection<Class> Classes
		{ get; }

		private ClassificationMethod(string name, IEnumerable<Class> classes)
		{
			Name = name;
			Classes = classes.ToArray();
		}

		#region List

		public static readonly ClassificationMethod Litvak = new ClassificationMethod("по Литваку", new []
		{
			new Class("Карьерист"),
			new Class("Культурник"),
			new Class("Алкоголик"),
		});

		public static readonly ClassificationMethod Adizes = new ClassificationMethod("по Адизесу", new[]
		{
			new Class("P Производитель"),
			new Class("A Администратор"),
			new Class("E Предприниматель"),
			new Class("I Интегратор"),
		});

		public static readonly ClassificationMethod Disk = new ClassificationMethod("по DISC", new[]
		{
			new Class("Синий"),
			new Class("Зелёный"),
			new Class("Красный"),
			new Class("Жёлтый"),
		});

		public static readonly ClassificationMethod SevenRadicals = new ClassificationMethod("7 радикалов", new[]
		{
			new Class("Яркий"),
			new Class("Атлетичный"),
			new Class("Классический"),
			new Class("Гармоничный"),
			new Class("Необычный"),
			new Class("Хипстер"),
			new Class("Невзрачный"),
		});

		public static readonly IReadOnlyCollection<ClassificationMethod> All = new []
		{
			Litvak,
			Adizes,
			Disk,
			SevenRadicals,
		};

		#endregion
	}
}
