using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
  [SerializeField] private int numBreakdowns = 0;
  [SerializeField] private int numAssignments = 0;
  [SerializeField] private int numProjects = 0;
  [SerializeField] private int numNewLoves = 0;
  [SerializeField] private int numJobApplied = 0;
  [SerializeField] private int numJobOffers = 0;

  [SerializeField] private bool completedCollege = false;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    Debug.Log("Num breakdowns:" + numBreakdowns);
  }

  public void IncrementNumBreakdowns()
  {
    numBreakdowns++;
  }
}
