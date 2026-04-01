using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Mabini St", "Manila", "NCR", "Philippines");
        Address address2 = new Address("456 Bonifacio Blvd", "Cebu City", "Cebu", "Philippines");

        Customer customer1 = new Customer("Juan Dela Cruz", address1);
        Customer customer2 = new Customer("Maria Santos", address2);

        Product product1 = new Product("Laptop", "LP1001", 50000, 1);
        Product product2 = new Product("Mouse", "MS2002", 1500, 2);
        Product product3 = new Product("Keyboard", "KB3003", 2500, 1);
        Product product4 = new Product("Monitor", "MN4004", 12000, 2);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ₱{order1.CalculateTotal():0.00}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ₱{order2.CalculateTotal():0.00}\n");
    }
}