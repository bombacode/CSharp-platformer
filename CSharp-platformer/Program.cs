using System;

class PlatformerGame
{
    static int playerX = 0;
    static int playerY = 0;
    static int platformWidth = 10;
    static int platformHeight = 1;
    static bool isJumping = false;

    static void Main()
    {
        DrawGame();

        while (true)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.LeftArrow)
                {
                    if (playerX > 0)
                    {
                        playerX--;
                    }
                }
                else if (key == ConsoleKey.RightArrow)
                {
                    playerX++;
                }
                else if (key == ConsoleKey.Spacebar && !isJumping)
                {
                    isJumping = true;
                    Jump();
                }
            }

            UpdatePlayerPosition();

            DrawGame();

            System.Threading.Thread.Sleep(50);
        }
    }

    static void Jump()
    {
        for (int i = 0; i < 5; i++)
        {
            playerY--;
            DrawGame();
            System.Threading.Thread.Sleep(50);
        }

        for (int i = 0; i < 5; i++)
        {
            playerY++;
            DrawGame();
            System.Threading.Thread.Sleep(50);
        }

        isJumping = false;
    }

    static void UpdatePlayerPosition()
    {
        if (!isJumping && playerY < Console.WindowHeight - 1)
        {
            playerY++;
        }
    }

    static void DrawGame()
    {
        Console.Clear();

        for (int i = 0; i < platformWidth; i++)
        {
            Console.SetCursorPosition(i, Console.WindowHeight - platformHeight);
            Console.Write("-");
        }

        Console.SetCursorPosition(playerX, playerY);
        Console.Write("@");
    }
}
