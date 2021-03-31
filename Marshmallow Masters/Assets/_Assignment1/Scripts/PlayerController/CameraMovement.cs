using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Rotation for the camera.
/// </summary>
public class CameraMovement : MonoBehaviour
{
    //split the camera rotations on the x axis and y axis, to allow for proper rotations.
    public Transform m_yRotate, m_xRotate;
    public float m_xRotateSpeed, m_yRotateSpeed;

    public float m_maxXRotate;

    /// <summary>
    /// Rotates the camera using the given input parameter.
    /// </summary>
    /// <param name="p_dir"></param>
    public void RotateCamera(Vector3 p_dir)
    {
        if (Mathf.Abs(p_dir.y) > 0)
        {
            m_yRotate.Rotate((Vector3.up * m_yRotateSpeed * Time.deltaTime) * Mathf.Sign(p_dir.y) * Mathf.Abs(p_dir.y));
        }

        if (Mathf.Abs(p_dir.x) > 0)
        {
            m_xRotate.Rotate(Vector3.right * m_xRotateSpeed * Time.deltaTime * Mathf.Sign(p_dir.x) * Mathf.Abs(p_dir.x));
            if (m_xRotate.eulerAngles.x > m_maxXRotate && m_xRotate.eulerAngles.x < 180)
            {
                m_xRotate.localEulerAngles = new Vector3(m_maxXRotate, 0, 0);
            }
            if (m_xRotate.eulerAngles.x < 360 - m_maxXRotate && m_xRotate.eulerAngles.x > 180)
            {
                m_xRotate.localEulerAngles = new Vector3(360 - m_maxXRotate, 0, 0);
            }
        }
        
    }
}
