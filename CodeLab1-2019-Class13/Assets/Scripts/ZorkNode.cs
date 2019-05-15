using System.Collections;
using System.Collections.Generic;

public class ZorkNode //class that hold data for this location in the simple Zork Game
{
    public int locationNum;
    public string storyText;
    public int wLocation;
    public int eLocation;
    public int nLocation;
    public int sLocation;

    public ZorkNode() //default constructor
    {
        locationNum = 0;
        storyText = "This is default question text.";
    }

    public ZorkNode(int pageNumber, string storyText)
    {
        this.locationNum = pageNumber;
        this.storyText = storyText;
    }

    public ZorkNode(int pageNumber, string storyText, string option1Text, string option2Text)
    {
        this.locationNum = pageNumber;
        this.storyText = storyText;
    }
}
