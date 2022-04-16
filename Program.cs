using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzeMusicPlaylist
{
    public class Songs
    {
        private static List<SongData> songDataList = new List<SongData>();
        public Songs(string[] args)
        {
            string MusicPLaylistFilePath = string.Empty;
            string ReportFilePath = string.Empty;
            string SongTextFile = Directory.GetCurrentDirectory();
            //checks for two command line parameters
            if (args.Length == 2)
            {
                try
                {
                    // Open the text file using a stream reader.
                    using (var reader = new StreamReader("SampleMusicPlaylist.txt"))
                    {
                        var line = reader.ReadLine();
                        var values = line.Split('\t');
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }
            }
            else 
            {
                if (args.Length != 2)
                {
                    //error message
                    Console.WriteLine("Invalid command. Command Ex: AnalyzeMusicPlaylist <music_playlist_file_path> <report_file_path>");
                    Console.ReadLine();
                    return;
                }
                else
                {
                    //establishes command parameter positions
                    MusicPLaylistFilePath = args[0];
                    ReportFilePath = args[1];
                }
            }
            if (File.Exists(MusicPLaylistFilePath))
            {
                if(ReadSongData(MusicPLaylistFilePath))
                {
                    //exception for creating file
                    try 
                    {
                        //create report file
                        var file = File.Create(ReportFilePath);
                        file.Close();
                    } 
                    catch (Exception) 
                    {
                        Console.WriteLine($"Unable to create report file at: " , ReportFilePath);
                    } 
                }
                else
                {
                    Console.WriteLine($"Sample Music Playlist does not exist at path: " , MusicPLaylistFilePath);
                }
                
            Console.ReadLine();
            }
            static bool ReadSongData(string filePath)
            {
                Console.WriteLine($"Reading data from: " , filePath);

                try 
                {
                    int NumItemsInRow = 0;
                    string[] lineNumbers = File.ReadAllLines(filePath);
                    for (int i = 0; i < lineNumbers.Length; i++)
                    {
                        string lineNumber = lineNumbers[i];
                        string[] value = lineNumber.Split('\t');
                        
                        if (i == 0)
                        {
                            NumItemsInRow = value.Length;
                        }
                        else
                        {
                            if (NumItemsInRow != value.Length)
                            {
                                Console.WriteLine($"Row " , lineNumber , " contains " , value.Length , " values. It should contain " , NumItemsInRow , ".");
                                return false;
                            }
                            else 
                            {
                                try
                                {   
                                    SongData songData = new SongData();
                                    songData.Name = value[0];
                                    songData.Artist = value[1];
                                    songData.Album = value[2];
                                    songData.Genre = Convert.ToString(value[3]);
                                    songData.Size = Convert.ToInt32(value[4]);
                                    songData.Time = Convert.ToInt32(value[5]);
                                    songData.Year = Convert.ToInt32(value[6]);
                                    songData.Plays = Convert.ToInt32(value[7]);
                                    songDataList.Add(songData);
                                }
                                catch (InvalidCastException)
                                {
                                    Console.WriteLine($"Row " , i , " contains invalid value.");
                                    return false;
                                }
                            }
                        }
                    }
                    Console.WriteLine($"Data reading success.");
                    return true;
                } 
                catch(Exception c) 
                {
                    Console.WriteLine("Error in reading data from txt file.");
                    throw c;
                } 
            }
            // 1
            Console.WriteLine("1. How many songs received 200 or more plays?");
            var plays200plus = from song in songDataList where song.Plays >= 200 orderby song.Year descending select song;
            Console.WriteLine("Songs that received 200 or more plays:");
            foreach (var song in plays200plus)
            {
                Console.WriteLine(song);
            }
            
            // 2
            Console.WriteLine("2. How many songs are in the playlist with the Genre of “Alternative”?");
            var altSongs = (from song in songDataList where song.Genre == "Alternative" select song).Count();
            Console.WriteLine("\nNumber of Alternative Songs: " + altSongs);

            // 3
            Console.WriteLine("3. How many songs are in the playlist with the Genre of “Hip-Hop/Rap”?");
            var rapSongs = (from song in songDataList where song.Genre == "Hip-Hop/Rap" select song).Count();
            Console.WriteLine("\nNumber of Alternative Songs: " + rapSongs);

            // 4
            Console.WriteLine("4. What songs are in the playlist from the album “Welcome to the Fishbowl?”");
            var WelcometotheFishbowlSongs = from song in songDataList where song.Album == "Welcome to the Fishbowl" orderby song.Year descending select song;
            Console.WriteLine("\nSongs that are from the album \"Welcome to the Fishbowl\":");
            foreach (var song in WelcometotheFishbowlSongs)
            {
                Console.WriteLine(song);
            }

            // 5
            Console.WriteLine("5. What are the songs in the playlist from before 1970?");
            var beforeParentSongs = from song in songDataList where song.Year <= 1970 orderby song.Year descending select song;
            Console.WriteLine("\nSongs that are from before 1970:");
            foreach (var song in beforeParentSongs)
            {
                Console.WriteLine(song);
            }

            // 6
            Console.WriteLine("6. What are the song names that are more than 85 characters long?");
            var Name85CharSongs = from song in songDataList where song.Name.ToCharArray().Length > 85 orderby song.Year descending select song;
            Console.WriteLine("\nSongs whose names are more thna 85 characters long:");
            foreach (var song in Name85CharSongs)
            {
                Console.WriteLine(song);
            }

            // 7
            Console.WriteLine("7. What is the longest song?");
            var longestSong = songDataList.OrderByDescending(song => song.Time).First();
            Console.WriteLine("\nLongest song:");
            Console.WriteLine(longestSong);

            // 8
            Console.WriteLine("8. What are the unique Genres in the playlist?");
            // var groupByUniqueGenres = from song in songDataList group song by song.Genre into newGroup
            //     orderby newGroup.Key
            //     select newGroup;
            var groupByUniqueGenres = from song in songDataList group song by song.Genre into newGroup select newGroup;

            foreach(var Genre in groupByUniqueGenres) {
                Console.WriteLine($"{ Genre.Key } => {Genre.Count() }");
            }
            // var results = from song in songDataList group song.Genre by Genre.song into g
            //     select new { PersonId = g.Key, Cars = g.ToList() };

            // 9
            Console.WriteLine("9. How many songs were produced each year in the playlist?");

            // 10
            Console.WriteLine("10. What are the total plays per year  in the playlist?");

            // 11
            Console.WriteLine("11. Print a list of the unique artists in the playlist.");
            var groupByUniqueArtists = from song in songDataList group song by song.Artist into newGroup select newGroup;

            foreach(var Artist in groupByUniqueGenres) {
                Console.WriteLine($"{ Artist.Key } => {Artist.Count() }");
            }


        
        }
    }
}