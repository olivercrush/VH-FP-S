using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float movementSpeed = 1f;
    private GameObject _body;

    private void Start()
    {
        _body = transform.Find("Body").gameObject;
    }

    public void MovePlayer(int moveX, int moveY)
    {
        if (ObstacleHelper.CheckForObstacles(_body.transform.position, ((_body.transform.forward * moveY) + (_body.transform.right * -moveX)), 0.4f))
        {
            transform.Translate(moveY * _body.transform.forward * Time.deltaTime * movementSpeed);
            transform.Translate(-moveX * _body.transform.right * Time.deltaTime * movementSpeed);
        }
    }
}
