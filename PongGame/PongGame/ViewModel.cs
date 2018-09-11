using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PongGame.Annotations;

namespace PongGame
{
    class ViewModel : INotifyPropertyChanged
    {
        int _leftPadPosition = 180;
        int _rightPadPosition = 180;
        int _leftResult = 0;
        int _rightResult = 0;
        Ball ball = new Ball { XPosition = 380, YPosition = 210, IsDirectionRight = true};

        public int LeftPadPosition
        {
            get { return _leftPadPosition; }
            set
            {
                _leftPadPosition = value;
                OnPropertyChanged("LeftPadPosition");
            }
        }
        public int RightPadPosition
        {
            get { return _rightPadPosition; }
            set
            {
                _rightPadPosition = value;
                OnPropertyChanged("RightPadPosition");
            }
        }

        public int LeftResult
        {
            get { return _leftResult; }
            set
            {
                _leftResult = value;
                OnPropertyChanged("LeftResult");
            }
        }

        public int RightResult
        {
            get { return _rightResult; }
            set
            {
                _rightResult = value;
                OnPropertyChanged("RightResult");
            }
        }

        public double BallXPosition
        {
            get { return ball.XPosition; }
            set
            {
                ball.XPosition = value;
                OnPropertyChanged("BallXPosition");
            }
        }

        public double BallYPosition
        {
            get { return ball.YPosition; }
            set
            {
                ball.YPosition = value;
                OnPropertyChanged("BallYPosition");
            }
        }

        public bool IsBallDirectionRight
        {
            get { return ball.IsDirectionRight; }
            set
            {
                ball.IsDirectionRight = value;
                OnPropertyChanged("IsBallDirectionRight");
            }
        }

        public void changeBallDirection()
        {
            IsBallDirectionRight = !IsBallDirectionRight;
        }
      

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
