using UnityEngine;

public class Floor : MonoBehaviour
{
    [Header("����̐ݒ�")]
    public GameObject platformPrefab;
    public int platformCount = 20;

    [Header("���̉����iX�X�P�[���j")]
    public float minWidth = 1f;
    public float maxWidth = 4f;

    [Header("�t�B�[���h���������̈ʒu�ω�")]
    public float minXOffset = -2f;
    public float maxXOffset = 2f;

    [Header("���i����̍���")]
    public float minYStep = 2f;     // �Œ�W�����v�����i�W�����v�\�ȍŏ��i���j
    public float maxYStep = 3f;     // �ő�W�����v�����i�v���C���[���M���͂��j

    [Header("�J�n�ʒu")]
    public Vector3 startPosition = Vector3.zero;

    void Start()
    {
        GeneratePlatforms();
    }

    void GeneratePlatforms()
    {

        Vector3 currentPos = startPosition;

        for (int i = 0; i < platformCount; i++)
        {
            float randomWidth = Random.Range(minWidth, maxWidth);// �t�B�[���h���̏��̒����������_������
            float xOffset = Random.Range(minXOffset, maxXOffset);// �t�B�[���h���̏��̈ʒu���������Ƀ����_������
            float yStep = Random.Range(minYStep, maxYStep); // ���i�Ƃ̋����𐧌�

            currentPos += new Vector3(xOffset, yStep, 0f);//currentPos�́A���i�̑���̈ʒu�B�ǂ��ɂǂ����炷���ݒ�

            GameObject platform = Instantiate(platformPrefab, currentPos, Quaternion.identity);//platformPrefab��Cube Quaternion.identity������͉�]�����Ȃ�

            Vector3 newScale = platform.transform.localScale;
            newScale.x = randomWidth;
            platform.transform.localScale = newScale;
        }
    }
}
