using System;

namespace EnhancedReactionMachine
{
    class Tester
    {
        private static IController controller;
        private static IGui gui;
        private static string displayText;
        private static int randomNumber;
        private static int passed = 0;

        static void Main(string[] args)
        {
            Connect();
            SimpleTest();
            Console.WriteLine("\n=====================================\nSummary: {0} tests passed out of 108", passed);
            Console.ReadKey();
        }

        private static void Connect()
        {
            controller = new EnhancedReactionController();
            gui = new DummyGui();
            gui.Connect(controller);
            controller.Connect(gui, new RndGenerator());
            gui.Init();
        }

        private static void IdleState()
        {
            //IDLE
            DoReset("IdleA", controller, "Insert coin");
            DoGoStop("IdleB", controller, "Insert coin");
            DoTicks("IdleC", controller, 1, "Insert coin");
            DoInsertCoin("IdleD", controller, "Press GO!");
        }

        private static void ReadyState()
        {
            //READY
            DoTicks("ReadyA", controller, 1, "Press GO!");
            DoInsertCoin("ReadyB", controller, "Press GO!");
        }

        private static void WaitState()
        {
            randomNumber = 117;
            DoGoStop("WaitA", controller, "Wait...");
            DoTicks("WaitB", controller, randomNumber - 1, "Wait...");
        }

        //Tests flow of program when GoStop pressed in Final and Results stages without waiting for timer to run out
        private static void TestResultsGoStop()
        {
            randomNumber = 117;
            Console.WriteLine("ROUND 1");
            WaitState();
            ActiveState();
            DoTicks("Final", controller, 199, "1.23");
            DoGoStop("Final (pressed)", controller, "Wait...");
            Console.WriteLine("ROUND 2");
            DoTicks("WaitShort", controller, randomNumber - 1, "Wait...");
            ActiveState();
            DoTicks("Final", controller, 199, "1.23");
            DoGoStop("Final (pressed)", controller, "Wait...");
            Console.WriteLine("ROUND 3");
            DoTicks("WaitShort", controller, randomNumber - 1, "Wait...");
            ActiveState();
            DoTicks("Final", controller, 199, "1.23");
            DoGoStop("Final (pressed)", controller, "Average time: 1.23");
            DoGoStop("Results: pressed", controller, "Insert coin");
        }

        private static void ActiveState()
        {
            DoTicks("ActiveA", controller, 1, "0.00");
            DoTicks("ActiveB", controller, 1, "0.01");
            DoTicks("ActiveC", controller, 11, "0.12");
            DoTicks("ActiveD", controller, 111, "1.23");
            DoGoStop("ActiveE", controller, "1.23");
        }

        private static void FinalState()
        {
            DoTicks("Final", controller, 299, "1.23");
        }

        private static void ResultsState()
        {
            DoTicks("Results", controller, 499, "Average time: 1.23");
        }

