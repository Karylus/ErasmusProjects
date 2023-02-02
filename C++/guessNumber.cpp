#include <iostream>
#include <random>

using namespace std;

int main()
{
    int option;
    cout << "1. You guess. \n2. The computer guess." << endl;
    cin >> option;

    random_device rd;
    mt19937 gen(rd());
    uniform_int_distribution<> distr(1, 100);
    int number = distr(gen);
    int guess = 0;

    int high = 100;
    int low = 1;
    char choice;


    switch (option) {
    case 1:
        do {
            cout << "Enter a guess between 1 and 100 : ";
            cin >> guess;

            if (guess > number)
                cout << "Too high!\n\n";
            else if (guess < number)
                cout << "Too low!\n\n";
            else
                cout << "You guessed the number!" << endl;

        } while (guess != number);

        break;
    
    case 2:
        
        cout << "\n\nThink about a number between " << low << " and " << high << endl;
        guess = (high-low) / 2;

        while(guess > low) {
            cout << "\n\nIs your number less than or equal to " << guess << " \nEnter y or n." << endl;
            cin >> choice;

            if (choice=='y') {
                high = guess;

                if (high - low == 1) guess = low;

                else guess -= (high - low) / 2;
            }

            else if (choice=='n') {
                low = guess;

                guess += (high - low) /2;
            }

            else cout << "Incorrect choice." << endl;
        }

        cout<< "Your number is: " << high << endl;

        break;
    
    default:
        cout << "The option is not correct." << endl;
        break;
    }
    
}