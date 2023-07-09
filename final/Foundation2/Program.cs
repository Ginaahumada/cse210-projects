using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Order #1\n");
        Customer firstCustomer = new Customer("Gina Ahumada", "Jaime Roldos", "Quevedo", "Los Rios", "Ecuador");
        Order firstOrder = new Order(firstCustomer);
        firstOrder.AddProduct("Box Potato", "T01", 5.0, 2);
        firstOrder.AddProduct("Cheetos", "Ch01", 0.25, 5);
        firstOrder.ComputeSubTotalPrice();
        Console.WriteLine(firstOrder.GetPackingLabel());
        Console.WriteLine(firstOrder.GetShippingLabel());
        firstOrder.DisplayTotalCost();

        Console.WriteLine("\nOrder #2\n");
        Customer secondCustomer = new Customer("Emmy Toala", "Sprigfield street", "San Diego", "California", "USA");
        Order secondOrder = new Order(secondCustomer);
        secondOrder.AddProduct("Watermelo Juice", "W01", 1.0, 16);
        secondOrder.AddProduct("Taquis", "TT01", 0.50, 60);
        secondOrder.AddProduct("Jolly Rancher", "JR01", 0.70, 19);
        secondOrder.ComputeSubTotalPrice();
        Console.WriteLine(secondOrder.GetPackingLabel());
        Console.WriteLine(secondOrder.GetShippingLabel());
        secondOrder.DisplayTotalCost();


    }
}