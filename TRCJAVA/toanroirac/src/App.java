public class App {
    public static void main(String[] args) throws Exception {
        int n = 1000;
        int k = 3;
        long result = Flash(n + k - 1, k - 1);
        System.out.println("Số nghiệm nguyên không âm: " + result);
        
    }
    public static int GiaiThua(int n) {
        if (n == 0) {
            return 1;
        }
        if(n == 1) {
            return 1;
        }
        return n * GiaiThua(n - 1);
    }
    public static int HoanVi(int n)
    {
        if(n==0)
        {
            return 1;
        }
        if(n==1)
        {
            return 1;
        }
        return GiaiThua(n);
    }
    public static int ChinhHop(int n,int k)
    {
        if(n==k)
        {
            return 1;
        }
        if(k==0)
        {
            return 1;
        }
        return ChinhHop((GiaiThua(n))/GiaiThua(n-k),k);
    }
   public static int ToHop(int n,int k)
   {
        if(n==k)
        {
            return 1;
        }
        if(k==0)
        {
            return 1;
        }  
        return ToHop(GiaiThua(n)/(GiaiThua(k)*(GiaiThua(n-k) )),k);
   }
   public static int HoanViLap(int n,int l)
   {
        return (int) Math.pow(n, l);
   }
   public static long Flash(int n,int k)
   {
    long result = 1;
    for (int i = 1; i <= k; i++) {
        result = result * (n - i + 1) / i;
    }
    return result;    
   }

}
