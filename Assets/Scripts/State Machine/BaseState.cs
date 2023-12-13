using UnityEngine;

public abstract class BaseState
{
   public abstract void EnterState(StateManager stateObject);
   public abstract void UpdateState(StateManager stateObject);

   public abstract void OnTriggerEnter(StateManager stateObject, Collider other);
}
