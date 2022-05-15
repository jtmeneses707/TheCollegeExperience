using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code based on code previously used in SQ 2021 for McCoy's ECS 189L class. 
public class PlayerController : MonoBehaviour
{
  [SerializeField] private float Speed = 100f;
  [SerializeField] private float BoostFactor = 1.5f;

  // private Rigidbody RigidBody;

  // Vector3 using new Vector3 and input axes. 
  private Vector3 MovementDirection;
  // Speed * BoostFactor, helps keep track of correct speed to use. 
  private float ModifiedSpeed;
  // Start is called before the first frame update
  void Start()
  {
    // RigidBody = GetComponent<Rigidbody>();
  }

  // Update is called once per frame
  // void Update()
  // {
  //   // Set the modified speed to serialized speed. 
  //   this.ModifiedSpeed = this.Speed;
  //   // Continue to add speed and boost if shift down. 
  //   if (Input.GetKey(KeyCode.LeftShift))
  //   {
  //     this.ModifiedSpeed *= this.BoostFactor;
  //   }
  //   this.MovementDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
  //   this.gameObject.transform.Translate(this.MovementDirection * Time.deltaTime * this.ModifiedSpeed);
  //   // this.RigidBody.MovePosition(this.gameObject.transform.position + (MovementDirection * Time.deltaTime * ModifiedSpeed));
  // }

  void FixedUpdate()
  {
    this.ModifiedSpeed = this.Speed;
    // Continue to add speed and boost if shift down. 
    if (Input.GetKey(KeyCode.LeftShift))
    {
      this.ModifiedSpeed *= this.BoostFactor;
    }
    this.MovementDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
    // this.gameObject.transform.Translate(this.MovementDirection * Time.deltaTime * this.ModifiedSpeed);
    GetComponent<Rigidbody>().MovePosition(transform.position + (this.MovementDirection * Time.deltaTime * ModifiedSpeed));
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Wall")
    {
      Debug.Log("TOUCHED WALL");
    }
  }

  public float GetCurrentSpeed()
  {
    return this.ModifiedSpeed;
  }

  public Vector3 GetMovementDirection()
  {
    return this.MovementDirection;
  }
}
