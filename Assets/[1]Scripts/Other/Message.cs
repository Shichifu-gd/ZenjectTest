using UnityEngine;

public class Message : IMessage
{
    public void MessageOne(string message)
    {
        Debug.Log(message);
    }

    public void MessageTwo(string message)
    {
        Debug.Log(message);
    }
}