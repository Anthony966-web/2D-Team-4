using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform FirePiont;
    public GameObject BulletPrefab;

    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(BulletPrefab, FirePiont.position, FirePiont.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(FirePiont.up * bulletForce, ForceMode2D.Impulse);
        StartCoroutine(ShootBullet(bullet));
    }

    private IEnumerator ShootBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(2f);
        Destroy(bullet);
    }

}
