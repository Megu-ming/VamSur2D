using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 _moveDir = Vector2.zero;
    float moveSpeed = 5f;

    public Vector2 MoveDir
    {
        get { return _moveDir; }
        set { _moveDir = value.normalized; }
    }

    private void Update()
    {
        //UpdateInput();
        MovePlayer();
    }

    private void UpdateInput()
    {
        Vector2 moveDir = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
            moveDir.y += 1;
        if (Input.GetKey(KeyCode.S))
            moveDir.y -= 1;
        if (Input.GetKey(KeyCode.A))
            moveDir.x -= 1;
        if (Input.GetKey(KeyCode.D))
            moveDir.x += 1;

        _moveDir = moveDir.normalized;
    }

    void MovePlayer()
    {
        // TEMP2
        _moveDir = Managers.MoveDir;

        Vector3 dir = _moveDir * moveSpeed * Time.deltaTime;
        transform.position += dir;
    }
}
