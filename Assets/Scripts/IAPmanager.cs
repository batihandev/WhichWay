using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPmanager : MonoBehaviour
{
    // Start is called before the first frame update
    private string removeAds = "com.vexedev.whichway.removeads";
    public void OnPurchaseComplete(Product product)
    {
        if (product.definition.id == removeAds)
        {
            StartScreen.ad = "7TjqzjL(#>F^zqDrr-D>UFjq>";
            OnClick.starClickCount++;
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().CreatePlayerData();
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().SaveData();
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<GoogleADMOBmanager>().DestroyBannerAd();
            PlayerPrefs.SetInt("removeAds", 1);
            Debug.Log("all ads removed");
        }

    }
    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        if (failureReason == PurchaseFailureReason.DuplicateTransaction)
        {
            StartScreen.ad = "7TjqzjL(#>F^zqDrr-D>UFjq>";
            OnClick.starClickCount++;
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().CreatePlayerData();
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<JSONSaving>().SaveData();
            GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<GoogleADMOBmanager>().DestroyBannerAd();
            PlayerPrefs.SetInt("removeAds", 1);
            Debug.Log("all ads removed");
        }
        else
        { 
            
            Debug.Log(product.definition.id + " failed because" + failureReason);
        }
        
    }
}
