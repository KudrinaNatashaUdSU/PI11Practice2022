using System;
namespace moon 
{
    class Program 
    {
        static void Main(string[] args) 
        {
            //данные
            double h=1000; //начальная высота в метрах
            double f=60; //на сколько времени хватит топлива в секундах
            double v=0; //скорость корабля в м/с
            double t=0; // время в секундах
            double T=0; //накопитель времени
            int engine=0; //0-двигатель выключен, 1-включен
            const double g=-1.62; //ускорение свободного падения на луне в м/с^2
            const double a=2; //ускорение корабля в м/с^2
            const double vMax=10; //скорость в м/с, при которой корабль разбивается

            //вспомогательные функции
            static int GetInt(string s, int a, int b) 
            {
            bool valid=false;
            int result=0;
            do 
            {
                Console.Write(s);
                valid=int.TryParse(Console.ReadLine(), out result);
            } while (!valid||(result!=a && result!=b));
            return result;
            }
            static void FindTime(double A, double B, double C, out int n, out double t1, out double t2) 
            {
                n=0;  //количество решений в уравнении
                t1=0;  
                t2=0;  
                double d=B*B-4*A*C;
                if (d<0) return;
                if (d==0) n=1;
                if (d>0) n=2;
                t1=(-B+Math.Sqrt(d))/(2*A);
                t2=(-B-Math.Sqrt(d))/(2*A);
            }
            
            //основной алгоритм
            while (h>=0.0000001) 
            {
                Console.WriteLine($"Текущие значения: высота {h:F2} м, скорость {Math.Abs(v):F2} м/с, топлива {f:F2} сек"); 
                engine=GetInt("(1-включить, 0-выключить): ", 0, 1);
                double currentA=engine==0? g:a;
                t=1;
                if (t<0) t=0;
                if (t>f) t=f;
                int n;
                double t1,t2;
                FindTime(currentA/2,v,h, out n, out t1, out t2);
                if (n>0 && t1>0 && t>t1) t=t1;
                if (n>0 && t2>0 && t>t2) t=t2;
                if (engine==1) f=f-t;
                h=h+v*t+currentA/2*t*t;
                v=v+currentA*t;
                T=T+t;
            }
            Console.WriteLine($"Текущие значения: высота {h:F2} м, скорость {Math.Abs(v):F2} м/с, топлива {f:F2} сек."); 
            if (Math.Abs(v)>vMax) 
            {
                Console.WriteLine("Вы разбились!");
            } else {
                Console.WriteLine($"Вы достигли луны за {T:F2} сек!");
            }
        }
    }
}
