using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeworkmeth
{
    class Song
    {
        private string name;
        private string author;
        private Song prevsong;
        public string Name
        {
            get { return name; }
        }
        public string Author
        {
            get { return author; }
        }
        public Song PrevSong
        {
            get { return prevsong; }
        }
        public Song(string name, string author)
        {
            prevsong = null;
            this.author = author;
            this.name = name;
        }
        public string Title()
        {
            return name + " " + author;
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            Song song = obj as Song;
            return (this.name == song.name) && (this.author == song.author);
        }
        public static void SPrevSong(List<Song> songs)
        {
            for (int i = 0; i < songs.Count; i++)
            {
                if (i != 0)
                {
                    songs[i].prevsong = songs[i - 1];
                    Console.WriteLine($"для песни {songs[i].Title()} предыдущая является {songs[i].prevsong.Title()}");
                }
            }
        }
        public static void EqualsSongs(List<Song> songs)
        {
            bool isFonded = false;
            for (int i = 0; i < songs.Count; i++)
            {
                for (int j = i + 1; j < songs.Count; j++)
                {
                    if (songs[i].Equals(songs[j]))
                    {
                        isFonded = true;
                        Console.WriteLine($"песни под номерами {i + 1} и {j + 1} совпали");
                        Console.WriteLine($"песня под названием {songs[i].name} , автор {songs[i].author}");
                    }
                }
            }
            if (!isFonded)
            {
                Console.WriteLine("одинаковых песен не найдено");
            }
        }
    }
}
