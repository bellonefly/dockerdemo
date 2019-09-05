using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Services
{
	public interface IMemberService
	{
		string GetName(int memberID);
	}
}
