using Domain.Interfaces.Services;
using System;

namespace Service
{
	public class MemberService : IMemberService
	{
		public string GetName(int memberID)
		{
			if (memberID == 1)
			{
				return "John";
			}
			else
			{
				return "NotExist";
			}
		}
	}
}
