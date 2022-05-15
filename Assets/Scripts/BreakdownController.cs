using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakdownController : MonoBehaviour
{
  [SerializeField] private GameObject Player;
  [SerializeField] private float MovementSpeed;

  private Vector3 PlayerPos;
  private Vector3 MovementDirection;
  // Start is called before the first frame update
  // void Start()
  // {
  //   PlayerPos = Player.transform.position;
  //   MovementDirection = (transform.position - PlayerPos).normalized;
  //   Debug.Log("Direction" + MovementDirection);
  // }

  void Awake()
  {
    PlayerPos = Player.transform.position;
    MovementDirection = (PlayerPos - transform.position).normalized;
  }

  // Update is called once per frame
  void Update()
  {
    transform.position = (transform.position + (MovementDirection * Time.deltaTime * MovementSpeed));
  }

  void OnTriggerEnter(Collider collider)
  {
    if (collider.gameObject.tag == "Wall")
    {
      Debug.Log("BREAKDOWN TOUCHED WALL");
    }

  }
}
