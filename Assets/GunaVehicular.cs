using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunaVehicular : MonoBehaviour
{

    [SerializeField] float intervalShot;
    [SerializeField] GameObject proyectil;
    [SerializeField] Transform pointShot;
    [SerializeField] bool ableDisparo;



    // Start is called before the first frame update
    void Start()
    {
        ableDisparo = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.F) && ableDisparo == true)
        {
            ableDisparo = false;
            StartCoroutine(Disparo());
            Debug.Log("Disparo Metodo llamado");
        }
    }
    IEnumerator Disparo()
    {
        Debug.Log("Disparo");
        //Instantiate(proyectil, pointShot);
        yield return new WaitForSeconds(intervalShot);
        ableDisparo = true;
    }
}
