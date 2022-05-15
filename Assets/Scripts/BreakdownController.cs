using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakdownController : AbstractObjectController
{
  // private GameObject _player;
  // [SerializeField] private GameObject _player;
  // [SerializeField] private float _movementSpeed;
  // [SerializeField] private WallController _wallController;
  // [SerializeField] private ScoreController _scoreController;
  // [SerializeField] private int _numBouncesBeforeDestroy;

  // private Vector3 _playerPos;
  // private Vector3 _movementDirection;
  // private int _numBounces = 0;

  void Awake()
  {
    _playerPos = _player.transform.position;
    _movementDirection = (_playerPos - transform.position).normalized;
  }

  // Update is called once per frame
  void Update()
  {
    transform.position = (transform.position + (_movementDirection * Time.deltaTime * _movementSpeed));
    // Debug.Log("Direction Vector" + MovementDirection);
  }

  void OnTriggerEnter(Collider collider)
  {
    var objectName = collider.gameObject.name;
    if (collider.gameObject.tag == "Wall")
    {
      _numBounces++;
      Bounce(collider);
    }

    // if (collider.gameObject.name == "Left Wall" || collider.gameObject.name == "Right Wall")
    // {
    //   _movementDirection = new Vector3(-_movementDirection.x, _movementDirection.y, _movementDirection.z);
    // }

    // if (collider.gameObject.name == "Top Wall" || collider.gameObject.name == "Bottom Wall")
    // {
    //   // Debug.Log("TOUCHED");
    //   _movementDirection = new Vector3(_movementDirection.x, -_movementDirection.y, _movementDirection.z);
    // }

    if (collider.gameObject.tag == "Player")
    {
      Debug.Log("TOUCHED PLAYER");
      _wallController.DoMentalBreakdown();
      _scoreController.IncrementNumBreakdowns();
      Destroy(this.gameObject);
    }

    if (_numBounces >= _numBouncesBeforeDestroy)
    {
      Destroy(this.gameObject);
    }

  }
}
