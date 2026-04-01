using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("C# Basics Tutorial", "John Doe", 600);
        Video video2 = new Video("OOP Explained", "Jane Smith", 800);
        Video video3 = new Video("How to Code Faster", "CodeMaster", 500);

        // Add comments to video 1
        video1.AddComment(new Comment("Alice", "Great video!"));
        video1.AddComment(new Comment("Bob", "Very helpful."));
        video1.AddComment(new Comment("Charlie", "Thanks for this!"));

        // Add comments to video 2
        video2.AddComment(new Comment("Dave", "I finally understand OOP."));
        video2.AddComment(new Comment("Eve", "Nice explanation!"));
        video2.AddComment(new Comment("Frank", "Can you make more videos?"));

        // Add comments to video 3
        video3.AddComment(new Comment("Grace", "Awesome tips!"));
        video3.AddComment(new Comment("Hank", "This helped me a lot."));
        video3.AddComment(new Comment("Ivy", "Short and useful!"));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display all videos and comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");

            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.Author}: {comment.Text}");
            }

            Console.WriteLine(); // blank line between videos
        }
    }
}