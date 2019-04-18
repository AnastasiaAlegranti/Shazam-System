using System;

namespace Anastasia
{
	public class BaseLogic:IDisposable
	{
		protected ShazamEntities DB = new ShazamEntities();

		public void Dispose()
		{
			DB.Dispose();
		}
	}
}
