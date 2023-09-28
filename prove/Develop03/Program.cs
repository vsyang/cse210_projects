using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(reference, "For God so loved the world, that He gave His only begotten Son, that whosoever believeth in Him should not perish, but have everlasting life.");

        bool quit = false;

        while (!quit)
        {
            Console.WriteLine();
            Console.WriteLine(scripture.GetDisplayText());
            //Console.WriteLine("Press Enter to continue or type 'quit' to exit: ");
            //string user = Console.ReadLine();

            if(scripture.IsCompletelyHidden())
            {
                quit = true;
            }    
            else  
            {
                Console.WriteLine("Press Enter to continue or type 'quit' to exit: ");
                string user = Console.ReadLine();

                if(user.ToLower() == "quit")
                {
                    quit = true;
                }
                else
                {
                    scripture.HideRandomWords(1);
                }
                // scripture.HideRandomWords(3);
                // Console.WriteLine(scripture.GetDisplayText());

                // if (scripture.IsCompletelyHidden())
                // {
                //     quit = true;
                // }
            }        
        }
    }
}