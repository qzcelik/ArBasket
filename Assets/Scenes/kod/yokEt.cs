using UnityEngine;
using System.Collections;

public class yokEt : MonoBehaviour {
    public GameObject zaman,zamanSes;
    void Start()
    {
        zamanSes = GameObject.Find("saatSes");
        zaman = GameObject.Find("sureZaman");
    }
    void spawn()
    {
        Destroy(this.gameObject);
    }
 	void OnTriggerEnter(Collider other)
    {
        if (other.tag == "top")
        {
            zamanSes.GetComponent<AudioSource>().Play();
            zaman.GetComponent<sure>().zaman += 10;
            Invoke("spawn",0.2f);
        }
    }
    void Update()
    {
        Destroy(gameObject,5);
    }
}
