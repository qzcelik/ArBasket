using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class puanlama : MonoBehaviour {

    public Text puan;
     hareket mesafeAl;
    public GameObject skor,ses;
    public ParticleSystem parti;
    int a=0;
    void Start()
    {
        ses = GameObject.Find("puanSes");
        skor = GameObject.Find("score");
        mesafeAl = GameObject.Find("top").GetComponent<hareket>();
        
    }
     void OnTriggerEnter(Collider other)
    {
  
        if(other.tag=="top")
        {
            ses.GetComponent<AudioSource>().Play();
            skor.GetComponent<Animation>().Play("puanAnim");
            parti.Play();
            if (mesafeAl.mesafe >= 1 && mesafeAl.mesafe <47) 
            a += 2;
            if(mesafeAl.mesafe>=47.1f)
            a += 3;
            puan.text =a+"";
        }
    }
    void Update()
    {
        if (PlayerPrefs.GetInt("yuksekPuan") < a)
        {
            PlayerPrefs.SetInt("yuksekPuan", a);
        }
    }
}
