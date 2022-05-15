using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractObjectController : MonoBehaviour
{

  [SerializeField] protected GameObject _player;
  [SerializeField] protected float _movementSpeed;
  [SerializeField] protected WallController _wallController;
  [SerializeField] protected ScoreController _scoreController;
  [SerializeField] protected int _numBouncesBeforeDestroy;

  protected Vector3 _playerPos;
  protected Vector3 _movementDirection;
  // protected int _numBounces = 0;
  // Used to implement basic bounce behavior. 
  protected void Bounce(Collider collider)
  {
    if (collider.gameObject.name == "Left Wall" || collider.gameObject.name == "Right Wall")
    {
      _movementDirection = new Vector3(-_movementDirection.x, _movementDirection.y, _movementDirection.z);
    }

    if (collider.gameObject.name == "Top Wall" || collider.gameObject.name == "Bottom Wall")
    {
      // Debug.Log("TOUCHED");
      _movementDirection = new Vector3(_movementDirection.x, -_movementDirection.y, _movementDirection.z);
    }
  }

  // Sets _movementDirection towards player.
  protected void SetMovementDirectionTowardsPlayer()
  {
    // Add some sort of randomization. 
    // var xVariation = Random.Range(0, 10f);
    // var yVariation = Random.Range(0, 10f);
    // var nearPlayerPos = new Vector3(_playerPos.x + xVariation, _playerPos.y + yVariation, _playerPos.z);
    _movementDirection = (_playerPos - transform.position).normalized;
  }

  protected void SetMovementDirectionAwayFromPlayer()
  {
    // Add randomization.
    var xVariation = Random.Range(0, 15f);
    var yVariation = Random.Range(0, 15f);
    var nearPlayerPos = new Vector3(_playerPos.x + xVariation, _playerPos.y + yVariation, _playerPos.z);
    _movementDirection = (transform.position - _playerPos).normalized;
  }




  // public void OnPlayerCollision()
  // {
  //   throw new System.Exception("Need to implement OnPlayerCollision");
  // }

  // public void OnWallCollision()
  // {
  //   throw new System.Exception("Need to implement OnWallCollision");
  // }

}
