using UnityEngine;
using System.Collections;

public class donder : MonoBehaviour {


    float zaman,rast;
    void Start()
    {
        rast = Random.Range(1f, 5f);
    }
	void Update ()
    {
        zaman += Time.deltaTime;

        if (rast > 3)
            transform.Translate(new Vector3(0,Time.deltaTime*0.2f,0));
        if(rast<3)
            transform.Translate(new Vector3(0, Time.deltaTime * 0.2f, 0));
        if (zaman > 6 && zaman < 8)
        {
            Destroy(this.gameObject);
            zaman = 0;
        }
    }
}
