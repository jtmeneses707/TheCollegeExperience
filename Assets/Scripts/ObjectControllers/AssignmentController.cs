using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignmentController : AbstractObjectController
{
  // Start is called before the first frame update
  [SerializeField] private int _numPlayerTouchesBeforeDestroy = 4;
  private int _numBounces = 0;
  private int _numPlayerTouches = 0;

  protected void Awake()
  {
    _playerController = _player.GetComponent<PlayerController>();
    _playerPos = _player.transform.position;
    SetMovementDirectionAwayFromPlayer();
  }

  // Update is called once per frame
  protected void Update()
  {
    transform.position = (transform.position + (_movementDirection * Time.deltaTime * _movementSpeed));
  }

  void OnTriggerEnter(Collider collider)
  {
    if (collider.gameObject.tag == "Wall")
    {
      _numBounces++;
      Bounce(collider);
    }

    if (collider.gameObject.tag == "Player")
    {
      OnPlayerCollision();
    }

    if (_numBounces >= _numBouncesBeforeDestroy)
    {
      _playerController.TakeDamageFromMissingAssignment();
      Destroy(this.gameObject);
    }
  }

  private void OnPlayerCollision()
  {
    _numPlayerTouches++;
    if (_numPlayerTouches >= _numPlayerTouchesBeforeDestroy)
    {
      _scoreController.IncrementNumAssignments();
      _playerController.IncreaseHealthFromAssignment();
      Destroy(this.gameObject);
    }
  }
}
