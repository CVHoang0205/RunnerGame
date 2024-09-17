using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CointText : MonoBehaviour
{
    public static int cointCount;
    public TextMeshProUGUI coinCountDisplay;
    public TextMeshProUGUI coinEndDisplay;

    // Update is called once per frame
    void Update()
    {
        coinCountDisplay.GetComponent<TextMeshProUGUI>().text = "" + cointCount;
        coinEndDisplay.GetComponent<TextMeshProUGUI>().text = "" + cointCount;
    }
}
