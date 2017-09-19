using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class sure : MonoBehaviour {
    public float zaman=5,sesZaman;
    public GameObject puan,anaButon,sureSes;
    Rigidbody top;
    blokKod blok;
    public AudioClip ses2;
    bonuslar bonus;
    public Text zamanText,highScore,sonSaniye;
   void Start()
    {
        sureSes = GameObject.Find("sureSes");
        top = GameObject.Find("top").GetComponent<Rigidbody>();
        sonSaniye.gameObject.SetActive(false);
        puan = GameObject.Find("PUAN");
        puan.SetActive(false);
        anaButon = GameObject.Find("anaButton");    
    }
   void spawn()
    {

        //Time.timeScale = 0;
        anaButon.SetActive(false);
        puan.SetActive(true);
        highScore.text =""+PlayerPrefs.GetInt("yuksekPuan");
    }
    
  
    void Update ()
    {
        zaman -= Time.deltaTime;
        zamanText.text = "" + zaman;
        if (zaman < 20) 
        {
            zamanText.GetComponent<Animation>().Play("sureAnim");
        }
        if (zaman <= 10)
        {
            sesZaman += Time.deltaTime;
            if (sesZaman > 0.9f&& sesZaman < 3) 
            {
                sureSes.GetComponent<AudioSource>().Play();
                sesZaman = 0;
            }

            //sureSes.GetComponent<AudioSource>().PlayOneShot(ses2,0.5f);
            sonSaniye.gameObject.SetActive(true);
            sonSaniye.text = "" +Mathf.Round(zaman);
        }
        if(zaman>10)
        {
            sonSaniye.gameObject.SetActive(false);
        }
            if (zaman <= 0)
        {
            sureSes.GetComponent<AudioSource>().Stop();
            zamanText.text = ""+0;
            sonSaniye.gameObject.SetActive(false);
            Invoke("spawn",1);
        }
           
        
        
	}
}
