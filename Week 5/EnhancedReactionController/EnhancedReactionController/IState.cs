//using System;
//namespace SimpleReactionMachine
//{
//    public interface IState
//    {
//        void CoinInserted();
//        void GoStopPressed();
//        void Tick();
//    }

//    public class IdleState : IState
//    {
//        private SimpleReactionController _controller;

//        public IdleState(SimpleReactionController controller)
//        {
//            _controller = controller;
//        }

//        public void CoinInserted()
//        {
//            _controller.ChangeState(new ReadyState(_controller);
//        }

//        public void GoStopPressed() { return; }

//        public void Tick() { return; }

//    }

//    public class ReadyState : IState
//    {
//        private SimpleReactionController _controller;

//        public ReadyState(SimpleReactionController controller)
//        {
//            _controller = controller;
//        }

//        public void CoinInserted() { return; }

//        public void GoStopPressed()
//        {
//            _controller.ChangeState(new WaitState(_controller));
//        }

//        public void Tick() { return; }
//    }

//    public class WaitState : IState
//    {
//        private SimpleReactionController _controller;

//        public WaitState(SimpleReactionController controller)
//        {
//            _controller = controller;
//        }

//        public void CoinInserted() { return; }

//        public void GoStopPressed()
//        {
//            _controller.ChangeState(new IdleState(_controller));
//        }

//        public void Tick()
//        {

//        }
//    }

//    public class ActiveState : IState
//    {
//        private SimpleReactionController _controller;
//    }

//    public class FinalState : IState
//    {

//    }
//}