        private static void SimpleTest()
        {
            //Testing normal game flow
            Console.WriteLine("Testing normal flow: ");
            IdleState();
            ReadyState();
            for(int i = 1; i < 4; i++)  //Three rounds
            {
                Console.WriteLine("ROUND {0}", i);
                WaitState();
                ActiveState();
                FinalState();
            }
            ResultsState();

            //Now testing game interrupting conditions
            Console.WriteLine("New game: ");
            IdleState();
            Console.WriteLine("GoStop not pressed after 10 secs, back to IdleState");   //After 10 secs, back to Idle
            DoTicks("10 secs later", controller, 1000, "Insert coin");
            IdleState();
            ReadyState();
            WaitState();
            Console.WriteLine("Pressing GoStop while in WaitState");        //Cheating?
            DoGoStop("Cheat", controller, "Insert coin");
            IdleState();
            ReadyState();
            Console.WriteLine("Pressing GoStop while results are shown before timer runs out");
            TestResultsGoStop();        //Pressing GoStop during results without waiting for timer

            //IDLE init
            gui.Init();
            DoReset("A", controller, "Insert coin");

            //IDLE -> READY init
            randomNumber = 123;
            DoInsertCoin("B", controller, "Press GO!");
            gui.Init();
            DoReset("C", controller, "Insert coin");

            //IDLE -> READY -> WAIT init
            randomNumber = 123;
            DoInsertCoin("D", controller, "Press GO!");
            DoGoStop("E", controller, "Wait...");
            //New game
            gui.Init();
            DoReset("F", controller, "Insert coin");

            //IDLE -> READY -> WAIT -> RUN init
            randomNumber = 137;
            DoInsertCoin("G", controller, "Press GO!");
            DoGoStop("H", controller, "Wait...");
            DoTicks("I", controller, randomNumber + 98, "0.98");
            //New game
            gui.Init();
            DoReset("J", controller, "Insert coin");

            //IDLE -> READY -> WAIT -> RUN -> STOP init
            randomNumber = 119;
            DoInsertCoin("K", controller, "Press GO!");
            DoGoStop("L", controller, "Wait...");
            DoTicks("M", controller, randomNumber + 135, "1.35");
            DoGoStop("P", controller, "1.35");
            //New game
            gui.Init();
            DoReset("Q", controller, "Insert coin");

            //IDLE -> READY -> WAIT -> RUN (timeout) -> STOP
            randomNumber = 120;
            DoInsertCoin("R", controller, "Press GO!");
            DoGoStop("S", controller, "Wait...");
            DoTicks("T", controller, randomNumber + 199, "1.99");
            DoTicks("U", controller, 50, "Average time: 0.00");
            //New game
            gui.Init();
            DoReset("Q", controller, "Insert coin");

            //IDLE -> READY -> WAIT -> RUN 3 rounds -> RESULTS
            randomNumber = 119;
            DoInsertCoin("R", controller, "Press GO!");
            DoGoStop("S", controller, "Wait...");
            DoTicks("T", controller, randomNumber + 135, "1.35");
            DoGoStop("U", controller, "1.35");
            DoGoStop("V", controller, "Wait...");
            DoTicks("W", controller, randomNumber + 135, "1.35");
            DoGoStop("X", controller, "1.35");
            DoGoStop("Y", controller, "Wait...");
            DoTicks("Z", controller, randomNumber + 135, "1.35");
            DoGoStop("a", controller, "1.35");
            DoGoStop("b", controller, "Average time: 1.35");
        }

        private static void DoReset(string str, IController controller, string msg)
        {
            try
            {
                controller.Init();
                GetMessage(str, msg);
            }
            catch (Exception exception)
            {
                Console.WriteLine("test {0}: failed with exception {1})", str, msg, exception.Message);
            }
        }

        private static void DoGoStop(string str, IController controller, string msg)
        {
            try
            {
                controller.GoStopPressed();
                GetMessage(str, msg);
            }
            catch (Exception exception)
            {
                Console.WriteLine("test {0}: failed with exception {1})", str, msg, exception.Message);
            }
        }

        private static void DoInsertCoin(string str, IController controller, string msg)
        {
            try
            {
                controller.CoinInserted();
                GetMessage(str, msg);
            }
            catch (Exception exception)
            {
                Console.WriteLine("test {0}: failed with exception {1})", str, msg, exception.Message);
            }
        }

        private static void DoTicks(string str, IController controller, int n, string msg)
        {
            try
            {
                for (int t = 0; t < n; t++) controller.Tick();
                GetMessage(str, msg);
            }
            catch (Exception exception)
            {
                Console.WriteLine("test {0}: failed with exception {1})", str, msg, exception.Message);
            }
        }

        private static void GetMessage(string str, string msg)
        {
            if (msg.ToLower() == displayText.ToLower())
            {
                Console.WriteLine("test {0}: passed successfully", str);
                passed++;
            }
            else
            {
                Console.WriteLine("test {0}: failed with message ( expected {1} | received {2})", str, msg, displayText);
            }
        }

        private class DummyGui : IGui
        {
            private IController controller;

            public void Connect(IController controller)
            {
                this.controller = controller;
            }

            public void Init()
            {
                displayText = "?reset?";
            }

            public void SetDisplay(string msg)
            {
                displayText = msg;
            }
        }

        private class RndGenerator : IRandom
        {
            public int GetRandom(int from, int to)
            {
                return randomNumber;
            }
        }
    }
}
