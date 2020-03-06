using Zenject;
using System;
using TMPro;

public enum OptionTime
{
    HourMinuteSecond,
    HourMinut,
    Hour,
    MinuteSecond,
    Minute,
    Second,
}

public class Message : IMessage, ITickable
{
    [Inject] private TextMeshProUGUI TextGameLog;

    private int Limit = 3000;

    private string NewMessage;
    private string OldMessage;

    public void MessageOne(string message)
    {
        NewMessage = message;
        OldMessage = NewMessage;
        MessageOutput($"{GetCurrentTime(OptionTime.HourMinuteSecond)} : {OldMessage}");
    }

    public void MessageTwo(string message)
    {
        NewMessage = message;
        OldMessage = NewMessage;
        MessageOutput($"{GetCurrentTime(OptionTime.MinuteSecond)} : {OldMessage}");
    }

    public void Tick() { }

    public string GetCurrentTime(OptionTime type)
    {
        if (type == OptionTime.HourMinuteSecond) return $"{DateTime.Now.Hour}h:{DateTime.Now.Minute}m:{DateTime.Now.Second}s";
        else if (type == OptionTime.HourMinut) return $"{DateTime.Now.Hour}h:{DateTime.Now.Minute}m";
        else if (type == OptionTime.Hour) return $"{DateTime.Now.Hour}h";
        else if (type == OptionTime.MinuteSecond) return $"{DateTime.Now.Minute}m:{DateTime.Now.Second}s";
        else if (type == OptionTime.Minute) return $"{DateTime.Now.Minute}m";
        else if (type == OptionTime.Second) return $"{DateTime.Now.Second}s";
        return $"Error";
    }

    public void MessageOutput(string message)
    {
        TextGameLog.text += $"\n {message}";
        TextLimit();
    }

    private void TextLimit()
    {
        var Quantity = TextGameLog.text.Length;
        if (Quantity > Limit)
        {
            int DynamicIndex = Quantity;
            DynamicIndex = DynamicIndex - Limit;
            TextGameLog.text = TextGameLog.text.Remove(0, DynamicIndex);
        }
    }
}