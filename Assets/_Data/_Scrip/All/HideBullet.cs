using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideBullet : MonoBehaviour
{
    public void HideBulletObj()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
