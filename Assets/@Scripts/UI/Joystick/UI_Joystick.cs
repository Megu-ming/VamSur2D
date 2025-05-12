using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Joystick : MonoBehaviour , IPointerClickHandler,IPointerDownHandler,IPointerUpHandler,IDragHandler
{
    [SerializeField]
    Image _handler;

    [SerializeField]
    Image _background;

    float _joystickRadius;
    Vector2 _touchPosition;
    Vector2 _moveDir;

    PlayerController _player;

    // Start is called before the first frame update
    void Start()
    {
        _joystickRadius = _background.gameObject.GetComponent<RectTransform>().sizeDelta.y / 2;
        _player = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData)
    {
        //Debug.Log("OnPointerClick");
    }

    public void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData)
    {
        
        //Debug.Log("OnPointerDown");
        _background.transform.position = eventData.position;
        _handler.transform.position = eventData.position;
        _touchPosition = eventData.position;

        // TEMP1
    }

    public void OnPointerUp(UnityEngine.EventSystems.PointerEventData eventData)
    {
        //Debug.Log("OnPointerUp");

        _handler.transform.position = _touchPosition;
        _moveDir = Vector2.zero;

        // TEMP1
        // _player.MoveDir = _moveDir;

        // TEMP2
        Managers.MoveDir = _moveDir;

        
    }

    public void OnDrag(UnityEngine.EventSystems.PointerEventData eventData)
    {
        //Debug.Log("OnDrag");

        Vector2 touchDir = (eventData.position - _touchPosition);

        float moveDist = Mathf.Min(touchDir.magnitude, _joystickRadius);
        _moveDir = touchDir.normalized;

        Vector2 newPosition = _touchPosition + _moveDir * moveDist;
        _handler.transform.position = newPosition;

        // TEMP1
        // _player.MoveDir = _moveDir;

        // TEMP2
        Managers.MoveDir = _moveDir;
    }
}
