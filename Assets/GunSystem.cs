using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSystem : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera cam;
    public Animator anim;
    private float fireRate = 0.2f; //ändra till önskat värde
    private float nextFire = 0f;
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
            anim.Play("FirePistol");
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            anim.Play("New State");
        }
    }
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
