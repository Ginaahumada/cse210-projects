using System;

class Program
{
    static void Main(string[] args)
    {
        //Create a List of Videos
        List<Video> videos = new List<Video>();

        Video FirstVideo = new Video("Baby Shark Dance", "Rovio", 180);

        FirstVideo.AddComment("Arturo Mata", "Very nive Video");
        FirstVideo.AddComment("Jose Miguel", "I don't Like it");
        FirstVideo.AddComment("Gina Ahumada", "I enjoy this video");

        Video SecondVideo = new Video("Detergent Tyde", "Tyde Corp", 160);

        SecondVideo.AddComment("Joseph Murillo", "Works perfectly, thank you!");
        SecondVideo.AddComment("Bryan Josue", "Excellent quality and design!");
        SecondVideo.AddComment("Camila Cabello", "Incredibly useful, highly recommend.");
        SecondVideo.AddComment("Angelina Jolie", "Amazing video.");


        Video ThirdVideo = new Video("Air dryer", "Black & Decker", 200);

        ThirdVideo.AddComment("Andrea Bocelli", "Fast shipping, very satisfied!");
        ThirdVideo.AddComment("Raul Mina", "Beautiful and practical, love it.");
        ThirdVideo.AddComment("Santiago Mena", "Meets all my expectations.");

        videos.Add(FirstVideo);
        videos.Add(SecondVideo);
        videos.Add(ThirdVideo);
        
        //Display the information for each Video
        foreach(Video video in videos)
        {
            video.DisplayInformation();
        }
        //Save the List of videos and comments in a file
        FileHandler file = new FileHandler("videos.txt");
        file.WriteInFile(videos);
        
    }
}