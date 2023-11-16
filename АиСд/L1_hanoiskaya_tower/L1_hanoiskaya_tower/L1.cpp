#include <iostream>
using namespace std;


void hanoi(int i, int k, int n)
{
    int tmp = 6 - i - k; 			// third pin (temporary)
    if (n == 1) {
        cout << "Move disk 1 from pin " << i << " to pin " << k << ".\n";
    }
    else {
        hanoi(i, tmp, n - 1);
        cout << "Move disk " << n << " from pin " << i << " to pin " << k << ".\n";
        hanoi(tmp, k, n - 1);
    }
}

int main()
{
    hanoi(1, 3, 4);
    return 0;
}
