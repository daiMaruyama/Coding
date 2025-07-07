using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    [SerializeField] private bool _isGoal = false; // true�Ȃ玩���̃S�[���i���_�j

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Puck"))
        {
            if (_isGoal)
            {
                Debug.Log("�����̃S�[���ɓ������I�����I");
                // TODO: �����Ŕs�k���o�E�V�[���J�ځE�Ď��s�Ȃ�
            }
            else
            {
                Debug.Log("�G�S�[���ɓ��ꂽ�I�����I");
                // TODO: �����ŏ������o�E�X�R�A���Z�Ȃ�
            }

            // �Q�[����~�i���ƂŃ{�^���ōĊJ or ���X�^�[�g�j
            Time.timeScale = 0f;
        }
    }
}
