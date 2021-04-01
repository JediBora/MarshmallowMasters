using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[System.Serializable]
public class DirectionInput : UnityEngine.Events.UnityEvent<Vector3> { }
[System.Serializable]
public class InputEvent : UnityEngine.Events.UnityEvent { }

/// <summary>
/// The script that gets all the player's inputs. Uses Unity's standard input system, and events to perform all the inputs.
/// </summary>
public class PlayerInput : MonoBehaviour
{

    #region Input Varaiables
    public InputEvents m_inputEvents;

    [System.Serializable]
    public struct InputEvents
    {
        public DirectionInput m_dirEvent, m_mouseMovementEvent;
        public InputEvent m_mouse1Fire;
        public InputEvent m_mouse1Released;
        public InputEvent m_jumpPress;
        public InputEvent m_respawnEvents;
    }
    public bool m_mousePressed;

    public InputAxis m_inputAxis;

    [System.Serializable]
    public struct InputAxis
    {
        public string m_verticalAxis, m_horizontalAxis, m_jumpAxis;
        public string m_mouseVertMovement, m_mouseHorizMovement;
        public float m_mouseDeadzone;
    }
    #endregion



    private void Update()
    {
        m_inputEvents.m_dirEvent.Invoke(GetDirectionalInput());
        m_inputEvents.m_mouseMovementEvent.Invoke(GetMouseMovement());
        CheckFirePress();
        CheckJumpPress();
    }

    private Vector3 GetDirectionalInput()
    {
        //Mobile
        return new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), 0f, CrossPlatformInputManager.GetAxis("Vertical"));

        //Original
        //return new Vector3(Input.GetAxis(m_inputAxis.m_horizontalAxis), 0f, Input.GetAxis(m_inputAxis.m_verticalAxis));
    }
    private Vector3 GetMouseMovement()
    {

        //Mobile
        float vertMovement = CrossPlatformInputManager.GetAxis("Horizontal");
       
        //Original
        float horizMovement = Input.GetAxis(m_inputAxis.m_mouseHorizMovement);
        //float vertMovement = Input.GetAxis(m_inputAxis.m_mouseVertMovement);

        if (Mathf.Abs(horizMovement) < m_inputAxis.m_mouseDeadzone)
        {
            horizMovement = 0;
        }
        if (Mathf.Abs(vertMovement) < m_inputAxis.m_mouseDeadzone)
        {
            vertMovement = 0;
        }

        return new Vector3(horizMovement, vertMovement, 0);
    }

    private void CheckFirePress()
    {
        if (Input.GetMouseButton(0))
        {
            m_inputEvents.m_mouse1Fire.Invoke();
            return;
        }

        if (Input.GetMouseButtonUp(0))
        {
            m_inputEvents.m_mouse1Released.Invoke();

            return;
        }
    }

    private void CheckJumpPress()
    {
        if (Input.GetAxis(m_inputAxis.m_jumpAxis) > 0)
        {
            m_inputEvents.m_jumpPress.Invoke();

        }
    }

    public void RespawnMe()
    {
        m_inputEvents.m_respawnEvents.Invoke();
        enabled = true;
    }
}
