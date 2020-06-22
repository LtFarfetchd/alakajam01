using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Plant : MonoBehaviour
{

    public Animator PlantAnim;
    public Transform SporePoint;
    public GameObject Spore;
    public bool ShouldShoot;
    public Transform Parent;
    // Start is called before the first frame update
    void Start()
    {
        ShouldShoot = false;
        PlantAnim = GetComponentInChildren<Animator>();
        Parent = GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //public void ShootSpore() 
    //{
    //    if (ShouldShoot == true)
    //    {
    //        Instantiate(Spore, SporePoint.transform.position, Parent.rotation);
    //        //transform.forward*

    //        ShouldShoot = false;

    //    }
    //}
    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.tag == "Player")
            
        {
            Debug.Log("PLAYER DETECTED");
            ShouldShoot = true;
            PlantAnim.SetBool("PlayerDetected", true);
            PlantAnim.Play("Plant_Shoot");
             //ShootSpore();
            StartCoroutine(ShootSpore());
        }
        
    }
    private void OnTriggerExit2D(Collider2D Other)
    {
        if (Other.gameObject.tag == "Player") 
        
        {
            PlantAnim.SetBool("PlayerDetected", false);
            ShouldShoot = false;
        }
        
            
        
    }

    public IEnumerator ShootSpore()
    {
        if (ShouldShoot == true)
        {
            Instantiate(Spore, SporePoint.transform.position, transform.rotation);
            //transform.forward*

            ShouldShoot = false;

        }
        else
        {
            yield return new WaitForSeconds(2);
            ShouldShoot = true;
        }

    }

}
