
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volSlider;
    public TMPro.TMP_Dropdown qualityD;
    float volume;
    int indexQ;
    public GameObject optionsMenu;
    
    private void Start()
    {
        
        volume = PlayerPrefs.GetFloat("Volume",0.5f);
        indexQ = PlayerPrefs.GetInt("indexQ",2);
        qualityD.value = indexQ;
        //Debug.Log(indexQ+"indexq");
        volSlider.value = volume;
        QualitySettings.SetQualityLevel(indexQ);
        audioMixer.SetFloat("Volume", Mathf.Log10(volume)*20);
    }

    public void SetVolume(float volume)
    {

        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
        //Debug.Log(Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
        

    }

    public void SetQuality(int indexQ)
    {
        QualitySettings.SetQualityLevel(indexQ);
        //Debug.Log(indexQ + "indexq");
        PlayerPrefs.SetInt("indexQ", indexQ);
        PlayerPrefs.Save();
    }
    public void soundE()
    {
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<SaveMe>().PlaySound();
    }
    public void SignIn()
    {
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<GPSmanager>().BasicSignInBtn();
    }
    public void SignOut()
    {
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<GPSmanager>().SignOutBtn();
    }
    public void ActivatePanel()
    {
        
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<GPSmanager>().panelActive();
        

    }
    public void DeactivatePanel()
    {
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<GPSmanager>().panelDeactive();
        optionsMenu.SetActive(true);
    }
    public void ShowAchievements()
    {
        GameObject.FindGameObjectWithTag("ButtonClick").GetComponent<GPSmanager>().ShowAchievementsUI();
    }

}
