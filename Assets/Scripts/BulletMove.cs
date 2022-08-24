using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    Vector3 lookPos;
    Rigidbody rb;
    [SerializeField] GameObject player;
    [SerializeField] float bulletSpeed=100.0f;
    [SerializeField] ParticleSystem bloodEffect;
    GameObject blood;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            blood.SetActive(true);
        }
        
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        BulletMovement();
        blood = this.gameObject.transform.GetChild(0).gameObject;
        blood.SetActive(false);
    }

   

    // Update is called once per frame
    
    private void BulletMovement()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit raycastHit;

        if (Physics.Raycast(ray, out raycastHit, 100))
        {
            lookPos = raycastHit.point;
        }

        Vector3 lookDir = lookPos - transform.position; //yakýndaki bir objeyi vurmak istdediðimiz zaman lookDir deðeri çok küçük oluyor o yüzden mermi çok yavaþ þekilde gidiyor.
        Debug.Log(lookDir);

        
        rb.AddForce(lookDir*bulletSpeed*Time.deltaTime, ForceMode.Impulse);
    }
}
