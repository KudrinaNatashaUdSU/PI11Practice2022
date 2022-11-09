using System;
Console.Clear();
Maze m=new Maze(ConsoleColor.DarkMagenta, ConsoleColor.DarkRed);
while(true) {
    m.Print(3,3);
    ConsoleKeyInfo ki=Console.ReadKey(true);
    if (ki.Key==ConsoleKey.LeftArrow) m.MoveAndGetScore(-1,0);
    if (ki.Key==ConsoleKey.RightArrow) m.MoveAndGetScore(1,0);
    if (ki.Key==ConsoleKey.UpArrow) m.MoveAndGetScore(0,-1);
    if (ki.Key==ConsoleKey.DownArrow) m.MoveAndGetScore(0,1);
    Console.SetCursorPosition(25, 11);
    Console.WriteLine($"Вам нужно найти выход в лабиринте. По пути вам встретятся монетки. Ваш счет: {Maze.count}.");
}

