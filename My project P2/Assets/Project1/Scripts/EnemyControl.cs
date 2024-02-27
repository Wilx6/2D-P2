using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{

    public float speed;
    public GameObject myPlayer;
    public Vector3 enemyDir = new Vector3(0,0,0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 PlayerPos = myPlayer.transform.position;
        Vector3 TargetPos = (PlayerPos - transform.position).normalized;
        transform.Translate(TargetPos * speed);
    }
}
