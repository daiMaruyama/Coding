using UnityEngine;

public class CamController : MonoBehaviour
{
    [SerializeField] float _camIntensity = 0.3f;
    [SerializeField] float _camDecay = 0.3f;
    float _intensity;
    float _decay;
    Vector3 _camPosition;
    // Start is called before the first frame update
    void Start()
    {
        _camPosition = transform.position; //�J�����|�W�V�������L��
    }

    // Update is called once per frame
    void Update()
    {
        if (_intensity > 0)
        {
            transform.position = _camPosition + Random.insideUnitSphere * _intensity; //�����Ȍ덷�����
            _intensity -= _decay * Time.deltaTime; //�h�������ԂƂƂ��Ɍ���
            if (_intensity <= 0)
            {
                transform.position = _camPosition; //�L���ʒu�ɖ߂�
            }
        }
    }

    public void Shake() //�O������A�N�Z�X�\
    {
        if (_intensity <= 0) //���x��0�ȉ���������i�h��ĂȂ��j
        {
            _camPosition = transform.position; //�J�n�ʒu�ɖ߂�
        }
        _intensity = _camIntensity; //���
        _decay = _camDecay; //���
    }

}
