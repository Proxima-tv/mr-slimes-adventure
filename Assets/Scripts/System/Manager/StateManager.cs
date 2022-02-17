using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    private string currentState;
    private List<string> states;

    private void Awake()
    {
        states = new List<string>();
    }

    /**
     * registers states to handler list
     * @param state a state to add to our states list
     */
    public void addState(string state)
    {
        Debug.Log($"Registering State: {state}");
        states.Add(state);
    }

    /**
     * set state by integer id
     * @param int the id of the state
     */
    public void setState(int state)
    {
        this.currentState = states[state];
    }

    /**
     * returns the looked for state id
     * @param state a string based state to find id for
     */
    public int getStateID(System.Predicate<string> state)
    {
        return states.FindIndex(state);
    }

    /**
     * returns current set state
     * @return string current active state
     */
    public string getState()
    {
        return currentState;
    }
}
