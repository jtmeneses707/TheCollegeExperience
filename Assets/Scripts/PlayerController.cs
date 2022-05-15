using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code based on code previously used in SQ 2021 for McCoy's ECS 189L class. 
public class PlayerController : MonoBehaviour
{
  [SerializeField] private float Speed = 100f;
  [SerializeField] private float BoostFactor = 1.5f;
  [SerializeField] private float TotalHealth = 100f;
  [SerializeField] private float CurHealth;
  [SerializeField] private float HealthDecayPerSecond = 1.5f;
  [SerializeField] private MeshRenderer Renderer;
  [SerializeField] private float TimeToCompleteCollege = 60f;
  [SerializeField] private float CurTimeCompleted = 0f;


  // Vector3 using new Vector3 and input axes. 
  private Vector3 MovementDirection;
  // Speed * BoostFactor, helps keep track of correct speed to use. 
  private float ModifiedSpeed;
  // Start is called before the first frame update
  void Start()
  {
    CurHealth = TotalHealth;
  }

  void Update()
  {
    if (CurHealth > 0)
    {
      CurHealth -= Time.deltaTime * HealthDecayPerSecond;
    }

    CurTimeCompleted += Time.deltaTime;
    // Change opacity. 
    var color = Renderer.material.color;
    color.a = CurHealth / TotalHealth;
    Renderer.material.color = color;

    if (CurTimeCompleted >= TimeToCompleteCollege)
    {
      // TODO: DO SOMETHING WITH SCENE MANAGER AND SCORE. 
    }
  }

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
    GetComponent<Rigidbody>().MovePosition(transform.position + (this.MovementDirection * Time.fixedDeltaTime * ModifiedSpeed));
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Wall")
    {
      // Debug.Log("TOUCHED WALL");
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

  public void IncreaseHealth(float increase)
  {
    CurHealth += increase;
    // Make sure health doesn't go above 100.
    if (CurHealth > 100)
    {
      CurHealth = 100;
    }
  }
}
