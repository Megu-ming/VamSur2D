using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 moveInput;
    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>(); // PlayerInput 컴포넌트를 가져옵니다.
    }

    private void OnEnable()
    {
        playerInput.actions.FindAction("Move").performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        playerInput.actions.FindAction("Move").canceled += ctx => moveInput = Vector2.zero;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 movement = new Vector3(moveInput.x, moveInput.y, 0f) * moveSpeed * Time.deltaTime;
        transform.position += movement; // 플레이어의 위치를 업데이트합니다.
    }
}
