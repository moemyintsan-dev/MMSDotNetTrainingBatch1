﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MMSDotNetTrainingBatch1.ConsoleApp;

namespace MMSDotNetTrainingBatch1.ConsoleApp
{
    internal class InventoryService
    {
        public void CreateProduct()
        {
            Console.Write("Input Product Name:");
            string productName = Console.ReadLine()!;

        BeforePrice:
            Console.Write("Input Product Price:");
            string priceResult = Console.ReadLine();
            decimal price = 0;
            bool isdecimal = decimal.TryParse(priceResult, out price);
            if (!isdecimal)
            {
                Console.WriteLine("Invalid Price");
                goto BeforePrice;
            }


        BeforeQuantity:
            Console.Write("Input Product Quantity:");
            string quantityResult = Console.ReadLine();
            int quantity = 0;
            bool isint = int.TryParse(quantityResult, out quantity);
            if (!isint)
            {
                Console.WriteLine("Invalid Quantity");
                goto BeforeQuantity;
            }

            Data.ProductId++;

            string productCode = "P" + Data.ProductId.ToString().PadLeft(3, '0');

            Product product = new Product(Data.ProductId, productCode, productName, price, quantity, "Fruit");
            Data.Products.Add(product);

            Console.WriteLine("Product Insert Successfully");
        }

        public void ViewProducts()
        {
            Console.WriteLine("Product List");
            foreach (var product in Data.Products)
            {
                Console.WriteLine($"Id: {product.Id}, Code{product.Code}, Name{product.Name}, Price{product.Price}, Quantity{product.Quantity}, Category{product.Category}");
            }

        }

        public void UpdateProduct()
        {
        BeforeProductCode:
            Console.Write("Input Product Code: ");
            string code = Console.ReadLine();
            var product = Data.Products.FirstOrDefault(product => product.Code == code);
            if (product is null)
            {
                Console.WriteLine("Product Not Found.");
                goto BeforeProductCode;
            }
            Console.WriteLine("Product Found. ");
            Console.WriteLine($"Code{product.Code}, Name{product.Name}, Quantity{product.Quantity}");

        BeforeInputQuantity:
            Console.Write("Input Quantity: ");
            string quantityResult = Console.ReadLine();
            int quantity = 0;
            bool isInt = int.TryParse(quantityResult, out quantity);
            if (!isInt)
            {
                Console.WriteLine("Invalid Quantity.");
                goto BeforeInputQuantity;
            }
            //product.Quantity = product.Quantity - quantity;
            product.Quantity -= quantity;
            Console.WriteLine("Product Updated Successfully. ");

        }
        public void DeleteProduct()
        {
        BeforeProductCode:
            Console.Write("Input Product Code: ");
            string code = Console.ReadLine();
            var product = Data.Products.FirstOrDefault(product => product.Code == code);
            if (product is null)
            {
                Console.WriteLine("Product Not Found.");
                goto BeforeProductCode;
            }
            Console.WriteLine("Product Found. ");
            Console.WriteLine($"Code{product.Code}, Name{product.Name}, Quantity{product.Quantity}");

            Console.WriteLine("Are you sure want to delete? (Y/N) ");
            string confirm = Console.ReadLine();
            if (confirm.ToUpper() == "Y")
            {
                Data.Products.Remove(product);
                Console.WriteLine("Product Deleted Successfully");
            } 

            else
            {
                Console.WriteLine("Product Not Deleted");
            
            }
        }
    }
}

        
    


        









           