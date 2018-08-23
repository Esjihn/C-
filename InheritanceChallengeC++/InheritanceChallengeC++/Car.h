#ifndef CAR_H
#define CAR_H
#include "stdafx.h"
#include <iostream>

using namespace std;

class Car
{
public:
	Car(int cylinders, string name);
	virtual ~Car();
	string startEngine()
	{
		return "Car -> startEngine()";
	}
	string accelerate()
	{
		return "Car -> accelerate()";
	}
	string brake()
	{

		return "Car -> brake()";
	}
	string getName()
	{
		return _name;
	}

protected:

private:
	bool _engine;
	int _cylinders;
	string _name;
	int _wheels;


};

#endif // CAR_H
