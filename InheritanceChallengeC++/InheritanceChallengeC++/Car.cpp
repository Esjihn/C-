#include "stdafx.h"
#include "Car.h"
#include <iostream>

using namespace std;

Car::Car(int cylinders, string name)
{
	this->_cylinders = cylinders;
	this->_name = name;
	this->_engine = true;
	this->_wheels = 4;
}

Car::~Car()
{
	//dtor
}

