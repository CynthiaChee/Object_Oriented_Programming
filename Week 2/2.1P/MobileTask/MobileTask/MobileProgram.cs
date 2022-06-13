using System;

namespace MobileTask
{

    class MobileProgram
    {
        static void Main(string[] args)
        {
            Mobile jimMobile = new Mobile("Monthly", "Samsung Galaxy S6", "07712223344");   //constructor

            jimMobile.setAccType("PAYG");
            jimMobile.setDevice("iPhone 6S");
            jimMobile.setNumber("07713334466");
            jimMobile.setBalance(15.50);

            Console.WriteLine();
            Console.WriteLine("Account Type: " + jimMobile.getAccType() + "\nMobile Number: "
                + jimMobile.getNumber() + "\nDevice: " + jimMobile.getDevice() + "\nBalance: " + jimMobile.getBalance());

            Console.WriteLine();
            jimMobile.addCredit(10.0);
            jimMobile.makeCall(5);
            jimMobile.sendText(2);


            Mobile blakeMobile = new Mobile("Monthly", "Oppo A5", "088566332799");

            blakeMobile.setAccType("PAYG");
            blakeMobile.setDevice("Redmi 8");
            blakeMobile.setNumber("07713334466");
            blakeMobile.setBalance(7.50);

            Console.WriteLine();
            Console.WriteLine("Account Type: " + blakeMobile.getAccType() + "\nMobile Number: "
                + blakeMobile.getNumber() + "\nDevice: " + blakeMobile.getDevice() + "\nBalance: " + blakeMobile.getBalance());

            Console.WriteLine();
            blakeMobile.addCredit(5.0);
            blakeMobile.makeCall(3);
            blakeMobile.sendText(6);


            Console.ReadLine();
        }
    }
}
