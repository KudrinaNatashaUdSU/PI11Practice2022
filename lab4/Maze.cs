class Maze{
    //данные
    int playerx=1;
    int playery=1;
    static public int count=0;
    int [,] maze=new int [,] 
    {
        {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        {1, 0, 1, 0, 0, 0, 1, 0, 0, 1},
        {1, 0, 1, 0, 1, 0, 1, 0, 1, 1},
        {1, 0, 0, 0, 1, 0, 0, 0, 1, 1},
        {1, 0, 1, 1, 1, 0, 1, 0, 0, 1},
        {1, 0, 0, 0, 1, 0, 1, 1, 0, 1},
        {1, 1, 1, 0, 0, 1, 1, 0, 0, 1},
        {1, 0, 1, 1, 0, 0, 0, 0, 1, 1},
        {1, 0, 0, 0, 0, 1, 1, 0, 0, 2},
        {1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
    };
    ConsoleColor ink;
    ConsoleColor paper;
    public Maze(ConsoleColor i, ConsoleColor p) {
        ink=i;
        paper=p;
    }
    //методы
    public void MoveAndGetScore(int dx, int dy) {
        int nx=playerx+dx;
        int ny=playery+dy;
        if (maze[ny, nx]==0 || maze[ny,nx]==3) {
            playerx=nx;
            playery=ny;
            if (maze[ny,nx]==0) {
                int m=3;
                maze[ny,nx]=m;
                count++;
            }
        }
        Action Exit=()=> {
            if (maze[ny, nx]==2) {
            Console.SetCursorPosition(25, 12);
            Console.WriteLine("Вы вышли!");
            System.Environment.Exit(0);
            } 
        };
        Exit();
    }
    public void Print(int shiftx, int shifty) {
        for (int y=0; y<10; y++) 
            for (int x=0; x<10; x++) {
                double dist=Math.Sqrt((playerx-x)*(playerx-x)+(playery-y)*(playery-y));
                if (dist>3.7) {
                    Print(shiftx+x, shifty+y, " ", ConsoleColor.Gray, ConsoleColor.DarkGray);
                } else {
                    if (maze[y,x]==0) Print(shiftx+x, shifty+y, ".");
                    else if (maze[y,x]==2) Print(shiftx+x, shifty+y, "x"); 
                    else if(maze[y,x]==3) Print(shiftx+x, shifty+y, " ");
                    else if (maze[y,x]==1) Print(shiftx+x, shifty+y, "#", ink, paper);
                }
            }
        Print(shiftx+playerx, shifty+playery, "@");  
    }
    void Print(int x, int y, string s, ConsoleColor ink=ConsoleColor.Red, ConsoleColor paper=ConsoleColor.Cyan) {
        Console.ForegroundColor=ink;
        Console.BackgroundColor=paper;
        Console.CursorLeft=x;
        Console.CursorTop=y;
        Console.Write(s);
    }
}