using System;
using System.Collections;
using System.Collections.Generic;

namespace _5_лаба_4___Hashtable_
{
    class Program
    {

        public static Hashtable discs = new Hashtable();
        public static Hashtable songs = new Hashtable();
        public static int count_of_discs = 0;
        public static List<int> list_songs = new List<int>();
        public static void Main(string[] args)
        {
            try
            {
                Menu();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Main(args);
            }
        }
        public static void Menu()
        {
            int num=0;
            while (!(num < 0 || num > 7))
            {
                Console.WriteLine("\nВыберите действие\n" +
                    "1) Добавить диск\n" +
                    "2) Удалить диск\n" +
                    "3) Добавить песню\n" +
                    "4) Удалить песню\n" +
                    "5) Просмотреть каталог дисков\n" +
                    "6) Просмотреть содержимое диска\n");
                num = Convert.ToInt32(Console.ReadLine());
                switch (num)
                {
                    case 1:
                        Add_disc();
                        break;
                    case 2:
                        Delete_disc();
                        break;
                    case 3:
                        Add_song();
                        break;
                    case 4:
                        Delete_song();
                        break;
                    case 5:
                        Output_discs(discs);
                        break;
                    case 6:
                        Output_songs();
                        break;
                    default:
                        Console.WriteLine("Такого пункта нету в меню");
                        Menu();
                        break;
                }
            }
        }
        public static void Output_songs()
        {
            Output_discs(discs);
            Console.WriteLine("\nВведите номер диска");
            int name_disc = Convert.ToInt32(Console.ReadLine());
            if (!discs.Contains(name_disc))
            {
                while (!discs.Contains(name_disc))
                {
                    Console.WriteLine("Введите верный номер диска");
                    name_disc = Convert.ToInt32(Console.ReadLine());
                }
            }
            Songs_of_dics(name_disc);
        }
        public static void Add_disc()
        {
            count_of_discs++;
            Console.WriteLine("\nВведите название нового диска");
            string disc_new = Console.ReadLine();
            discs.Add(count_of_discs, disc_new);
            list_songs.Add(0);
        }
        public static void Delete_disc()
        {
            Output_discs(discs);
            Console.WriteLine("\nВведите номер диска:");
            int num = Convert.ToInt32(Console.ReadLine());
            if (!discs.Contains(num))
            {
                do
                {
                    Console.WriteLine("Введенного номера не существует (введите back, чтобы вернуться обратно)");
                    if (Console.ReadLine().Trim().ToLower() == "back")
                    {
                        num = 0;
                        break;
                    }
                } while (!discs.Contains(num));
            }
            if (num != 0)
            {
                Delete_songs(num);
                list_songs[num - 1] = 0;
                discs.Remove(num);
            }
        }
        public static void Add_song()
        {
            Output_discs(discs);
            Console.WriteLine("\nВведите номер диска, где будет песня");
            int nameofdisc = Convert.ToInt32(Console.ReadLine());
            switch (nameofdisc)
            {
                case 1:
                    list_songs[0] = list_songs[0] + 1;
                    break;
                case 2:
                    list_songs[1] = list_songs[1] + 1;
                    break;
                default:
                    if (!discs.Contains(nameofdisc))
                    {
                        while (!discs.Contains(nameofdisc))
                        {
                            Console.WriteLine("Введите верный номер диска");
                            nameofdisc = Convert.ToInt32(Console.ReadLine());
                        }
                    }
                    list_songs[nameofdisc - 1] = list_songs[nameofdisc - 1] + 1;
                    break;
            }
            Songs_of_dics(nameofdisc);
            Console.WriteLine("\nВведите название новой песни");
            string new_song = Console.ReadLine();
            songs.Add(nameofdisc * 10 + list_songs[nameofdisc - 1], new_song);
        }
        static void Delete_song()
        {
            Output_discs(discs);
            Console.WriteLine("\nВведите номер диска");
            int name_disc = Convert.ToInt32(Console.ReadLine());
            if (!discs.Contains(name_disc))
            {
                while (!discs.Contains(name_disc))
                {
                    Console.WriteLine("Введенного номера не существует");
                    name_disc = Convert.ToInt32(Console.ReadLine());
                }
            }
            Songs_of_dics(name_disc);
            Console.WriteLine("\nВведите номер песни, которую надо удалить");
            int song_delete = Convert.ToInt32(Console.ReadLine());
            if (!songs.Contains(song_delete))
            {
                while (!songs.Contains(song_delete))
                {
                    Console.WriteLine("Введенного номера песни не существует, введите номер песни");
                    song_delete = Convert.ToInt32(Console.ReadLine());
                }
            }
            songs.Remove(song_delete);
        }
        static void Output_discs(Hashtable discs)
        {
            Console.WriteLine("Диски:");
            foreach (DictionaryEntry pair in discs)
            {
                Console.WriteLine($"{pair.Key} : {pair.Value}");
            }
        }
        static void Songs_of_dics(int n)
        {
            Console.WriteLine($"Песни, которые есть на {n} диске : ");
            ICollection keyS = songs.Keys;
            foreach (int element in keyS)
            {
                string s = Convert.ToString(n); 
                if (Convert.ToString(element).StartsWith(s) == true)
                {
                    Console.WriteLine($"{element} : {songs[element]} ");
                }
            }
        }
        static void Delete_songs(int number)
        {
            ICollection key = songs.Keys;
            foreach (int pair in key)
            {
                string num = Convert.ToString(number);
                if (Convert.ToString(pair).Trim().StartsWith(num) == true)
                {
                    songs.Remove(pair);
                }
            }
        }
    
}
}
