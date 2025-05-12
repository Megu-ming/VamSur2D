using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    [SerializeField]
    GameObject _playerPrefab;

    GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = Instantiate(_playerPrefab);
        _player.name = _playerPrefab.name;

        _player.AddComponent<PlayerController>();

        Camera.main.GetComponent<CameraController>().target = _player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
