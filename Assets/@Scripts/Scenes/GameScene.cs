using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    [SerializeField]
    GameObject _playerPrefab;
    [SerializeField]
    GameObject _joystickPrefab;

    GameObject _player;
    GameObject _joystick;
    // Start is called before the first frame update
    void Start()
    {
        _player = Instantiate(_playerPrefab);
        _joystick = Instantiate(_joystickPrefab);
        _player.name = _playerPrefab.name;
        _joystick.name = _joystickPrefab.name;

        _player.AddComponent<PlayerController>();

        Camera.main.GetComponent<CameraController>().target = _player;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
