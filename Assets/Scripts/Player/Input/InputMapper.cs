using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputMapper : MonoBehaviour
{
    // Input transport variables do not touch
    internal float Horizontal;
    internal bool Jump = false;

    void setJump(bool jumpContext)
    {
        Debug.Log("context" + jumpContext);
        if (jumpContext)
        {
            Debug.Log(Jump);
            if(Jump) { Jump = false; }
            else { Jump = true; }
        }
        
    }

    // input listeners do not touch
    #region Input Methods
        public void OnHorizontal(InputAction.CallbackContext context) { Horizontal = context.ReadValue<float>(); }
        public void OnJump(InputAction.CallbackContext context) { Jump = context.ReadValue<float>() > 0.1f;  }
    #endregion

}
