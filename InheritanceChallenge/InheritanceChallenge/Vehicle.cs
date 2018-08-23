using System;

namespace InheritanceChallenge
{
    partial class Program
    {
        public class Vehicle
        {
            String _name;
            String _size;

            int _currentVelocity;
            int _currentDirection;

            public Vehicle(String name, String size)
            {
                this._name = name;
                this._size = size;

                this._currentVelocity = 0;
                this._currentDirection = 0;
            }

            public void steer(int direction)
            {
                this._currentDirection += direction;
                Console.WriteLine("Vehicle.steer(): Steering at " + getCurrentDirection() + " degrees. ");

            }

            public void move(int velocity, int direction)
            {
                _currentDirection = direction;
                _currentVelocity = velocity;
                Console.WriteLine("Vehicle.move(): Moving at " + getCurrentVelocity() + " in direction " + getCurrentDirection());
            }

            public String getName()
            {
                return _name;
            }

            public String getSize()
            {
                return _size;
            }

            public int getCurrentVelocity()
            {
                return _currentVelocity;
            }

            public int getCurrentDirection()
            {
                return _currentDirection;
            }

            public void stop()
            {
                this._currentVelocity = 0;
            }
        }
    }
}
