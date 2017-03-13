using UnityEngine;

public class CameraControl : MonoBehaviour
{               
    [HideInInspector] public Transform[] m_Targets; 


    private Camera[] m_Camera;                                            

    private Vector3[] m_DesiredPosition = new[] { new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f) };
    private float m_PosY = 2.5f;

    private Quaternion m_CameraAngle = Quaternion.Euler(20, 0, 0);
    private Quaternion[] m_DesiredRotation = new[] { Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0) };

    private void Awake()
    {
        m_Camera = GetComponentsInChildren<Camera>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        FindPosition();
        FindRotation();

        for (int i = 0; i < 2; i++)
        {
            m_Camera[i].transform.position = m_DesiredPosition[i];
            m_Camera[i].transform.rotation = m_DesiredRotation[i] * m_CameraAngle;
        }
    }

    private void FindPosition()
    {
        Vector3 Pos = new Vector3();
        for(int i = 0; i < 2; i++)
        {
            if (!m_Targets[i].gameObject.activeSelf)
                continue;

            Pos = m_Targets[i].TransformPoint(Vector3.forward*-3);
            
            Pos.y = m_PosY;
            
            m_DesiredPosition[i] = Pos;
        }
    }

    private void FindRotation()
    {
        for(int i = 0; i < 2; i++)
        {
            if (!m_Targets[i].gameObject.activeSelf)
                continue;
            m_DesiredRotation[i] = m_Targets[i].rotation;
        }
    }

    public void SetStartPositionAndSize()
    {
        FindPosition();
        FindRotation();

        m_Camera[0].transform.position = m_DesiredPosition[0];
        m_Camera[1].transform.position = m_DesiredPosition[1];
        m_Camera[0].transform.rotation = m_DesiredRotation[0] * m_CameraAngle;
        m_Camera[1].transform.rotation = m_DesiredRotation[1] * m_CameraAngle;

    }
}