using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TruyumOnline.Models;

namespace TruyumOnline.Repositories
{
	public class AdminRepository : IAdminRepository
	{
		string connectionString= "Data Source = DESKTOP-0LBTHNR\\SQLEXPRESS; User ID =sa;password=pass@word1;Initial Catalog = TruYumOnline; Integrated Security = True; Trusted_Connection=True;";
		public void AddMenuItems(Items items)
		{
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("INSERT INTO Items(ItemName,Price,Active,Category,FreeDelivery) Values(@ItemName,@Price,@Active,@Category,@FreeDelivery)", con);
				cmd.Parameters.AddWithValue("@ItemName",items.ItemName);
				cmd.Parameters.AddWithValue("@Price",items.Price);
				cmd.Parameters.AddWithValue("@Active", items.Active);
				cmd.Parameters.AddWithValue("@Category", items.Category);
				cmd.Parameters.AddWithValue("@FreeDelivery", items.FreeDelivery);
				con.Open();
				cmd.ExecuteNonQuery();
				con.Close();
			}
		}
		public void DeleteMenuItem(int itemId)
		{
			using(SqlConnection con=new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("DELETE FROM Items WHERE ItemId=@ItemId", con);
				cmd.Parameters.AddWithValue("@Itemid",itemId);
				con.Open();
				cmd.ExecuteNonQuery();
				con.Close();
			}
		}
		public Items GetMenuItemById(int? itemId)
		{
			Items item = new Items();
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				string sqlQuery = "SELECT * FROM Items WHERE ItemId= " + itemId;
				SqlCommand cmd = new SqlCommand(sqlQuery,con);
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
		public List<Items> GetMenuItems()
		{
			List<Items> itemsList = new List<Items>();
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("select * from Items", con);
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

		public void ModifyMenuItems(Items items)
		{
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("UPDATE Items SET ItemName=@ItemName,Price=@Price,Active=@Active,Category=@Category,FreeDelivery=@FreeDelivery WHERE ItemId=@ItemId", con);
				cmd.Parameters.AddWithValue("@ItemId", items.ItemId);
				cmd.Parameters.AddWithValue("@ItemName", items.ItemName);
				cmd.Parameters.AddWithValue("@Price", items.Price);
				cmd.Parameters.AddWithValue("@Active", items.Active);
				cmd.Parameters.AddWithValue("@Category", items.Category);
				cmd.Parameters.AddWithValue("@FreeDelivery", items.FreeDelivery);
				con.Open();
				cmd.ExecuteNonQuery();
				con.Close();
			}

		}
	}
}
