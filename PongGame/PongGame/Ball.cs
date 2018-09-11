using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongGame
{
    class Ball
    {
        double xPosition;
        double yPosition;
        bool isDirectionRight;

        public double XPosition
        {
            get => xPosition;
            set => xPosition = value;
        }

        public double YPosition
        {
            get => yPosition;
            set => yPosition = value;
        }

        public bool IsDirectionRight
        {
            get => isDirectionRight;
            set => isDirectionRight = value;
        }
    }
}
