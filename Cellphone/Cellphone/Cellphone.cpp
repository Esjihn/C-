// Cellphone.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

using namespace std;


int cellphoneTower(int);

int main()
{
	int input;
	cin >> input;
	cin.ignore();
	cout << input << endl;
	cellphoneTower(10);


    return 0;
}

int cellphoneTower(int towerStrength)
{
	int array[100];
	int counter = 0;


	for (int i = 0; i < counter; i++)
	{
		if (counter == 10)
		{
			break;
		}
		else
		{
			cout << towerStrength;
			cout << counter;
			towerStrength++;
			counter++;
		}

		
	}

	cout << towerStrength << endl;
	return towerStrength;
}

