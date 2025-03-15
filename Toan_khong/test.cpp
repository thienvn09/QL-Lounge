#include<iostream>
using namespace std;
void Nhap(int a[], int &n)
{
    cin >> n;
    for (int i = 0; i < n; i++)
    {
        cin >> a[i];
    }
}
void Xuat(int a[], int n)
{
    for (int i = 0; i < n; i++)
    {
        cout << a[i] << " ";
    }
}
int main()
{
    int n;
    int a[1000];
    Nhap(a, n);
    Xuat(a, n);
    return 0;
}