using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fusion;

public class CarPlayer : NetworkBehaviour
{

    [SerializeField] int vida;
    [SerializeField] GunaVehicular gunaVehicular;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(transform.position.y <= -20)
        {
            SceneManager.LoadScene(0);
        } 
    }
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag("Bala"))
        //{
        //    vida--;
        //    if(vida == 0)
        //    {
        //        //ff
        //    }
        //}
        if (collision.gameObject.CompareTag("Force"))
        {
            StartCoroutine(ForceShot());
        }
        if (collision.gameObject.CompareTag("Interval"))
        {
            StartCoroutine(InvertaloShot());
        }
    }

    IEnumerator InvertaloShot()
    {
        gunaVehicular.intervalShot = 0.3f;
        yield return new WaitForSeconds(30);
        gunaVehicular.intervalShot = 1;
    }

    IEnumerator ForceShot()
    {
        gunaVehicular.forceShot = 17000;
        yield return new WaitForSeconds(30);
        gunaVehicular.intervalShot = 10000;
    }
}
