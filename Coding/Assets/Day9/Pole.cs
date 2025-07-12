using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pole : MonoBehaviour
{
    private Stack<Disk> _disks = new Stack<Disk>();

    public void Push(Disk disk)
    {
        _disks.Push(disk);
        disk.SetPole(this);
    }

    public Disk Peek()
    {
        return _disks.Count > 0 ? _disks.Peek() : null;
    }

    public Disk Pop()
    {
        return _disks.Pop();
    }

    public int DiskCount => _disks.Count;

    public Vector3 GetTopPosition()
    {
        return transform.position + Vector3.up * (_disks.Count * 0.35f - 3.7f); // マジックナンバー仮多用
    }

    public void Clear()
    {
        _disks.Clear();
    }

    private void OnMouseDown()
    {
        Debug.Log("Pole clicked!");
        GameManager.Instance.SelectPole(this);
    }

}
