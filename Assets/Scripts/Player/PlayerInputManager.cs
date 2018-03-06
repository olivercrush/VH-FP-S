using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    private PlayerCameraController _cameraController;
    private PlayerMovementController _movementController;
    private PlayerJumpController _jumpController;
    private PlayerAttackController _attackController;

    void Start ()
    {
        _cameraController = GetComponentInChildren<PlayerCameraController>();
        _movementController = GetComponent<PlayerMovementController>();
        _jumpController = GetComponent<PlayerJumpController>();
        _attackController = GetComponent<PlayerAttackController>();

        Cursor.visible = false;
	}
	
	void Update ()
    {
        ManageClickInput();
        ManageMouseAxisInput();
        ManageMovementInput();
        ManageJumpInput();
    }

    private void ManageClickInput()
    {
        if (Input.GetMouseButton(0))
            _attackController.Shoot();
    }

    private void ManageMouseAxisInput()
    {
        _cameraController.ChangeRotation(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }

    private void ManageMovementInput()
    {
        int moveX = 0;
        int moveY = 0;

        // Movements on the X Axis
        if (Input.GetKey(KeyCode.W))
            moveY++;

        if (Input.GetKey(KeyCode.S))
            moveY--;

        // Movements on the Y Axis
        if (Input.GetKey(KeyCode.A))
            moveX++;

        if (Input.GetKey(KeyCode.D))
            moveX--;

        _movementController.MovePlayer(moveX, moveY);
    }

    private void ManageJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _jumpController.Jump();
    }
}
