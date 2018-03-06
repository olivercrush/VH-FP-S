using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private float fireRate;
    private bool isCoolingDown;
    private Animation fireAnim;

	void Start ()
    {
        fireRate = 0.1f;
        isCoolingDown = false;
        fireAnim = GetComponent<Animation>();
    }

    public void Fire(Ray shootRay)
    {
        if (!isCoolingDown)
        {
            fireAnim.Play(fireAnim.clip.name);
            Debug.DrawLine(shootRay.origin, shootRay.origin + shootRay.direction * 3, Color.red, 5);
            Debug.Log("Shoot !");
            isCoolingDown = true;
            Invoke("Cooldown", fireRate);
        }
    }

    private void Cooldown()
    {
        isCoolingDown = false;
    }
}
