using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHP : MonoBehaviour
{
    [SerializeField] int monsterHP;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Howitzer(Clone)")
        {
            monsterHP -= 1;
            if (monsterHP <= 0)
                Destroy(gameObject);
        }
        else if (collision.gameObject.name == "DirectHit(Clone)")
        {
            monsterHP -= 2;
            if (monsterHP <= 0)
                Destroy(gameObject);
        }
    }
}
