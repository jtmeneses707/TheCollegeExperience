using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakdownController : AbstractObjectController
{

  private int _numBounces = 0;

  void Awake()
  {
    _playerPos = _player.transform.position;

    SetMovementDirectionTowardsPlayer();
  }

  // Update is called once per frame
  void Update()
  {
    transform.position = (transform.position + (_movementDirection * Time.deltaTime * _movementSpeed));
    // Debug.Log("Direction Vector" + MovementDirection);
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
      Destroy(this.gameObject);
    }

  }

  private void OnPlayerCollision()
  {
    _wallController.DoMentalBreakdown();
    _scoreController.IncrementNumBreakdowns();
    Destroy(this.gameObject);
  }


}
