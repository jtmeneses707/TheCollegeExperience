using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
  [SerializeField] public int numBreakdowns = 0;
  [SerializeField] public int numAssignments = 0;
  [SerializeField] public int numProjects = 0;
  [SerializeField] public int numNewLoves = 0;
  [SerializeField] public bool completedCollege = false;
  // Start is called before the first frame update


  // Update is called once per frame

  public void IncrementNumBreakdowns()
  {
    numBreakdowns++;
  }

  public void IncrementNumNewLoves()
  {
    numNewLoves++;
  }

  public void IncrementNumAssignments()
  {
    numAssignments++;
  }

  public void IncrementNumProjects()
  {
    numProjects++;
  }

  public void CompleteCollege()
  {
    completedCollege = true;
  }



}
