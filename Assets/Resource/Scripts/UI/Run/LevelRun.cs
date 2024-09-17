using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelRun : Singleton<LevelRun>
{
    public GameObject disPlays;
    public GameObject disEndPlas;
    public static int countRun;
    public bool addingDis = false;
    public bool StopcountRun = false;

    // Update is called once per frame
    void Update()
    {
        if (addingDis == false && StopcountRun == false)
        {
            addingDis = true;
            StartCoroutine(AddingDis());
        }
    }

    IEnumerator AddingDis() 
    {
        countRun++;
        disPlays.GetComponent<TextMeshProUGUI>().text = "" + countRun;
        disEndPlas.GetComponent<TextMeshProUGUI>().text = "" + countRun;
        yield return new WaitForSeconds(0.35f);
        addingDis = false;
    }

    public void StopRun() 
    {
        StopcountRun = true;
    }

    public void ResetRunCount()  
    {
        countRun = 0;
        StopcountRun = false;
        disPlays.GetComponent<TextMeshProUGUI>().text = "0";
        disEndPlas.GetComponent<TextMeshProUGUI>().text = "0";
    }
}
