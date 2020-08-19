using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruyumOnline.Models;

namespace TruyumOnline.Repositories
{
	public interface ICustomerRepository
	{
		public List<Items> GetAllItems();
		public void AddToCart(Items item);
		public Items GetMenuItemById(int? itemId);
		public List<Cart> GetAllCartItems();
		public Cart GetCartItem(int? cartItemId);
		public void DeleteCartItem(int cartItemId);
	}
}
