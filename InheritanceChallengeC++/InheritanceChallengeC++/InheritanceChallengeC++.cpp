// InheritanceChallengeC++.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include "Car.h"

using namespace std;

static void PolyConsole();


int main()
{
	cout >> PolyConsole();

    return 0;
}



static void PolyConsole()
{
	Car *car = new Car(8, "new");
	car->startEngine();
	car->accelerate();
	car->brake();
	

}
