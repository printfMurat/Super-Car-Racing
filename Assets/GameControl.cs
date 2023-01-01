using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    private static GameControl gamecontrolinstance;
    AudioSource MenuVoice;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this);
        if(gamecontrolinstance == null)
        {
            gamecontrolinstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {

        MenuVoice = GetComponent<AudioSource>();
        
        

        if (PlayerPrefs.HasKey("menuses"))
        {
            MenuVoice.volume = PlayerPrefs.GetFloat("menuses");
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Kalite"));


        }
        else
        {
            //Oyun ilk kez acýlýyor
            PlayerPrefs.SetFloat("menuses", 1);
            PlayerPrefs.SetFloat("oyunses", 1);
            PlayerPrefs.SetInt("kalite", 3);
           
        }
      
    }
  


}
