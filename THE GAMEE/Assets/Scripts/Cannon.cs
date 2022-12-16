using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    public GameObject boca;
    public float delayToShoot;
    public float waitforBullet;
    AudioSource audioTrack;

  
    
    [SerializeField]
    float bulletSpeed;
    [SerializeField]
    float startDelayTime;
    float delay;
    bool fire;
    void Start()
    {
        delay = startDelayTime;
        fire = true;
        audioTrack = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        delay = (delay > 0) ? delay - Time.deltaTime : 0;
        if (delay<=0&&fire)
        {
            StartCoroutine(Shoot());
            fire = false;
        }
    }

   

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(delayToShoot);
        while (true)
        {
            audioTrack.Play();
            GameObject bulletNew = Instantiate(bullet, boca.transform.position, boca.transform.rotation);
            bulletNew.GetComponent<Rigidbody>().AddForce(boca.transform.forward * bulletSpeed, ForceMode.Impulse);
            yield return new WaitForSeconds(waitforBullet);
        }


    }

}
