using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLoveController : AbstractObjectController
{
  // Start is called before the first frame update
  new void Awake()
  {
    base.Awake();
    _playerPos = _player.transform.position;
    SetMovementDirectionAwayFromPlayer();
  }

  // Update is called once per frame
  void Update()
  {
    transform.position = (transform.position + (_movementDirection * Time.deltaTime * _movementSpeed));
  }

  void OnTriggerEnter(Collider collider)
  {
    Debug.Log("Star touched");
    if (collider.gameObject.tag == "Wall")
    {
      Debug.Log("SHOULD BOUNCE ON WALL");
      Bounce(collider);
    }

    if (collider.gameObject.tag == "Player")
    {
      OnPlayerCollision();
    }
  }

  private void OnPlayerCollision()
  {
    StartCoroutine(Flasher());
    _wallController.DoNewLove();
    _scoreController.IncrementNumNewLoves();
    Destroy(this.gameObject);
  }
}
