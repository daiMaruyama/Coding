using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] Disk _diskPrefab;
    [SerializeField] Pole[] _poles;
    [SerializeField, Range(3, 10)] int _diskCount = 3;

    private Disk _selectedDisk;
    private Pole _selectedPole;

    private int _moveCount = 0;
    private int _moveLimit = 100;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        _moveCount = 0;
        _moveLimit = (1 << _diskCount) - 1; // 2^n - 1�̈Ӗ��i�r�b�g���Z�j

        for (int i = 1; i <= _diskCount; i++)
        {
            Disk disk = Instantiate(_diskPrefab);
            Color color = Color.HSVToRGB((float)i / _diskCount, 0.8f, 0.8f); // �i�f�B�X�N�̉��Ԗڂ��𗘗p���ĐF�ω��j
            disk.Initialize(i, _poles[0], color);
        }

    }

    public bool CanSelectDisk(Disk disk)
    {
        return _selectedDisk == null && disk.CurrentPole.Peek() == disk;
    }

    public void SelectDisk(Disk disk)
    {
        _selectedDisk = disk;
        _selectedPole = disk.CurrentPole;
    }

    public void SelectPole(Pole toPole)
    {
        if (_selectedDisk == null) return;

        if (toPole.Peek() == null || toPole.Peek().Size < _selectedDisk.Size)
        {
            _selectedPole.Pop();
            toPole.Push(_selectedDisk);
            _moveCount++;

            CheckClear(toPole);
        }

        _selectedDisk = null;
        _selectedPole = null;

        if (_moveCount > _moveLimit)
        {
            Debug.Log("�ŒZ�萔�𒴂��܂����I��蒼���I");
            RestartGame();
        }
    }

    private void CheckClear(Pole toPole)
    {
        if (toPole != _poles[2]) return;

        if (toPole.DiskCount == _diskCount)
        {
            if (_moveCount == _moveLimit)
            {
                Debug.Log("�����I�ŒZ�萔�ŃN���A�I");
            }
            else
            {
                Debug.Log("�N���A�������ǍŒZ�萔����Ȃ������I");
                RestartGame();
            }
        }
    }

    private void RestartGame()
    {
        foreach (var disk in FindObjectsOfType<Disk>())
        {
            Destroy(disk.gameObject);
        }

        foreach (var pole in _poles)
        {
            pole.Clear();
        }

        InitializeGame();
    }
}
