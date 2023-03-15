using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    List<Vector3> positions;
    byte positionIndex = 0;
    bool hasMoved;
    // Start is called before the first frame update
    void Start()
    {
        positions = new List<Vector3>
        {
            new(transform.position.x, transform.position.y, -12.09f),
            new(transform.position.x, transform.position.y, -6.85f),
            new(transform.position.x, transform.position.y, -10.04f)
        };
    }
    void Move()
    {
        float xAxis = Input.GetAxis("Horizontal");
        if (!hasMoved)
        {
            if (xAxis < 0)
            {
                positionIndex = (byte)((positionIndex == 0) ? positions.Count : positionIndex);
                transform.position = positions[--positionIndex];
            }
            else if (xAxis > 0)
            {
                positionIndex = (byte)((positionIndex == positions.Count - 1) ? -1 : positionIndex);
                transform.position = positions[++positionIndex];
            }
            hasMoved = true;
        }
        if (xAxis == 0)
        {
            hasMoved = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
