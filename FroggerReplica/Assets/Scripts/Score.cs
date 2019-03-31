using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public static int WinCount = 0;
    public static int HopCount = 0;
    public static int FailCount = 0;

    public Text winCountText;
    public Text hopCountText;
    public Text failCountText;


    void Update()
    {
        if (winCountText)
            winCountText.text = "Wins: " + WinCount.ToString();

        if (hopCountText)
            hopCountText.text = "Hops: " + HopCount.ToString();

        if (failCountText)
            failCountText.text = "Fails: " + FailCount.ToString();
    }

    public static void updateWins(int valueToAdd = 1, bool resetFails = false)
    {
        WinCount = resetFails ? 0 : WinCount;
        WinCount += valueToAdd;
    }

    public static void updateHops(int valueToAdd = 1, bool resetFails = false)
    {
        HopCount = resetFails ? 0 : HopCount;
        HopCount += valueToAdd;
    }

    public static void updateFails(int valueToAdd = 1, bool resetFails = false)
    {
        FailCount = resetFails ? 0 : FailCount;
        FailCount += valueToAdd;
    }

}
