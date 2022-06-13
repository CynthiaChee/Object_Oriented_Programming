using System;
namespace SimpleReactionMachine
{
    public class EnhancedReactionController : IController
    {
        private IGui _gui;
        private IRandom _rng;
        private IState _state;
        private double _ticks;
        private int _round;
        private double _totalTicks;

        public IGui Gui => _gui;
        public IRandom Rng => _rng;
        public IState State => _state;
        public double Ticks
        {
            get => _ticks;
            set => _ticks = value;
        }
        public int Round
        {
            get => _round;
            set => _round = value;
        }
        public double TotalTicks
        {
            get => _totalTicks;
            set => _totalTicks = value;
        }

        public void Connect(IGui gui, IRandom rng)
        {
            this._gui = gui;
            this._rng = rng;
            Init();
        }

        public void Init()
        {
            _state = new IdleState(this);
        }

        public void CoinInserted()
        {
            _state.CoinInserted();
        }

        public void GoStopPressed()
        {
            _state.GoStopPressed();
        }

        public void Tick()
        {
            _state.Tick();
        }

        public void ChangeState(IState state)
        {
            _state = state;
        }
    }

    public interface IState
    {
        void CoinInserted();
        void GoStopPressed();
        void Tick();
    }

    public class IdleState : IState
    {
        private EnhancedReactionController _controller;

        public IdleState(EnhancedReactionController controller)
        {
            _controller = controller;
            _controller.Gui.Init();
            _controller.TotalTicks = 0;
            _controller.Round = 0;
            _controller.Gui.SetDisplay("Insert coin");
        }

        public void CoinInserted()
        {
            _controller.ChangeState(new ReadyState(_controller));
        }

        public void GoStopPressed() { return; }

        public void Tick() { return; }

    }

    public class ReadyState : IState
    {
        private EnhancedReactionController _controller;
        private int _readyTime;

        public ReadyState(EnhancedReactionController controller)
        {
            _controller = controller;
            _readyTime = 1000;
            _controller.Ticks = 0;
            _controller.Gui.SetDisplay("Press GO!");
        }

        public void CoinInserted() { return; }

        public void GoStopPressed()
        {
            _controller.ChangeState(new WaitState(_controller));
        }

        public void Tick()
        {
            _controller.Ticks++;
            if (_controller.Ticks >= _readyTime)
            {
                _controller.ChangeState(new IdleState(_controller));
            }
        }
    }

    public class WaitState : IState
    {
        private EnhancedReactionController _controller;
        private int _waitTime;

        public WaitState(EnhancedReactionController controller)
        {
            _controller = controller;
            _waitTime = _controller.Rng.GetRandom(100, 250);
            _controller.Ticks = 0;
            _controller.Gui.SetDisplay("Wait...");
        }

        public void CoinInserted() { return; }

        public void GoStopPressed()
        {
            _controller.ChangeState(new IdleState(_controller));
        }

        public void Tick()
        {
            _controller.Ticks++;
            if (_controller.Ticks >= _waitTime)
            {
                _controller.Round++;
                _controller.ChangeState(new ActiveState(_controller));
            }
        }
    }

    public class ActiveState : IState
    {
        private EnhancedReactionController _controller;
        private int _gameTime;

        public ActiveState(EnhancedReactionController controller)
        {
            _controller = controller;
            _gameTime = 200;
            _controller.Ticks = 0;
            _controller.Gui.SetDisplay($"{(_controller.Ticks / 100):0.00}");
        }

        public void CoinInserted() { return; }

        public void GoStopPressed()
        {
            _controller.TotalTicks += _controller.Ticks;
            _controller.ChangeState(new FinalState(_controller));
        }

        public void Tick()
        {
            _controller.Ticks++;
            _controller.Gui.SetDisplay($"{(_controller.Ticks / 100):0.00}");
            if (_controller.Ticks >= _gameTime)
            {
                _controller.ChangeState(new ResultsState(_controller));
            }
        }
    }

    public class FinalState : IState
    {
        private EnhancedReactionController _controller;
        private int _displayTime;

        public FinalState(EnhancedReactionController controller)
        {
            _controller = controller;
            _displayTime = 300;
            _controller.Gui.SetDisplay($"{(_controller.Ticks/100):0.00}");
            _controller.Ticks = 0;
        }

        public void CoinInserted() { return; }

        public void GoStopPressed()
        {
            RoundsCheck();
        }

        public void Tick()
        {
            _controller.Ticks++;
            if (_controller.Ticks >= _displayTime)
            {
                RoundsCheck();
            }
        }

        public void RoundsCheck()
        {
            if (_controller.Round >= 3)
            {
                _controller.ChangeState(new ResultsState(_controller));
                return;
            }
            _controller.ChangeState(new WaitState(_controller));
        }
    }

    public class ResultsState : IState
    {
        private EnhancedReactionController _controller;
        private int _resultsTime;

        public ResultsState(EnhancedReactionController controller)
        {
            _controller = controller;
            _resultsTime = 500;
            _controller.Ticks = 0;
            _controller.Gui.SetDisplay($"Average time: {(_controller.TotalTicks / _controller.Round * 0.01):0.00}");
        }

        public void CoinInserted() { return; }

        public void GoStopPressed()
        {
            _controller.ChangeState(new IdleState(_controller));
        }

        public void Tick()
        {
            _controller.Ticks++;
            if (_controller.Ticks >= _resultsTime)
            {
                _controller.ChangeState(new IdleState(_controller));
            }
        }
    }
}
