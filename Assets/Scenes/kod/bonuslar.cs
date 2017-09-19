using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class bonuslar : MonoBehaviour {


    public GameObject timee;
    float zaman,zaman2;
     sure kontrol;
    void Start()
    { 
        kontrol=GameObject.Find("sureZaman").GetComponent<sure>();
    }
    void spawn()
    {
        Instantiate(timee, transform.position, Quaternion.identity);
    }
   
    void Update()
    {
        zaman += Time.deltaTime;
         if(kontrol.zaman>0)
        if (zaman > Random.RandomRange(15f, 17f) && zaman < Random.RandomRange(17f, 19f)) 
        {
            Invoke("spawn", Random.RandomRange(6f, 12f));
            zaman = 0;
        }
        
       
    }
}
