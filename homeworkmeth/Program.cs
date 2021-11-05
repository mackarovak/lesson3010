using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeworkmeth
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание1");
            Console.WriteLine(GC.GetTotalMemory(false));

            Account account1 = new Account(1000);
            Account account2 = new Account(1000);
            account1.MakeTransfer(account2, 500);
            account2.MakeTransfer(account1, 100);

            Console.WriteLine(GC.GetTotalMemory(false));

            account1.Dispose("acc1.txt");
            account2.Dispose("acc2.txt");

            Console.WriteLine(GC.GetTotalMemory(false));

            Console.WriteLine("Задание 2");
            List<Song> songs = new List<Song>();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("какое название песни?");
                string name = Console.ReadLine();
                Console.WriteLine("как зовут певца?");
                string author = Console.ReadLine();
                songs.Add(new Song(name, author));
            }
            Song.EqualsSongs(songs);
            Song.SPrevSong(songs);
        }
    }
}
