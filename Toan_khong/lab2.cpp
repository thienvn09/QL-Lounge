#include<stdio.h>
void Nhap(int a[], int &n)
{
    scanf("%d", &n);
    for (int i = 0; i < n; i++)
    {
        scanf("%d", &a[i]);
    }
}
int main()
{
    int n;
    int a[1000];
    Nhap(a, n);
    return 0;
}