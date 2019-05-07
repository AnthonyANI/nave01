using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public static int WinCount = 0;
    public static int HopCount = 0;
    public static int FailCount = 0;

    public Text winCountText;
    public Text hopCountText;


    void Update()
    {
        if (winCountText)
            winCountText.text = "Wins: " + WinCount.ToString();

        if (hopCountText)
            hopCountText.text = "Hops: " + HopCount.ToString();
    }

    public static void UpdateWins(int valueToAdd = 1, bool resetWins = false)
    {
        WinCount = resetWins ? 0 : WinCount;
        WinCount += valueToAdd;
    }

    public static void UpdateHops(int valueToAdd = 1, bool resetHops = false)
    {
        HopCount = resetHops ? 0 : HopCount;
        HopCount += valueToAdd;
    }

    public static void UpdateFails(int valueToAdd = 1, bool resetFails = false)
    {
        FailCount = resetFails ? 0 : FailCount;
        FailCount += valueToAdd;
    }

}
