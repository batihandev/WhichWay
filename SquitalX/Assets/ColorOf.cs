using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorOf : MonoBehaviour
{
    public Material[] materials;
    Material whichmats;
    int random;
    int whichmatcount;
   
    // Start is called before the first frame update
    void Awake()
    {
        switch (Spawner.whichcube)
        {
            case 0:
                int[] list0 = { 1, 2, 3 };
                random = Random.Range(0, list0.Length);
                whichmatcount = list0[random];
                whichmats = materials[whichmatcount];
                gameObject.GetComponent < MeshRenderer >().material= whichmats;
                break;
            case 1:
                int[] list1 = { 0, 2, 3 };
                random = Random.Range(0, list1.Length);
                whichmatcount = list1[random];
                whichmats = materials[whichmatcount];
                gameObject.GetComponent<MeshRenderer>().material = whichmats;
                break;
            case 2:
                int[] list2 = { 0, 1,  3 };
                random = Random.Range(0, list2.Length);
                whichmatcount = list2[random];
                whichmats = materials[whichmatcount];
                gameObject.GetComponent<MeshRenderer>().material = whichmats;
                break;
            case 3:
                int[] list3 = { 0, 1, 2 };
                random = Random.Range(0, list3.Length);
                whichmatcount = list3[random];
                whichmats = materials[whichmatcount];
                gameObject.GetComponent<MeshRenderer>().material = whichmats;
                break;

        }
        Debug.Log("Hangiküb" + Spawner.whichcube + "Hangimat" + whichmats+"portalnumber"+ChosePortal.portalnumber);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
