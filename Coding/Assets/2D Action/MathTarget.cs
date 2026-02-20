using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathTarget : MonoBehaviour
{
    [SerializeField] Transform _player;
    Vector3 tPos;

    float tr = Data.range;
    float dot;
    void Start()
    {
        tPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pf = _player.forward;

        if ((_player.position.x - tPos.x) * (_player.position.x -tPos.x)
            + (_player.position.z - tPos.z) * (_player.position.z - tPos.z) < tr * tr)
        {
            dot = Vector3.Dot(pf, (tPos - _player.position).normalized);

            if (Data.cosA < dot)
            {
                GetComponent<Renderer>().material.color = Color.red;
            }
            else
            {
                GetComponent<Renderer>().material.color = Color.white;
            }
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.white;
        }

    }
}
