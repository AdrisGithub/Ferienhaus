using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Console;
using static System.DateOnly;

namespace Ferienhaus;

 class MeetingProcessor { 
     private List<Meeting> meetings;
     private string fileLoc = "meetings.txt";

    public MeetingProcessor() {
        meetings = new List<Meeting>();
        init();
    }

    public List<Meeting> getMeetings => meetings;

    private void init() {
        meetings.AddRange(Meeting.updateMeetingsFromFile(fileLoc));
    }

    public void addMeeting(DateOnly start, DateOnly end) {
        meetings.Add(new Meeting(start,end));
        StreamWriter writer = new StreamWriter(fileLoc, true);
        writer.WriteLine(start+" "+end);
        writer.Close();
    }
 }