#include <stdio.h>

void Nhap(int a[], int &n)
{
    scanf("%d", &n);
    for (int i = 0; i < n; i++)
    {
        scanf("%d", &a[i]);
    }
}

void HoanVi(int &a, int &b)
{
    int tam = a;
    a = b;
    b = tam;
}

void Xuat(int a[], int n)
{
    for (int i = 0; i < n; i++)
    {
        printf("%d ", a[i]);
    }
    
}

void Tim(int a[], int n)
{
    int j = n - 1;
    
    // Tìm vị trí vi phạm thứ tự giảm dần
    while (j > 0 && a[j - 1] >= a[j])
        j--;

    if (j == 0) // Nếu dãy là hoán vị cuối cùng
        return;

    int k = n - 1;
    while (a[j - 1] >= a[k])
        k--;

    HoanVi(a[j - 1], a[k]);

    // Đảo ngược đoạn cuối
    int r = j, s = n - 1;
    while (r < s)
    {
        HoanVi(a[r], a[s]);
        r++;
        s--;
    }

    Xuat(a, n);
}

int main()
{
    int n;
    int a[1000]; // Định nghĩa mảng với kích thước tối đa
    Nhap(a, n);
    Xuat(a, n);
    Tim(a, n);
    return 0;
}
