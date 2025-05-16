using LINQ_Task.Data;
using LINQ_Task.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LINQ_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new ApplicationDbContext();

            //1-List all customers' first and last names along with their email addresses.
            /*var CustomersNameMail = context.Customers.Select(e => new
            {
                FullName = e.FirstName + ' ' + e.LastName,
                Email = e.Email
            });
            foreach (var item in CustomersNameMail)
            {
                Console.WriteLine($"Full Name: {item.FullName} E-mail:{item.Email}");
            }*/

            //2- Retrieve all orders processed by a specific staff member (e.g., staff_id = 3)
            /*var OrdersId3 = context.Orders.Where(e => e.StaffId == 3);
            foreach (var item in OrdersId3)
            {
                Console.WriteLine($"{item.OrderId}");
            }*/

            //3- Get all products that belong to a category named "Mountain Bikes".
            /*var MountainBikes = context.Products.Where(e => e.Category.CategoryName == "Mountain Bikes");
            foreach (var item in MountainBikes)
            {
                Console.WriteLine($"{item.ProductName}");
            }*/

            //4-Count the total number of orders per store.
            /*var orders = context.Stores.Select(e => new
            {
                Name=e.StoreName,
                Id=e.StoreId,
                Count=e.Orders.Count()
            });
            foreach (var item in orders)
            {
                Console.WriteLine($"{item.Name} : {item.Id} has {item.Count} orders");
            }*/

            //5- List all orders that have not been shipped yet (shipped_date is null).
            /*var NonShippedOrders = context.Orders.Where(e => e.ShippedDate == null);
            foreach (var item in NonShippedOrders)
            {
                Console.WriteLine($"Order {item.OrderId}");
            }*/

            //6- Display each customer’s full name and the number of orders they have placed.
            /*var Customers = context.Customers.Select(e => new {
                FullName=$"{e.FirstName} {e.LastName}",
                Id=e.CustomerId,
                Count=e.Orders.Count });
            foreach (var item in Customers)
            {
                Console.WriteLine($"{item.FullName} : {item.Id} -------------> {item.Count}");
            }*/

            //7- List all products that have never been ordered (not found in order_items).
            /*var NonOrderedProducts = context.Products.Where(e => e.OrderItems.Count == 0);
            foreach (var item in NonOrderedProducts)
            {
                Console.WriteLine($"{item.ProductId}");
            }*/

            //8- Display products that have a quantity of less than 5 in any store stock.
            /*var Products = context.Stocks.Where(e => e.Quantity < 5).Select(e=>e.ProductId).Distinct();
            foreach (var item in Products)
            {
                Console.WriteLine($"{item}");
            }*/

            //9- Retrieve the first product from the products table.
            /*var product = context.Products.Select(e=>e.ProductName).First();
            Console.WriteLine(product);*/

            //10- Retrieve all products from the products table with a certain model year.
            //Certain means that it has a model year, so returning products with model year !?
            /*var products = context.Products.Where(e => e.ModelYear != null).Select(e => new 
            { 
                ProductId=e.ProductId,
                ModelYear=e.ModelYear
            });
            foreach (var item in products)
            {
                Console.WriteLine(item);
            }*/

            //11- Display each product with the number of times it was ordered.
            //Considering this means: The number of orders each product was in (Count not Summing Quantity)
            /*var products = context.Products.Select(e => new {
                Id = e.ProductId,
                Count = e.OrderItems.Count()
            });
            foreach (var item in products)
            {
                Console.WriteLine($"Id: {item.Id}----------> {item.Count}");
            }*/

            //12- Count the number of products in a specific category.
            //Answer (1)
            /*var products = context.Products.GroupBy(e => e.CategoryId).Select(e => new
            {
                Category = e.Key,
                Count = e.Count()
            });
            foreach (var item in products)
            {
                Console.WriteLine(item);
            }*/
            //Answer (2)
            /*var p = context.Categories.Select(e => e.Products.Count());
            foreach (var item in p)
            {
                Console.WriteLine(item);
            }*/

            //13- Calculate the average list price of products.
            /*var Avg = context.Products.Average(e => e.ListPrice);
            Console.WriteLine(Avg);*/

            //14- Retrieve a specific product from the products table by ID
            /*var p = context.Products.First(e=>e.ProductId==1);
            Console.WriteLine(p.ProductName);
            var p2 = context.Products.Single(e => e.ProductId == 1);
            Console.WriteLine(p2.ProductName);*/

            //15- List all products that were ordered with a quantity greater than 3 in any order.
            /*var OrderItems = context.OrderItems.Where(e => e.Quantity>3).Select(e => new
            {
                ProductId=e.ProductId,
            }).Distinct();
            foreach (var item in OrderItems)
            {
                Console.WriteLine(item.ProductId);
            }*/

            //16- Display each staff member’s name and how many orders they processed
            /*var staffs = context.Orders.Join(
                context.Staffs,
                o=>o.StaffId,
                s=>s.StaffId,
                (o,s)=>new
                {
                    StaffName=s.FirstName,
                    StaffId=s.StaffId
                }
                ).GroupBy(s => new {s.StaffId,s.StaffName}).Select(e => new
                {
                    Name=e.Key,
                    Count=e.Count()
                });
            foreach (var item in staffs)
            {
                Console.WriteLine($"Name: {item.Name.StaffName} Id: {item.Name.StaffId} Number of Orders: {item.Count}" );
            }*/

            //17- List active staff members only (active = true) along with their phone numbers.
            /*var staff = context.Staffs.Where(e => e.Active == 1).Select(e => new
            {
                Name=e.FirstName,
                Phone=e.Phone
            });

            foreach (var item in staff)
            {
                Console.WriteLine($"{item.Name} ------------------> {item.Phone}");
            }*/

            //18- List all products with their brand name and category name.
            /*var products = context.Products.Select(e => new
            {
                e.ProductName,
                e.Brand.BrandName,
                e.Category.CategoryName
            });
            foreach (var item in products)
            {
                Console.WriteLine($"{item.ProductName}---->{item.CategoryName}----->{item.BrandName}");
            }*/

            //19- Retrieve orders that are completed.
            /*var orders = context.Orders.Where(e => e.OrderStatus == 3);
            foreach (var item in orders)
            {
                Console.WriteLine($"Order: {item.OrderId}");
            }*/

            //20 - List each product with the total quantity sold(sum of quantity from order_items).
            /*var a = context.OrderItems.GroupBy(e => new {e.ProductId,e.Product.ProductName}).Select(e => new
            {
                Name=e.Key.ProductName,
                Id=e.Key.ProductId,
                Total=e.Sum(e=>e.Quantity)
            });
            foreach (var item in a)
            {
                Console.WriteLine($"{item.Name} : {item.Id} ------> {item.Total}");
            }*/

            //2nd approach is better as it returns products with 0 quantity, 
            //while 1st approach doesn't because if the product's quantity is 0 means it
            //wasn't ordered so it isn't in OrderItems at which we start our query, so 
            //Quantity 0 products doesn't appear
            /*var products = context.Products.Select(p => new {
                Name=p.ProductName,
                Id=p.ProductId,
                Total=p.OrderItems.Sum(o=>o.Quantity)
            });
            foreach (var item in products)
            {
                Console.WriteLine($"{item.Name} :  {item.Id}  ------> {item.Total}");
            }*/
        }
    }
}
