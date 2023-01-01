using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class settingsscript : MonoBehaviour
{
    public Slider menuvoiceSlider;
    public Slider gamevoiceSlider;
    AudioSource MenuVoice;
    public Dropdown qualityOptions;

    private void Start()
    {
        MenuVoice = GameObject.Find("OyunKontrol").GetComponent<AudioSource>();
        menuvoiceSlider.value = PlayerPrefs.GetFloat("menuses");
        menuvoiceSlider.value = PlayerPrefs.GetFloat("oyunses");
    }
    public void MenuVoiceChanged()
    {
        PlayerPrefs.SetFloat("menuses", menuvoiceSlider.value);
        MenuVoice.volume=menuvoiceSlider.value;
    }
    public void GameVoiceChanged()
    {
        PlayerPrefs.SetFloat("oyunses", gamevoiceSlider.value);
    }
    public void qualityselection(int choice)
    {
        PlayerPrefs.SetInt("Kalite", choice);

        QualitySettings.SetQualityLevel(choice);

    }
}
