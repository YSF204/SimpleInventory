using Simple_Inventory_Management_System;
class Program
{
    static void Main()
    {
        Inventory inventory = new Inventory();
        Menu menu = new Menu(inventory);

        menu.Run();
    }
}