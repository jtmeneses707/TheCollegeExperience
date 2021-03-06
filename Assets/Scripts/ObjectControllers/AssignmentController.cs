using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignmentController : AbstractObjectController
{
  // Start is called before the first frame update
  [SerializeField] protected int _numPlayerTouchesBeforeDestroy = 4;
  protected int _numBounces = 0;
  protected int _numPlayerTouches = 0;

  new protected void Awake()
  {
    base.Awake();
    _playerController = _player.GetComponent<PlayerController>();
    _playerPos = _player.transform.position;
    SetMovementDirectionAwayFromPlayer();
  }

  // Update is called once per frame
  protected void Update()
  {
    transform.position = (transform.position + (_movementDirection * Time.deltaTime * _movementSpeed));
  }

  protected void OnTriggerEnter(Collider collider)
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
    StartCoroutine(Flasher());
    _numPlayerTouches++;
    if (_numPlayerTouches >= _numPlayerTouchesBeforeDestroy)
    {
      _scoreController.IncrementNumAssignments();
      _playerController.IncreaseHealthFromAssignment();
      Destroy(this.gameObject);
    }
  }
}
