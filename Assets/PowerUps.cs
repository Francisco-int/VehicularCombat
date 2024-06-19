using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PowerUps : MonoBehaviour
{
    [Tooltip("")] public PowerUpType currentPowerUp = PowerUpType.none;
   


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && currentPowerUp == PowerUpType.Velocity)
        {
            Velocity();
        }
        

        if (Input.GetKey(KeyCode.E) && currentPowerUp == PowerUpType.SuperJump)
        {
            SuperJump();
        }
       
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && currentPowerUp == PowerUpType.Push && Input.GetKey(KeyCode.E))
        {
            //Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            //Vector3 pushAway = (collision.gameObject.transform.position - transform.position);

            //rb.AddForce(pushAway * pushForce, ForceMode.Impulse);
        }
    }
    void Velocity()
    {
        
    }

    void SuperJump()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            currentPowerUp = other.gameObject.GetComponent<PowerUPSelector>().powerUpType;
        }
    }
}