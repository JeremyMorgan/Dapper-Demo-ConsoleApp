using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DapperDemo
{
	class Program
	{
		static void Main(string[] args)
		{
			IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

			string SqlString = "SELECT TOP 100 [CustomerID],[CustomerFirstName],[CustomerLastName],[IsActive] FROM [Customer]";

			var ourCustomers = (List<Customer>)db.Query<Customer>(SqlString);

			foreach (var Customer in ourCustomers)
			{
				Console.WriteLine(new string('*', 20));
				Console.WriteLine("\nCustomer ID: " + Customer.CustomerID.ToString());
				Console.WriteLine("First Name: " + Customer.CustomerFirstName);
				Console.WriteLine("Last Name: " + Customer.CustomerLastName);
				Console.WriteLine("Is Active? " + Customer.IsActive + "\n");
				Console.WriteLine(new string('*', 20));
			}

			Console.ReadLine();

		}
	}
}
