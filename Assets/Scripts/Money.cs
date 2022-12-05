using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public float moneyPerMilliseconds;
    public float moneyPerSeconds;
    public float money;
    public float cost;

    public Text moneyText;
    void Update()
    {
        moneyText.text = "money:  " + money.ToString("N0") + "   G";

        moneyPerMilliseconds += moneyPerSeconds;

        if (moneyPerMilliseconds >= 1000)
        {
            moneyPerMilliseconds = moneyPerSeconds;
            money += 1;
        }
    }
}
