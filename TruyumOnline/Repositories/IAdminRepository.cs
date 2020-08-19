using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruyumOnline.Models;

namespace TruyumOnline.Repositories
{
	public interface IAdminRepository
	{
		public List<Items> GetMenuItems();
		public void AddMenuItems(Items items);
		public void ModifyMenuItems(Items items);
		public void DeleteMenuItem(int itemId);
		public Items GetMenuItemById(int? itemId);
	}
}
