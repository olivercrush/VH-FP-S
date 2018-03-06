using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpController : MonoBehaviour
{
    public float jumpHeight = 5f;

    private bool isJumping;
    private GameObject _body;

    private void Start()
    {
        _body = transform.Find("Body").gameObject;
        isJumping = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
            isJumping = false;
    }

    public void Jump()
    {
        GameObject obstacle = ObstacleHelper.ReturnObstacle(_body.transform.position, _body.transform.forward, 0.4f);

        if (obstacle != null)
        {
            if (_body.transform.position.y > obstacle.transform.position.y)
            {
                GrabLedge(obstacle);
                return;
            }
        }

        if (!isJumping)
        {
            isJumping = true;
            GetComponent<Rigidbody>().velocity = Vector3.Lerp(_body.transform.position, Vector3.up * jumpHeight, 1);
        }
    }

    public void GrabLedge(GameObject obstacle)
    {
        Debug.Log("Grab ledge !");
    }
}
