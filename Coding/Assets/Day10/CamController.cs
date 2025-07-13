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
        _camPosition = transform.position; //カメラポジションを記憶
    }

    // Update is called once per frame
    void Update()
    {
        if (_intensity > 0)
        {
            transform.position = _camPosition + Random.insideUnitSphere * _intensity; //小さな誤差を作る
            _intensity -= _decay * Time.deltaTime; //揺れ具合が時間とともに減衰
            if (_intensity <= 0)
            {
                transform.position = _camPosition; //記憶位置に戻す
            }
        }
    }

    public void Shake() //外部からアクセス可能
    {
        if (_intensity <= 0) //強度が0以下だったら（揺れてない）
        {
            _camPosition = transform.position; //開始位置に戻す
        }
        _intensity = _camIntensity; //代入
        _decay = _camDecay; //代入
    }

}
