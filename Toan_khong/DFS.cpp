#include <iostream>
using namespace std;

const int MAX = 100; // số đỉnh tối đa
int a[MAX][MAX];     // ma trận kề
bool daTham[MAX];    // mảng đánh dấu đỉnh đã thăm
int n, m;            // n: số đỉnh, m: số cạnh

// Thuật toán DFS đệ quy
void DFS(int u) {
    daTham[u] = true;           // đánh dấu đã thăm đỉnh u
    cout << u << " ";           // in ra đỉnh u

    for (int v = 0; v < n; v++) {
        if (a[u][v] == 1 && !daTham[v]) {
            DFS(v);             // gọi đệ quy với đỉnh v kề chưa thăm
        }
    }
}

int main() {
    cout << "Nhap so dinh va so canh: ";
    cin >> n >> m;

    // Khởi tạo ma trận kề với toàn 0
    for (int i = 0; i < n; i++)
        for (int j = 0; j < n; j++)
            a[i][j] = 0;

    cout << "Nhap cac canh (u v):\n";
    for (int i = 0; i < m; i++) {
        int u, v;
        cin >> u >> v;
        a[u][v] = 1;
        a[v][u] = 1; // Nếu là đồ thị vô hướng thì gán cả hai chiều
    }

    cout << "Duyet DFS bat dau tu dinh 0:\n";
    DFS(0); // duyệt từ đỉnh 0

    return 0;
}
