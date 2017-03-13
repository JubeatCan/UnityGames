using UnityEngine;

public class UIDirectionControl : MonoBehaviour
{
    public bool m_UseRelativeRotation = true;  


    private Quaternion m_RelativeRotation;     

    /* can used to do the camera rotation */
    private void Start()
    {
        m_RelativeRotation = transform.parent.localRotation;
    }


    private void Update()
    {
        if (m_UseRelativeRotation)
            transform.rotation = m_RelativeRotation;
    }
}
