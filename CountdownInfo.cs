using System;
namespace Retirement
{
	public class CountdownInfo
	{
		public CountdownInfo()
		{
		}
        public string Days { get; set; }

        public string Hours { get; set; }

        public string Minutes { get; set; }

        public string Seconds { get; set; }

        public string Title { get; set; }

        public override string ToString()
        {
            return $"{this.Days}\r\n{this.Hours}\r\n{this.Minutes}\r\n{this.Seconds}";
        }
    }
}

