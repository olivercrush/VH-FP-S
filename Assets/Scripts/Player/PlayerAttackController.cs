using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    public GameObject weapon;
    private GameObject _camera;

    void Start()
    {
        _camera = transform.Find("Camera").gameObject;
    }

    public void Shoot()
    {
        Ray shootRay = new Ray(_camera.transform.position, _camera.transform.forward);
        weapon.GetComponent<Weapon>().Fire(shootRay);
    }
}
