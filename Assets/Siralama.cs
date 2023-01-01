using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siralama : MonoBehaviour
{
    public int AktifYonSirasi = 1; //field
    SiralamaYonetim siralama;
    public int pozisyon;
    Genelayarlar genelayarlar;
    private void Start()
    {
        siralama = GameObject.FindWithTag("OyunKontrol").GetComponent<SiralamaYonetim>();
        siralama.kendinigonder(gameObject, AktifYonSirasi);
        genelayarlar = GameObject.FindWithTag("OyunKontrol").GetComponent<Genelayarlar>();
        genelayarlar.kendinigonder(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GidisYonuObje"))
        {
            AktifYonSirasi = int.Parse(other.transform.gameObject.name);
            siralama.siralamaGuncelle(gameObject, AktifYonSirasi);
            Debug.Log("Carpti");
        }
        if (gameObject.name == "Biz")
        {
            if (other.CompareTag("Finish"))
            {
                genelayarlar.OyunSonu(pozisyon);
            }
        }


    }
}
