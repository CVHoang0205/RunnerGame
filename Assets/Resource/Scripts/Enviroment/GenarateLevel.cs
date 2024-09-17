using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenarateLevel : Singleton<GenarateLevel>
{
    public GameObject[] section;
    public int zPos = 39;
    public bool creatingSection = false;
    public int SecNum;

    public void StartGenarateLevel()
    {
        if (creatingSection == false) 
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }
    }

    IEnumerator GenerateSection() 
    {
        while (true) 
        {
            SecNum = Random.Range(0, 4);
            Instantiate(section[SecNum], new Vector3(0, 0, zPos), Quaternion.identity);
            zPos += 39;
            yield return new WaitForSeconds(2.5f);
        }
    }

    public void ResetGeneration()  
    {
        zPos = 35;
        creatingSection = false;
    }
}
