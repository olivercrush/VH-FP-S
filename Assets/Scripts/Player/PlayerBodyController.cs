using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBodyController : MonoBehaviour
{
    private GameObject _camera;

    private void Start()
    {
        _camera = transform.parent.Find("Camera").gameObject;
    }

    private void Update()
    {
        transform.localEulerAngles = new Vector3(0, _camera.transform.localEulerAngles.y, 0);
    }
}
