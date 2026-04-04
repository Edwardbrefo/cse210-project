using System;
using System.Collections.Generic;
using System.Net.Sockets;

public class Product
{
    private string _name;
    private double _price;
    private string _productId;
    private int _quantity;
    public Product(string name, double price, string productId, int quantity)
    {
        _name = name;
        _price = price;
        _productId = productId;
        _quantity = quantity;
    }
    public double GetTotalPrice()
    {
        return _price * _quantity;
    }
    public string GetName()
    {
        return _name;
    }
    public string GetProductId()
    {
        return _productId;
    }
}

 public class Customer
{
    private string _name;
    private Address _address;
    public Customer (string name, Address address)
    {
        _name = name;
        _address = address;
    }
    public string GetName()
    {
        return _name;
    }
    public Address GetAddress()
    {
        return _address;
    }
    
    
}  
public class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool IsInUSA()
    {
        return _country.ToLower() == "usa";
    }
    public string GetFullAddress()
    {
        return $"{_street}, {_city}, {_state}, {_country}";
    }
}
    class Order
    {
    private Customer _customer;
    private List<Product> _products = new List<Product>();

    public Order(Customer customer)
    {
        _customer = customer;
    }
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }
        public double GetTotalPrice()
            {
                double subTotal = 0;
                foreach (Product product in _products)
                {                   
                     subTotal += product.GetTotalPrice();
                }
                return subTotal + GetShippingCost();

            }
        public double GetShippingCost()
        {
            if (_customer.GetAddress().IsInUSA())
            {
                return 5.00;
            }
            else
            {
                return 35.00;
            }
        }  
        public void GetPackingLabel()
        {
            Console.WriteLine("Packing Label:");
            foreach (Product product in _products)
            {
                Console.WriteLine($"Product Name: {product.GetName()}, Product ID: {product.GetProductId()}");
            }
        }
        public void GetShippingLabel()
        {
            Console.WriteLine("Shipping Label:");
            Console.WriteLine($"Customer Name: {_customer.GetName()}");
            Console.WriteLine($"Customer Address: {_customer.GetAddress().GetFullAddress()}");
        }
        
        
    }

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");
        Console.WriteLine("");

        Address address1 = new Address("123 Main St", "Accra", "Greater Accra", "Ghana");
        Address address2 = new Address("456 Elm St", "New York", "NY", "USA");

        Customer customer1 = new Customer("Kwame Boye", address1);
        Customer customer2 = new Customer("Nana Ama", address2);

        Product product1 = new Product("Laptop", 999.99, "P001", 1);
        Product product2 = new Product("Smartphone", 499.99, "P002", 2);
        Product product3 = new Product("Headphones", 199.99, "P003", 1);
        Product product4 = new Product("Camera", 299.99, "P004", 3);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        Order order2 = new Order(customer2);
        order2.AddProduct(product2);
        order2.AddProduct(product4);

        Console.WriteLine("Order 1:");
        order1.GetPackingLabel();
        order1.GetShippingLabel();
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice()}");
        Console.WriteLine("");

        Console.WriteLine("Order 2:");
        order2.GetPackingLabel();
        order2.GetShippingLabel();
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice()}");
        Console.WriteLine("");
    

        



    }
}