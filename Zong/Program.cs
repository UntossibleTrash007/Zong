using System;
class Program
{

    static int ballX = 0;
    static int ballY = 0;
    static int ballSpeedX = 1;
    static int ballSpeedY = 1;
    static int paddle1Y = 10;
    static int paddle2Y = 10;
    static int paddleHeight = 5;
    static int width = 80;
    static int height = 20;

    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        Console.Title = "Zong";

        while (true)
        {
            Draw();
            Input();
            Logic();
            System.Threading.Thread.Sleep(1);
        }
    }

    static void Draw()
    {
        Console.Clear();

        for (int i = 0; i < width; i++)
        {
            Console.SetCursorPosition(i, 0);
            Console.Write("-");
        }

        for (int i = 0; i < width; i++)
        {
            Console.SetCursorPosition(i, height - 1);
            Console.Write("-");
        }

        for (int i = 0; i < paddleHeight; i++)
        {
            Console.SetCursorPosition(0, paddle1Y + i);
            Console.Write("|");

            Console.SetCursorPosition(width - 1, paddle2Y + i);
            Console.Write("|");
        }

        Console.SetCursorPosition(ballX, ballY);
        Console.Write("O");

    }

    static void Input()
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.W && paddle1Y > 1)
            {
                paddle1Y--;
            }
            if (key.Key == ConsoleKey.S && paddle1Y < height - paddleHeight)
            {
                paddle1Y++;
            }
            if (key.Key == ConsoleKey.UpArrow && paddle2Y > 1)
            {
                paddle2Y--;
            }
            if (key.Key == ConsoleKey.DownArrow && paddle2Y < height - paddleHeight)
            {
                paddle2Y++;
            }

        }

    }

    static void Logic()
    {
        ballX += ballSpeedX;
        ballY += ballSpeedY;

        if (ballY <= 0 || ballY >= height - 1)
        {
            ballSpeedY = -ballSpeedY;
        }

        if (ballX == 1 && ballY >= paddle1Y && ballY <= paddle1Y + paddleHeight)
        {
            ballSpeedX = -ballSpeedX;
        }
        if (ballX == width - 2 && ballY >= paddle2Y && ballY <= paddle2Y + paddleHeight)
        {
            ballSpeedX = -ballSpeedX;
        }

        if (ballX <= 0 || ballX >= width - 1)
        {
            ballX = width / 2;
            ballY = height / 2;

            ballSpeedX = -ballSpeedX;
            ballSpeedY = 1;
        }
    }

}