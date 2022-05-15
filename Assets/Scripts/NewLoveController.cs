using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLoveController : AbstractObjectController
{
  // Start is called before the first frame update
  void Awake()
  {
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
  }

  private void OnPlayerCollision()
  {
    // _wallController
    // TODO: DO STUFF WITH WALLCONTROLLER AND SCORE>
  }
}
