namespace Bunny_Generator
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // Size of the Field
            int width = 20;
            int height = 40;

            // How long it runs
            int duration = 20000;

            // How fast it updates ( speed )
            int speed = 50;
            

            Map bunnyHill = new Map(width, height);

            bunnyHill.GenerateBunny();
            bunnyHill.DisplayMap();

            int count = 0;
            Random rand = new Random();
            while(count <= duration)
            {

                if(rand.Next(0, 6) % 5 == 0 )
                {
                    bunnyHill.GenerateBunny();
                }

                bunnyHill.FullMove();
                Thread.Sleep(speed);
            }


        }
    }
}