using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorOfGround : MonoBehaviour
{
    public Material[] materials;
    Material whichmats;
    int random;
    int whichmatcount;
    public static bool iscubegoneground = false;
    public GameObject objectcheck;

    // Start is called before the first frame update
    void Awake()
    {
        ColorChanger();

    }

    // Update is called once per frame
    void Update()
    {
        if (iscubegoneground)
        {
            ColorChanger();

        }
    }
    void ColorChanger()
    {
        switch (Spawner.whichcube)
        {
            case 0:
                int[] list0 = { 1, 2, 3 };
                random = Random.Range(0, list0.Length);
                whichmatcount = list0[random];
                whichmats = materials[whichmatcount];
                gameObject.GetComponent<MeshRenderer>().material = whichmats;
                break;
            case 1:
                int[] list1 = { 0, 2, 3 };
                random = Random.Range(0, list1.Length);
                whichmatcount = list1[random];
                whichmats = materials[whichmatcount];
                gameObject.GetComponent<MeshRenderer>().material = whichmats;
                break;
            case 2:
                int[] list2 = { 0, 1, 3 };
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
        iscubegoneground = false;
        Debug.Log("GroundColorÇALIÞTI"+"Hangiküb" + Spawner.whichcube + "Hangimat" + whichmats + "portalnumber" + ChosePortal.portalnumber);
    }
}
