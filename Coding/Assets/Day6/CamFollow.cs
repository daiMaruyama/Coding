using UnityEngine;

public class CamFollow : MonoBehaviour
{
    [SerializeField] Transform _targetObject;
    [SerializeField] Vector3 _offset = new Vector3(0, 1f, -10f);

    private void LateUpdate()
    {
        if (_targetObject != null)
        {
            this.transform.position = _targetObject.position + _offset;
        }
    }
}
