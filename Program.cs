using System;

namespace cowboy //Sup bitch
{
    class Program
    {
        //Player objects
        class Cowboy {
            public int Life {get; set;}
            public int Bullets {get; set;}
            public int Cooldown {get; set;}
        }

        //Actual program
        public static void Main(string[] args)
        {
            string inst;
            string[] commands;
            int[] matrix = new int[2];
            int turn = 1;

            //Initialize player classes
            Cowboy p1 = new Cowboy();
                p1.Life = 2;
                p1.Bullets = 0;
                p1.Cooldown = 0;
            Cowboy p2 = new Cowboy();
                p2.Life = 2;
                p2.Bullets = 0;
                p2.Cooldown = 0;
            //Print Instructions
            Console.WriteLine("Two cowbows chose an action simultaneously.");
            Console.WriteLine("You can choose to Reload, Shoot, or Defend.");
            Console.WriteLine("It's Hiiiiiiigh Noooooooon!");

            //Game loop
            while(true){
                Console.WriteLine("----------[Turn " + turn + "]----------");
                turn++;
                //Input (TBA: health memory for comparison when Shot with proxy var)
                matrix[0] = 3;
                matrix[1] = 3;
                inst = Console.ReadLine();
                commands = inst.Split(',');
                Console.WriteLine("Draw!");
                //Console.WriteLine("Player 1: " + commands[0] +" "+ "Player 2:" + commands[1]);

                //Input conversion p1 (Major issue: what if it contains multiple inputs?)
                if (commands[0].Contains("attack")){
                    matrix[0] = 0;
                }else if(commands[0].Contains("reload")){
                    matrix[0] = 1;
                }else if(commands[0].Contains("defend")){
                    matrix[0] = 2;
                }else{
                    Console.WriteLine("Input 1 is invalid");
                }

                //Input conversion p2
                if (commands[1].Contains("attack")){
                    matrix[1] = 0;
                }else if(commands[1].Contains("reload")){
                    matrix[1] = 1;
                }else if(commands[1].Contains("defend")){
                    matrix[1] = 2;
                }else{
                    Console.WriteLine("Input 2 is invalid");
                }

                //Console.WriteLine("Matrix 1: " + matrix[0] +" "+ "Matrix 2: " + matrix[1]);

                //Catch Invalid moves (attackWithoutBullet, defendOnCooldown, restore enemy health damaged)
                if (p1.Bullets == 0 && matrix[0] == 0){
                    p1.Life--;
                    p2.Bullets++;

                    if(matrix[1] == 0) p2.Life++;
                    if(matrix[1] == 1){
                        p2.Life++;
                        p2.Bullets++;
                    }
                }
                if (p1.Cooldown > 0 && matrix[0] == 2){
                    p1.Cooldown-=3;

                    if(matrix[1] != 0) p1.Life--;
                }

                if (p2.Bullets == 0 && matrix[1] == 0){
                    p2.Life--;
                    p2.Bullets++;

                    if(matrix[0] == 0) p1.Life++;
                    if(matrix[0] == 1){
                        p1.Life++;
                        p1.Bullets++;
                    }
                }
                if (p2.Cooldown > 0 && matrix[1] == 2){
                    p2.Cooldown-=3;

                    if(matrix[0] != 0) p2.Life--;
                }

                //Results
                if(matrix[0] == 0 && matrix[1] == 0){
                    p1.Life--;
                    p1.Bullets--;
                    
                    p2.Life--;
                    p2.Bullets--;

                }else if(matrix[0] == 1 && matrix[1] == 0){
                    p1.Life--;
                    p2.Bullets--;

                }else if(matrix[0] == 2 && matrix[1] == 0){
                    p1.Cooldown+=3;
                    p2.Bullets--;

                }else if(matrix[0] == 0 && matrix[1] == 1){
                    p1.Bullets--;
                    p2.Life--;

                }else if(matrix[0] == 1 && matrix[1] == 1){
                    p1.Bullets++;
                    p2.Bullets++;

                }else if(matrix[0] == 2 && matrix[1] == 1){
                    p1.Cooldown+=3;
                    p2.Bullets--;

                }else if(matrix[0] == 0 && matrix[1] == 2){
                    p1.Bullets--;
                    p2.Cooldown+=3;

                }else if(matrix[0] == 1 && matrix[1] == 2){
                    p1.Bullets++;
                    p2.Cooldown+=3;

                }else if(matrix[0] == 2 && matrix[1] == 2){
                    p1.Cooldown+=3;
                    p2.Cooldown+=3;

                }

                //Reduce cooldowns by 1
                if(p1.Cooldown >0){
                    p1.Cooldown--;
                }
                if(p2.Cooldown >0){
                    p2.Cooldown--;
                }
                //Maximum bullets?
                if(p1.Bullets >1){
                    p1.Bullets = 1;
                }
                if(p2.Bullets >1){
                    p2.Bullets = 1;
                }

                //Debug info
                Console.WriteLine("Player 1 Life: " + p1.Life + "     " + "Player 2 Life: "+ p2.Life);
                Console.WriteLine("Player 1 Bullets: " + p1.Bullets + "  " + "Player 2 Bullets: "+ p2.Bullets);
                Console.WriteLine("Player 1 Cooldown: " + p1.Cooldown + " " + "Player 2 Cooldown: "+ p2.Cooldown);

                if(p1.Life == 0){
                    Console.WriteLine("Game Over! Player 2 Wins!");
                    break;
                    
                }
                if(p2.Life == 0){
                    Console.WriteLine("Game Over! Player 1 Wins!");
                    break;
                    
                }
            }
        }
    }
}


