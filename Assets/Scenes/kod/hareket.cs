using UnityEngine;
using System.Collections;

public class hareket : MonoBehaviour
{

   Touch parmak;
   public  float hiz, konum,mesafe;
    int sayac = 0;
    public GameObject kamera,spawnPoint,pota,ghost, menuPanel,potaSes,carpmaSes,blokSes ;
    Rigidbody rb;
    Vector3 pos;
    int sayaac = 0;
    public  ParticleSystem parti;
    void Start()
    {
        Time.timeScale = 0;
        menuPanel = GameObject.Find("basla");
        
        carpmaSes = GameObject.Find("carpmaSes");
        blokSes = GameObject.Find("blokSes");
        spawnPoint = GameObject.Find("ghost");
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        pota = GameObject.Find("pota");
        ghost = GameObject.Find("ghost");
        potaSes = GameObject.Find("potaSes");
    }
    public void kaybet()
    {
        Time.timeScale = 1;
        menuPanel.SetActive(false);
    }
    
    void Update()
    {
        if(Input.GetKey("escape"))
        {
            Application.Quit();
        }
        mesafe = Vector3.Distance(pota.transform.position, ghost.transform.position);
        Debug.Log("" + mesafe);
    }
    void kontrol()
    {
        if (sayac ==3)
        {
            //gameObject.SetActive(false);
            transform.parent = kamera.transform;
            rb.useGravity = false;
            sayac = 0;
            rb.isKinematic = true;
            transform.localRotation = Quaternion.identity;
            transform.localPosition = Vector3.zero;
            transform.position = spawnPoint.transform.position;
            //kamera = GameObject.Find("Camera");
        }      
     }


    public void atis()
    {
      if (Input.GetMouseButtonDown(0))
           {
                konum = Input.mousePosition.y;
        
            }
        if (Input.GetMouseButtonUp(0))
        {
            sayac = 1;
            hiz = konum - Input.mousePosition.y;
        }
         rb.isKinematic = false;
        rb.useGravity = true;
        rb.AddForce(-transform.up * hiz/1.2f);
        transform.parent = null;
        rb.AddForce(-transform.forward * hiz);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "duvar")
        {
            carpmaSes.GetComponent<AudioSource>().Play();
            sayac++;
            kontrol();
        }
        if(other.gameObject.tag=="pota")
        {
            potaSes.GetComponent<AudioSource>().Play();
        }
        if (other.gameObject.tag == "blok")
        {
            blokSes.GetComponent<AudioSource>().Play();
        }
       
    }
    
   public void reset()
    {
        Time.timeScale = 1;
        Application.LoadLevel(0);
    }
}
