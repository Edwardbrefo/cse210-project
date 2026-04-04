using System;
using System.Collections.Generic;


class Video
{
    public string _title;
    public string _author;
    public int _length;
    public List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
    }

    public void DisplayComment()
    {
        foreach (Comment comment in _comments)
        {
            Console.WriteLine($"Commenter Name: {comment._commenterName}: {comment._Text}");
            
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");

        Video video1 = new Video("C# Tutorial for Beginners", "Edward Brefo", 600);
        video1._comments.Add(new Comment("Alice", "Great tutorial!"));
        video1._comments.Add(new Comment("Bob", "Very helpful, thanks!"));
        video1._comments.Add(new Comment("Charles", "I learned a lot from this video."));
        video1.DisplayVideoInfo();
        Console.WriteLine("Comments:");
        video1.DisplayComment();

       Console.WriteLine("");
       
        Video video2 = new Video("Learn Python in 10 Minutes", "Anna Marie", 600);
        video2._comments.Add(new Comment("Adam", "This is a great introduction to Python."));
        video2._comments.Add(new Comment("Eve", "Thanks for the quick overview!"));
        video2._comments.Add(new Comment("Seth", "I appreciate the concise format."));
        video2.DisplayVideoInfo();
        Console.WriteLine("Comments:");
        video2.DisplayComment();
    }
}