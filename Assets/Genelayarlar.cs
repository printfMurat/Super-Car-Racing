using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class Genelayarlar : MonoBehaviour
{
    public GameObject[] Araclar;
    public GameObject Spawnnoktasi;
    public GameObject[] YapayZekaSpawnNoktalari;
    public GameObject[] YapayZekaAraclari;
    public AudioSource[] Seslerimiz;
    public GameObject OyunSonuPanel;

    public List<GameObject> OlusanArabalar = new List<GameObject>();


    void Start()
    {

        baslangicislemleri();
        Seslerimiz[0].volume = PlayerPrefs.GetFloat("oyunses");

    }
    void baslangicislemleri()
    {
    
        GameObject arabam = Instantiate(Araclar[PlayerPrefs.GetInt("SecilenArac")], Spawnnoktasi.transform.position, Spawnnoktasi.transform.rotation);

        GameObject.FindWithTag("MainCamera").GetComponent<kameraKontrol>().target[0] = arabam.transform.Find("PozisyonAl");
        GameObject.FindWithTag("MainCamera").GetComponent<kameraKontrol>().target[1] = arabam.transform.Find("Pivot");

        GameObject.FindWithTag("OyunKontrol").GetComponent<KameraGecisKontrol>().kameralar[1] = arabam.transform.Find("Kameralar/OnKaput").gameObject;
        GameObject.FindWithTag("OyunKontrol").GetComponent<KameraGecisKontrol>().kameralar[2] = arabam.transform.Find("Kameralar/Aracici").gameObject;

        for (int i = 0; i < 3; i++)
        {
            int randomdeger = Random.Range(0, YapayZekaAraclari.Length - 1);

            GameObject OlusanArac = Instantiate(YapayZekaAraclari[randomdeger], YapayZekaSpawnNoktalari[i].transform.position, YapayZekaSpawnNoktalari[i].transform.rotation);
            OlusanArac.GetComponent<YapayZekaController>().spawnNoktasiİndex = i;
           
        }
        

    }
    public void kendinigonder(GameObject gelenobje)
    {
        OlusanArabalar.Add(gelenobje);
    }
    public void OyunSonu(int pozisyon)
    {
        OyunSonuPanel.SetActive(true);
        OyunSonuPanel.transform.Find("Panel/sira").GetComponent<TextMeshProUGUI>().text = pozisyon.ToString() + ". Place";
    }
  
}
