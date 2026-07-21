using System;

public class BankAccount
{
    public int AccountNumber { get; set; }
    public string HolderName { get; set; }
    public double Balance { get; set; }

    public bool IsOverdrawn => Balance < 0;

    public BankAccount() { }
    public BankAccount(int accNum, string name, double balance)
    {
        AccountNumber = accNum;
        HolderName = name;
        Balance = balance;
    }
    public void Deposit(double amount)
    {
        Balance += amount;
        SendEmail();
    }
    public void Withdraw(double amount)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
            SendEmail();
        }
    }
    public double CheckBalance()
    {
        PrintInformation();
        return Balance;
    }
    private void PrintInformation()
    {
        Console.WriteLine($"Holder: {HolderName}, Balance: {Balance}");
    }

    private void SendEmail() { }
}
public class Student
{
    public int Grade { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    private string email;
    private int age;
    public static int StudentCount = 0;
    public static int GetTotalStudents() => StudentCount;
    private string pin;
    public string Pin { set => pin = value; }
    public Student()
    {
        StudentCount++;
    }
    public void Register(string Email)
    {
        this.email = Email;
        SendEmail();
    }
    private void SendEmail() { }
}
public class Product
{
    public string ProductName { get; set; }
    public double Price { get; set; }
    public int StockQuantity { get; set; }
    public void Sell(int quantity)
    {
        if (StockQuantity >= quantity)
        {
            StockQuantity -= quantity;
        }
        else
        {
            Console.WriteLine("not enough stock");
        }
        LogTransaction();
    }
    public void Restock(int quantity)
    {
        StockQuantity += quantity;
        LogTransaction();
    }
    public double GetInventoryValue()
    {
        PrintDetails();
        return Price * StockQuantity;
    }
    private void PrintDetails()
    {
        Console.WriteLine($"Product: {ProductName}, Price: {Price}, Stock: {StockQuantity}");
    }
    private void LogTransaction() { }
}
class Program
{
    static void Main(string[] args)
    {
        BankAccount account1 = new BankAccount { AccountNumber = 1163, HolderName = "karim", Balance = 120 };
        BankAccount account2 = new BankAccount { AccountNumber = 15203, HolderName = "Ali", Balance = 63 };
        Student student1 = new Student { Name = "Ali", Address = "Muscat", Grade = 65 };
        Student student2 = new Student { Name = "Ahmed", Address = "Muscat", Grade = 70 };
        Product product1 = new Product { ProductName = "Wireless Mouse", Price = 5.500, StockQuantity = 50 };
        Product product2 = new Product { ProductName = "Mechanical Keyboard", Price = 15.750, StockQuantity = 20 };
        bool running = true;
        while (running)
        {
            Console.WriteLine("\nMENU");
            Console.WriteLine("1. View Details  2. Update Address  3. Deposit  4. Withdraw  5. Product Details");
            Console.WriteLine("6. Register Std  7. Compare Accs  8. Restock  9. Transfer  10. Update Grade");
            Console.WriteLine("11. Report Card  12. Acc Status  13. Bulk Sale  14. Scholarship  15. Top-Up");
            Console.WriteLine("16. New Acc Constructor  17. Total Students  18. Overdrawn Check  19. Set Student PIN  20. Exit");
            Console.Write("Choice: ");
            if (!int.TryParse(Console.ReadLine(), out int choice)) continue;
            switch (choice)
            {
                case 1:
                    Console.Write("Pick Account (1 or 2): ");
                    BankAccount selAcc1 = (int.Parse(Console.ReadLine()) == 1) ? account1 : account2;
                    selAcc1.CheckBalance();
                    break;
                case 2:
                    Console.Write("Pick Student (1 or 2): ");
                    Student selStd2 = (int.Parse(Console.ReadLine()) == 1) ? student1 : student2;
                    Console.Write("New address: ");
                    selStd2.Address = Console.ReadLine();
                    Console.WriteLine($"Updated: {selStd2.Address}");
                    break;
                case 3:
                    Console.Write("Pick Account (1 or 2): ");
                    BankAccount selAcc3 = (int.Parse(Console.ReadLine()) == 1) ? account1 : account2;
                    Console.Write("Amount: ");
                    selAcc3.Deposit(double.Parse(Console.ReadLine()));
                    Console.WriteLine($"Holder: {selAcc3.HolderName}, Balance: {selAcc3.Balance}");
                    break;
                case 4:
                    Console.Write("Pick Account (1 or 2): ");
                    BankAccount selAcc4 = (int.Parse(Console.ReadLine()) == 1) ? account1 : account2;
                    Console.Write("Amount: ");
                    selAcc4.Withdraw(double.Parse(Console.ReadLine()));
                    Console.WriteLine($"Balance: {selAcc4.Balance}");
                    break;
                case 5:
                    Console.Write("Pick Product (1 or 2): ");
                    Product selProd5 = (int.Parse(Console.ReadLine()) == 1) ? product1 : product2;
                    Console.WriteLine($"Total Value: {selProd5.GetInventoryValue()}");
                    break;
                case 6:
                    Console.Write("Pick Student (1 or 2): ");
                    Student selStd6 = (int.Parse(Console.ReadLine()) == 1) ? student1 : student2;
                    Console.Write("Email: ");
                    selStd6.Register(Console.ReadLine());
                    Console.WriteLine("Registered successfully.");
                    break;
                case 7:
                    if (account1.Balance > account2.Balance) Console.WriteLine($"{account1.HolderName} has more.");
                    else if (account2.Balance > account1.Balance) Console.WriteLine($"{account2.HolderName} has more.");
                    else Console.WriteLine("Equal.");
                    break;
                case 8:
                    Console.Write("Pick Product (1 or 2): ");
                    Product selProd8 = (int.Parse(Console.ReadLine()) == 1) ? product1 : product2;
                    Console.Write("Quantity: ");
                    selProd8.Restock(int.Parse(Console.ReadLine()));
                    if (selProd8.StockQuantity < 10) Console.WriteLine("Low");
                    else if (selProd8.StockQuantity <= 49) Console.WriteLine("Moderate");
                    else Console.WriteLine("Well Stocked");
                    break;
                case 9:
                    Console.Write("Source Account (1 or 2): ");
                    int src = int.Parse(Console.ReadLine());
                    BankAccount sAcc = (src == 1) ? account1 : account2;
                    BankAccount dAcc = (src == 1) ? account2 : account1;
                    Console.Write("Amount: ");
                    double amt = double.Parse(Console.ReadLine());
                    if (sAcc.Balance >= amt) { sAcc.Withdraw(amt); dAcc.Deposit(amt); Console.WriteLine("Success."); }
                    else Console.WriteLine("Insufficient balance.");
                    break;
                case 10:
                    Console.Write("Pick Student (1 or 2): ");
                    Student selStd10 = (int.Parse(Console.ReadLine()) == 1) ? student1 : student2;
                    Console.Write("New grade: ");
                    if (int.TryParse(Console.ReadLine(), out int g) && g >= 0 && g <= 100) { selStd10.Grade = g; Console.WriteLine("Updated."); }
                    else Console.WriteLine("Invalid grade.");
                    break;
                case 11:
                    Console.Write("Pick Student (1 or 2): ");
                    Student selStd11 = (int.Parse(Console.ReadLine()) == 1) ? student1 : student2;
                    Console.WriteLine($"Card -> Name: {selStd11.Name}, Grade: {selStd11.Grade}, Status: {(selStd11.Grade >= 60 ? "Pass" : "Fail")}");
                    break;
                case 12:
                    Console.Write("Pick Account (1 or 2): ");
                    BankAccount selAcc12 = (int.Parse(Console.ReadLine()) == 1) ? account1 : account2;
                    if (selAcc12.Balance < 50) Console.WriteLine("Low Balance");
                    else if (selAcc12.Balance <= 1000) Console.WriteLine("Healthy");
                    else Console.WriteLine("Premium");
                    break;
                case 13:
                    Console.Write("Pick Product (1 or 2): ");
                    Product selProd13 = (int.Parse(Console.ReadLine()) == 1) ? product1 : product2;
                    Console.Write("Quantity: ");
                    int qty = int.Parse(Console.ReadLine());
                    if (selProd13.StockQuantity >= qty) { selProd13.Sell(qty); Console.WriteLine($"Revenue: {qty * selProd13.Price}"); }
                    else Console.WriteLine($"Need {qty - selProd13.StockQuantity} more units.");
                    break;
                case 14:
                    Console.Write("Pick Student (1 or 2): ");
                    Student s = (int.Parse(Console.ReadLine()) == 1) ? student1 : student2;
                    Console.Write("Pick Account (1 or 2): ");
                    BankAccount a = (int.Parse(Console.ReadLine()) == 1) ? account1 : account2;
                    if (s.Grade >= 80 && a.Balance >= 100) Console.WriteLine("Eligible");
                    else Console.WriteLine("Not Eligible");
                    break;
                case 15:
                    Console.Write("Pick Account (1 or 2): ");
                    BankAccount selAcc15 = (int.Parse(Console.ReadLine()) == 1) ? account1 : account2;
                    if (selAcc15.Balance < 50) { double b = selAcc15.Balance; selAcc15.Deposit(100 - b); Console.WriteLine($"Before: {b}, After: {selAcc15.Balance}"); }
                    else Console.WriteLine("No top-up needed.");
                    break;
                case 16:
                    BankAccount newAcc = new BankAccount(999, "Sami", 250);
                    Console.WriteLine($"New Account: {newAcc.AccountNumber}, Holder: {newAcc.HolderName}, Balance: {newAcc.Balance}");
                    break;
                case 17:
                    Console.WriteLine($"Total Students: {Student.GetTotalStudents()}");
                    break;
                case 18:
                    Console.Write("Pick Account (1 or 2): ");
                    BankAccount selAcc18 = (int.Parse(Console.ReadLine()) == 1) ? account1 : account2;
                    Console.WriteLine($"Is Overdrawn: {selAcc18.IsOverdrawn}");
                    break;
                case 19:
                    Console.Write("Pick Student (1 or 2): ");
                    Student selStd19 = (int.Parse(Console.ReadLine()) == 1) ? student1 : student2;
                    Console.Write("Enter PIN: ");
                    selStd19.Pin = Console.ReadLine();
                    Console.WriteLine("PIN set successfully.");
                    break;
                case 20:
                    running = false;
                    break;
            }
        }
    }
}