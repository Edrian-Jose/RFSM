using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private Vector2 startPos;
    private Vector2 nextPos;
    [SerializeField]
    public GameObject enemyTargetGameObject;
    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

}
