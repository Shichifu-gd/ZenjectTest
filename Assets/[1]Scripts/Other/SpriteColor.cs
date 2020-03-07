using UnityEngine;

public class SpriteColor
{
    private string ColorAnger = "DD5F5F";
    private string ColorCalm;

    public SpriteColor(Color colorCalm)
    {
        ColorCalm = GetStringFromColor(colorCalm);
    }

    public void SetColorAngre(string value) { ColorAnger = value; }

    public void SetColorCalm(string value) { ColorCalm = value; }

    public Color GetColorAnger()
    {
        return GetColorFromString(ColorAnger);
    }

    public Color GetColorCalm()
    {
        return GetColorFromString(ColorCalm);
    }

    private Color GetColorFromString(string hexString)
    {
        float red = HexToFloatNormalized(hexString.Substring(0, 2));
        float green = HexToFloatNormalized(hexString.Substring(2, 2));
        float blue = HexToFloatNormalized(hexString.Substring(4, 2));
        float alpha = 0.5f; // TODO: Fix
        if (hexString.Length >= 8) alpha = HexToFloatNormalized(hexString.Substring(6, 2));
        return new Color(red, green, blue, alpha);
    }

    private string GetStringFromColor(Color color, bool useAlpha = false)
    {
        string red = FloatNormalizedToHex(color.r);
        string green = FloatNormalizedToHex(color.g);
        string blue = FloatNormalizedToHex(color.b);
        if (!useAlpha) return red + green + blue;
        else
        {
            string alpha = FloatNormalizedToHex(color.a);
            return red + green + blue + alpha;
        }
    }

    private int HexToDec(string hex)
    {
        int dec = System.Convert.ToInt32(hex, 16);
        return dec;
    }

    private string DecToHex(int value)
    {
        return value.ToString("X2");
    }

    private string FloatNormalizedToHex(float value)
    {
        return DecToHex(Mathf.RoundToInt(value * 255f));
    }

    private float HexToFloatNormalized(string hex)
    {
        return HexToDec(hex) / 255f;
    }
}