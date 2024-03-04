using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_10CharpT
{
    using System;
    using System.Collections;

    class MusicCD
    {
        public string Title { get; set; }
        public List<Song> Songs { get; set; }

        public MusicCD(string title)
        {
            Title = title;
            Songs = new List<Song>();
        }
    }

    class Song
    {
        public string Title { get; set; }
        public string Artist { get; set; }

        public Song(string title, string artist)
        {
            Title = title;
            Artist = artist;
        }

        public override string ToString()
        {
            return $"{Title} - {Artist}";
        }
    }

    class MusicCDCatalog
    {
        static Hashtable catalog = new Hashtable();

        public static void Task()
        {
            while (true)
            {
                Console.WriteLine("Music CD Catalog Menu:");
                Console.WriteLine("1. Add CD");
                Console.WriteLine("2. Delete CD");
                Console.WriteLine("3. Add Song");
                Console.WriteLine("4. Delete Song");
                Console.WriteLine("5. View Catalog");
                Console.WriteLine("6. View CD");
                Console.WriteLine("7. Search by Artist");
                Console.WriteLine("8. Exit");
                Console.Write("Enter your choice (1-8): ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddCD();
                            break;
                        case 2:
                            DeleteCD();
                            break;
                        case 3:
                            AddSong();
                            break;
                        case 4:
                            DeleteSong();
                            break;
                        case 5:
                            ViewCatalog();
                            break;
                        case 6:
                            ViewCD();
                            break;
                        case 7:
                            SearchByArtist();
                            break;
                        case 8:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine(
                                "Invalid choice. Please enter a number between 1 and 8."
                            );
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }

                Console.WriteLine();
            }
        }

        static void AddCD()
        {
            Console.Write("Enter CD title: ");
            string cdTitle = Console.ReadLine();

            if (!catalog.ContainsKey(cdTitle))
            {
                catalog[cdTitle] = new MusicCD(cdTitle);
                Console.WriteLine($"CD '{cdTitle}' added successfully.");
            }
            else
            {
                Console.WriteLine($"CD '{cdTitle}' already exists in the catalog.");
            }
        }

        static void DeleteCD()
        {
            Console.Write("Enter CD title to delete: ");
            string cdTitle = Console.ReadLine();

            if (catalog.ContainsKey(cdTitle))
            {
                catalog.Remove(cdTitle);
                Console.WriteLine($"CD '{cdTitle}' deleted successfully.");
            }
            else
            {
                Console.WriteLine($"CD '{cdTitle}' not found in the catalog.");
            }
        }

        static void AddSong()
        {
            Console.Write("Enter CD title: ");
            string cdTitle = Console.ReadLine();

            if (catalog.ContainsKey(cdTitle))
            {
                Console.Write("Enter song title: ");
                string songTitle = Console.ReadLine();

                Console.Write("Enter a song artist name: ");
                string artistName = Console.ReadLine();

                MusicCD musicCD = (MusicCD)catalog[cdTitle];
                musicCD.Songs.Add(new Song(songTitle, artistName));

                Console.WriteLine($"Song '{songTitle}' added to CD '{cdTitle}' successfully.");
            }
            else
            {
                Console.WriteLine(
                    $"CD '{cdTitle}' not found in the catalog. Please add the CD first."
                );
            }
        }

        static void DeleteSong()
        {
            Console.Write("Enter CD title: ");
            string cdTitle = Console.ReadLine();

            if (catalog.ContainsKey(cdTitle))
            {
                Console.Write("Enter song title to delete: ");
                string songTitle = Console.ReadLine();

                MusicCD musicCD = (MusicCD)catalog[cdTitle];
                Song songToRemove = musicCD.Songs.Find(song => song.Title == songTitle);

                if (songToRemove != null)
                {
                    musicCD.Songs.Remove(songToRemove);
                    Console.WriteLine(
                        $"Song '{songTitle}' deleted from CD '{cdTitle}' successfully."
                    );
                }
                else
                {
                    Console.WriteLine($"Song '{songTitle}' not found in CD '{cdTitle}'.");
                }
            }
            else
            {
                Console.WriteLine($"CD '{cdTitle}' not found in the catalog.");
            }
        }

        static void ViewCatalog()
        {
            Console.WriteLine("Music CD Catalog:");
            foreach (DictionaryEntry entry in catalog)
            {
                MusicCD musicCD = (MusicCD)entry.Value;

                Console.WriteLine($"CD: {musicCD.Title}");
                Console.WriteLine("Songs:");
                foreach (Song song in musicCD.Songs)
                {
                    Console.WriteLine($"- {song}");
                }
                Console.WriteLine();
            }
        }

        static void ViewCD()
        {
            Console.Write("Enter CD title: ");
            string cdTitle = Console.ReadLine();

            if (catalog.ContainsKey(cdTitle))
            {
                MusicCD musicCD = (MusicCD)catalog[cdTitle];
                Console.WriteLine($"CD: {musicCD.Title}");
                Console.WriteLine("Songs:");
                foreach (Song song in musicCD.Songs)
                {
                    Console.WriteLine($"- {song}");
                }
            }
            else
            {
                Console.WriteLine($"CD '{cdTitle}' not found in the catalog.");
            }
        }

        static void SearchByArtist()
        {
            Console.Write("Enter artist name: ");
            string artistName = Console.ReadLine();

            bool found = false;

            Console.WriteLine($"Songs by artist '{artistName}':");
            foreach (DictionaryEntry entry in catalog)
            {
                MusicCD musicCD = (MusicCD)entry.Value;
                foreach (Song song in musicCD.Songs)
                {
                    if (song.Artist.Contains(artistName))
                    {
                        Console.WriteLine($"- {song} (CD: {musicCD.Title})");
                        found = true;
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine($"No songs by artist '{artistName}' found in the catalog.");
            }
        }
    }
    //class MusicCDCatalog
    //{
    //    static Hashtable catalog = new Hashtable();

    //    public static void Task()
    //    {
    //        while (true)
    //        {
    //            Console.WriteLine("Music CD Catalog Menu:");
    //            Console.WriteLine("1. Add CD");
    //            Console.WriteLine("2. Delete CD");
    //            Console.WriteLine("3. Add Song");
    //            Console.WriteLine("4. Delete Song");
    //            Console.WriteLine("5. View Catalog");
    //            Console.WriteLine("6. View CD");
    //            Console.WriteLine("7. Search by Artist");
    //            Console.WriteLine("8. Exit");
    //            Console.Write("Enter your choice (1-8): ");

    //            int choice;
    //            if (int.TryParse(Console.ReadLine(), out choice))
    //            {
    //                switch (choice)
    //                {
    //                    case 1:
    //                        AddCD();
    //                        break;
    //                    case 2:
    //                        DeleteCD();
    //                        break;
    //                    case 3:
    //                        AddSong();
    //                        break;
    //                    case 4:
    //                        DeleteSong();
    //                        break;
    //                    case 5:
    //                        ViewCatalog();
    //                        break;
    //                    case 6:
    //                        ViewCD();
    //                        break;
    //                    case 7:
    //                        SearchByArtist();
    //                        break;
    //                    case 8:
    //                        Environment.Exit(0);
    //                        break;
    //                    default:
    //                        Console.WriteLine(
    //                            "Invalid choice. Please enter a number between 1 and 8."
    //                        );
    //                        break;
    //                }
    //            }
    //            else
    //            {
    //                Console.WriteLine("Invalid input. Please enter a valid number.");
    //            }

    //            Console.WriteLine();
    //        }
    //    }

    //    static void AddCD()
    //    {
    //        Console.Write("Enter CD title: ");
    //        string cdTitle = Console.ReadLine();

    //        if (!catalog.ContainsKey(cdTitle))
    //        {
    //            catalog[cdTitle] = new ArrayList();
    //            Console.WriteLine($"CD '{cdTitle}' added successfully.");
    //        }
    //        else
    //        {
    //            Console.WriteLine($"CD '{cdTitle}' already exists in the catalog.");
    //        }
    //    }

    //    static void DeleteCD()
    //    {
    //        Console.Write("Enter CD title to delete: ");
    //        string cdTitle = Console.ReadLine();

    //        if (catalog.ContainsKey(cdTitle))
    //        {
    //            catalog.Remove(cdTitle);
    //            Console.WriteLine($"CD '{cdTitle}' deleted successfully.");
    //        }
    //        else
    //        {
    //            Console.WriteLine($"CD '{cdTitle}' not found in the catalog.");
    //        }
    //    }

    //    static void AddSong()
    //    {
    //        Console.Write("Enter CD title: ");
    //        string cdTitle = Console.ReadLine();

    //        if (catalog.ContainsKey(cdTitle))
    //        {
    //            Console.Write("Enter song title: ");
    //            string songTitle = Console.ReadLine();

    //            Console.Write("Enter a song artist name: ");
    //            string artistName = Console.ReadLine();

    //            ArrayList songs = (ArrayList)catalog[cdTitle];
    //            songs.Add($"{songTitle} - {artistName}");

    //            Console.WriteLine($"Song '{songTitle}' added to CD '{cdTitle}' successfully.");
    //        }
    //        else
    //        {
    //            Console.WriteLine(
    //                $"CD '{cdTitle}' not found in the catalog. Please add the CD first."
    //            );
    //        }
    //    }

    //    static void DeleteSong()
    //    {
    //        Console.Write("Enter CD title: ");
    //        string cdTitle = Console.ReadLine();

    //        if (catalog.ContainsKey(cdTitle))
    //        {
    //            Console.Write("Enter song title to delete: ");
    //            string songTitle = Console.ReadLine();

    //            ArrayList songs = (ArrayList)catalog[cdTitle];
    //            if (songs.Contains(songTitle))
    //            {
    //                songs.Remove(songTitle);
    //                Console.WriteLine(
    //                    $"Song '{songTitle}' deleted from CD '{cdTitle}' successfully."
    //                );
    //            }
    //            else
    //            {
    //                Console.WriteLine($"Song '{songTitle}' not found in CD '{cdTitle}'.");
    //            }
    //        }
    //        else
    //        {
    //            Console.WriteLine($"CD '{cdTitle}' not found in the catalog.");
    //        }
    //    }

    //    static void ViewCatalog()
    //    {
    //        Console.WriteLine("Music CD Catalog:");
    //        foreach (DictionaryEntry entry in catalog)
    //        {
    //            string cdTitle = (string)entry.Key;
    //            ArrayList songs = (ArrayList)entry.Value;

    //            Console.WriteLine($"CD: {cdTitle}");
    //            Console.WriteLine("Songs:");
    //            foreach (string song in songs)
    //            {
    //                Console.WriteLine($"- {song}");
    //            }
    //            Console.WriteLine();
    //        }
    //    }

    //    static void ViewCD()
    //    {
    //        Console.Write("Enter CD title: ");
    //        string cdTitle = Console.ReadLine();

    //        if (catalog.ContainsKey(cdTitle))
    //        {
    //            ArrayList songs = (ArrayList)catalog[cdTitle];
    //            Console.WriteLine($"CD: {cdTitle}");
    //            Console.WriteLine("Songs:");
    //            foreach (string song in songs)
    //            {
    //                Console.WriteLine($"- {song}");
    //            }
    //        }
    //        else
    //        {
    //            Console.WriteLine($"CD '{cdTitle}' not found in the catalog.");
    //        }
    //    }

    //    static void SearchByArtist()
    //    {
    //        Console.Write("Enter artist name: ");
    //        string artistName = Console.ReadLine();

    //        bool found = false;

    //        Console.WriteLine($"Songs by artist '{artistName}':");
    //        foreach (DictionaryEntry entry in catalog)
    //        {
    //            ArrayList songs = (ArrayList)entry.Value;
    //            foreach (string song in songs)
    //            {
    //                if (song.Contains(artistName))
    //                {
    //                    Console.WriteLine($"- {song} (CD: {entry.Key})");
    //                    found = true;
    //                }
    //            }
    //        }

    //        if (!found)
    //        {
    //            Console.WriteLine($"No songs by artist '{artistName}' found in the catalog.");
    //        }
    //    }
    //}
}
