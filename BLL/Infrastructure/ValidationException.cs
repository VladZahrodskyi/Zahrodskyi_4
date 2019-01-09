using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Infrastructure
{
	public class ValidationException : Exception
	{
		
		public string Property { get; protected set; }
		public ValidationException(string message, Exception innerException, string prop) : base(message, innerException)
		{
			Property = prop;
		}
		public ValidationException(string message, string prop) : base(message)
		{
			Property = prop;
		}
	}
}
