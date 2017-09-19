using UnityEngine;
using System.Collections;

public class blokKod : MonoBehaviour {

    int sayac = 0;
    public GameObject blokObje;
    sure kontrol;
    float zaman;
    void Start()
    {
        kontrol = GameObject.Find("sureZaman").GetComponent<sure>();
    }
    void spawn2()
    {
        Instantiate(blokObje, transform.position, Quaternion.identity);
    }
    void Update()
    {
         zaman += Time.deltaTime;
        if (kontrol.zaman > 0) 
            if (zaman > Random.RandomRange(12f, 13f) && zaman < Random.RandomRange(13f, 14f))
        {
            Invoke("spawn2", Random.RandomRange(6f, 12f));
            zaman = 0;
        }
    }
}
