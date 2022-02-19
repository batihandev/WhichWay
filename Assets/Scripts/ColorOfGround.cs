
using UnityEngine;

public class ColorOfGround : MonoBehaviour
{
    public Material[] materials;
    Material whichMats;
    int random;
    int whichMatCount;
    public static bool ýsCubeGoneGround = false;
    public GameObject objectCheck;

    // Start is called before the first frame update
    void Awake()
    {
       // ColorChanger();
        int[] list0 = { 1, 2, 3 };
        random = Random.Range(0, list0.Length);
        whichMatCount = list0[random];
        whichMats = materials[whichMatCount];
        gameObject.GetComponent<MeshRenderer>().material = whichMats;
    }

    // Update is called once per frame
    void Update()
    {
        if (ýsCubeGoneGround )
        {
            ColorChanger();

        }
    }
    void ColorChanger()
    {
        switch (Spawner.whichCube)
        {
            case 0:
                int[] list0 = { 1, 2, 3 };
                random = Random.Range(0, list0.Length);
                whichMatCount = list0[random];
                whichMats = materials[whichMatCount];
                gameObject.GetComponent<MeshRenderer>().material = whichMats;
                break;
            case 1:
                int[] list1 = { 0, 2, 3 };
                random = Random.Range(0, list1.Length);
                whichMatCount = list1[random];
                whichMats = materials[whichMatCount];
                gameObject.GetComponent<MeshRenderer>().material = whichMats;
                break;
            case 2:
                int[] list2 = { 0, 1, 3 };
                random = Random.Range(0, list2.Length);
                whichMatCount = list2[random];
                whichMats = materials[whichMatCount];
                gameObject.GetComponent<MeshRenderer>().material = whichMats;
                break;
            case 3:
                int[] list3 = { 0, 1, 2 };
                random = Random.Range(0, list3.Length);
                whichMatCount = list3[random];
                whichMats = materials[whichMatCount];
                gameObject.GetComponent<MeshRenderer>().material = whichMats;
                break;

        }
        ýsCubeGoneGround = false;
        //Debug.Log("GroundColorÇALIÞTI"+"Hangiküb" + Spawner.whichcube + "Hangimat" + whichmats + "portalnumber" + ChosePortal.portalnumber);
    }
}
