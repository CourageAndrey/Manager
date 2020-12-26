namespace Manager.Core.Staff
{
	public class Class
	{
		public string Name
		{ get; }

		public string Description
		{ get; }

		internal Class(string name, string description)
		{
			Name = name;
			Description = description;
		}
	}
}
