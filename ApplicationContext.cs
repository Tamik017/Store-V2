using Microsoft.EntityFrameworkCore;
using Store.Model;
using Store.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Store
{
    public class ApplicationContext: DbContext
    {
        DbSet<Suppliers> _suppliers {  get; set; }
        public List<Suppliers> GetSuppliers()
        {
            List<Suppliers> suppliers = _suppliers.ToList();

            return suppliers;
        }

        DbSet<Products> _products { get; set; }
        public List<Products> GetProducts()
        {
            List <Products> products = _products.ToList();
            foreach (var item in products)
            {
                Entry(item).Reference(p => p.Поставщик).Load();
            }
            foreach (var item in products)
            {
                Entry(item).Reference(p => p.Категория).Load();
            }
            return products;
        }

        public DbSet<Rating> _rating { get; set; }
        public List<Rating> GetRatings()
        {
            List<Rating> rating = _rating.ToList();
            return rating;
        }

        public DbSet<Categories> _categories { get; set; }
        public List<Categories> GetCategories()
        {
            List<Categories> categories = _categories.ToList();
            return categories;
        }

        public DbSet<Employees> _employees { get; set; }
        public List<Employees> GetEmployees()
        {
            List<Employees> employees = _employees.ToList();

            return employees;
        }
        public DbSet<Orders> _orders {  get; set; }
        public DbSet<OrderElements> _orderElements { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=TAMIK17; Database=store; TrustServerCertificate=True; Trusted_Connection=True;");
        }
    }
}
