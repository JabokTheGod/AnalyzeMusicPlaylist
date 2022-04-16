using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyzeMusicPlaylist
{
    class CommandLineApp
    {
        static void Main(string[] args)
        {
            Songs songs = new Songs(args);
        }
    }
    public class SongData
    {
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Genre { get; set; }
        public int Size { get; set; }
        public int Time { get; set; }
        public int Year { get; set; }
        public int Plays { get; set; }
    
        public override string ToString()
        {
            return String.Format("Name: {0}, Artist: {1}, Album: {2}, Genre: {3}, Size: {4}, Time: {5}, Year: {6}, Plays: {7}", Name, Artist, Album, Genre, Size, Time, Year, Plays);
        }
    }
}    








        // private string _Name;
        // private string _Artist;
        // private string _Album;
        // private SongGenre _Genre;
        // private int _Size;
        // private int _Time;
        // private int _Year;
        // private int _Plays;

        // public Songs(string name, string artist, string album, SongGenre genre, int size, int time, int year, int plays)
        // {
        //     Name = name;
        //     Artist = artist;
        //     Album = album;
        //     Genre = genre;
        //     Size = size;
        //     Time = time;
        //     Year = year;
        //     Plays = plays;
        // }
        // public string Name 
        // {
        //     get { return _Name; }
        //     set {
        //         _Name = value;
        //     }
        // }
        // public string Artist 
        // {
        //     get { return _Artist; }
        //     set {
        //         _Artist = value;
        //     }
        // }
        // public string Album 
        // {
        //     get { return _Album; }
        //     set {
        //         _Album = value;
        //     }
        // }
        // public SongGenre Genre 
        // {
        //     get { return _Genre; }
        //     set {
        //         _Genre = value;
        //     }
        // }
        // public int Size 
        // {
        //     get { return _Size; }
        //     set {
        //         _Size = value;
        //     }
        // }
        // public int Time 
        // {
        //     get { return _Time; }
        //     set {
        //         _Time = value;
        //     }
        // }
        // public int Year 
        // {
        //     get { return _Year; }
        //     set {
        //         _Year = value;
        //     }
        // }
        // public int Plays 
        // {
        //     get { return _Plays; }
        //     set {
        //         _Plays = value;
        //     }
        // }
        // 
    