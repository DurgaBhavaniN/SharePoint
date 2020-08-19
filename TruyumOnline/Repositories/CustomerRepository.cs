using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TruyumOnline.Models;

namespace TruyumOnline.Repositories
{
	public class CustomerRepository : ICustomerRepository
	{
		string connectionString = "Data Source = DESKTOP-0LBTHNR\\SQLEXPRESS; User ID =sa;password=pass@word1;Initial Catalog = TruYumOnline; Integrated Security = True; Trusted_Connection=True;";

		public void AddToCart(Items items)
		{
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("INSERT INTO Cart(ItemName,Price,Active,Category,FreeDelivery,ItemId) Values(@ItemName,@Price,@Active,@Category,@FreeDelivery,@ItemId)", con);
				cmd.Parameters.AddWithValue("@ItemName",items.ItemName);
				cmd.Parameters.AddWithValue("@Price", items.Price);
				cmd.Parameters.AddWithValue("@Active", items.Active);
				cmd.Parameters.AddWithValue("@Category", items.Category);
				cmd.Parameters.AddWithValue("@FreeDelivery", items.FreeDelivery);
				cmd.Parameters.AddWithValue("@ItemId", items.ItemId);
				con.Open();
				cmd.ExecuteNonQuery();
				con.Close();
			}
		}

		public void DeleteCartItem(int cartItemId)
		{
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("DELETE FROM Cart WHERE CartItemId=@CartItemId", con);
				cmd.Parameters.AddWithValue("@CartItemid",cartItemId);
				con.Open();
				cmd.ExecuteNonQuery();
				con.Close();
			}
		}

		public List<Items> GetAllItems()
		{
			List<Items> itemsList = new List<Items>();
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("select * from Items Where Active=@Active", con);
				cmd.Parameters.AddWithValue("@Active", "Yes");
				con.Open();
				SqlDataReader sdr = cmd.ExecuteReader();
				while (sdr.Read())
				{
					Items item = new Items();
					item.ItemId = Convert.ToInt32(sdr["ItemId"]);
					item.ItemName = sdr["ItemName"].ToString();
					item.Price = sdr["Price"].ToString();
					item.Active = sdr["Active"].ToString();
					item.Category = sdr["Category"].ToString();
					item.FreeDelivery = sdr["FreeDelivery"].ToString();
					itemsList.Add(item);
				}
				con.Close();
			}
			return itemsList;
		}

		public List<Cart> GetAllCartItems()
		{
			List<Cart> cartList = new List<Cart>();
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("select * from Cart", con);
				con.Open();
				SqlDataReader sdr = cmd.ExecuteReader();
				while (sdr.Read())
				{
					Cart cart = new Cart();
					cart.CartItemId = Convert.ToInt32(sdr["CartItemId"]);
					cart.ItemId = Convert.ToInt32(sdr["ItemId"]);
					cart.ItemName = sdr["ItemName"].ToString();
					cart.Price = sdr["Price"].ToString();
					cart.Active = sdr["Active"].ToString();
					cart.Category = sdr["Category"].ToString();
					cart.FreeDelivery = sdr["FreeDelivery"].ToString();
					cartList.Add(cart);
				}
				con.Close();
			}
			return cartList;
		}

		public Cart GetCartItem(int? cartItemId)
		{
			Cart cart = new Cart();
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				string sqlQuery = "SELECT * FROM Cart WHERE CartItemId= " + cartItemId;
				SqlCommand cmd = new SqlCommand(sqlQuery, con);
				con.Open();
				SqlDataReader sdr = cmd.ExecuteReader();
				while (sdr.Read())
				{
					cart.CartItemId = Convert.ToInt32(sdr["CartItemId"]);
					cart.ItemName = sdr["ItemName"].ToString();
					cart.Price = sdr["Price"].ToString();
					cart.Active = sdr["Active"].ToString();
					cart.Category = sdr["Category"].ToString();
					cart.FreeDelivery = sdr["FreeDelivery"].ToString();
					cart.ItemId = Convert.ToInt32(sdr["ItemId"]);
				}
				con.Close();
			}
			return cart;
		}

		public Items GetMenuItemById(int? itemId)
		{
			Items item = new Items();
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				string sqlQuery = "SELECT * FROM Items WHERE ItemId= " + itemId;
				SqlCommand cmd = new SqlCommand(sqlQuery, con);
				con.Open();
				SqlDataReader sdr = cmd.ExecuteReader();
				while (sdr.Read())
				{
					item.ItemId = Convert.ToInt32(sdr["ItemId"]);
					item.ItemName = sdr["ItemName"].ToString();
					item.Price = sdr["Price"].ToString();
					item.Active = sdr["Active"].ToString();
					item.Category = sdr["Category"].ToString();
					item.FreeDelivery = sdr["FreeDelivery"].ToString();
				}
				con.Close();
			}
			return item;
		}
	}
}
