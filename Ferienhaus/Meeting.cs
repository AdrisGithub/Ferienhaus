using System;
using System.IO;

namespace Ferienhaus;

internal class Meeting
{
    private readonly DateOnly start;
    private readonly DateOnly end;
    public Meeting(string start, string end)
    {
        this.start = DateOnly.Parse(start);
        this.end = DateOnly.Parse(end);
    }
    public Meeting(DateOnly start, DateOnly end)
    {
        this.start = start;
        this.end = end;
    }
    public bool Collides(DateOnly input) => input >= start && input <= end;

    public bool Collides(DateOnly start, DateOnly end)
    {
        return start >= this.start && end <= this.end;
    }
    private static Meeting createMeeting(string input)
    {
        string[] array = input.Split(' ');
        return new Meeting(array[0], array[1]);
    }

    public static Meeting[] updateMeetingsFromFile(string fileLoc)
    {
        string[] fileText = File.ReadAllLines(fileLoc);
        Meeting[] meetings = new Meeting[fileText.Length];
        for (int i = 0; i < fileText.Length; i++)
        {
            meetings[i] = createMeeting(fileText[i]);
        }
        return meetings;
    }

    public DateOnly Start => start;

    public DateOnly End => end;
}