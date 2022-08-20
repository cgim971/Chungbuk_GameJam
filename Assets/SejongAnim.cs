using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SejongAnim : MonoBehaviour
{
    [SerializeField] Animator anim;
    Transform trans;
    Vector3 scale;

    public int direction;
    public bool isMoving=true;

    private void Start() {
        scale = new Vector3(trans.localScale.x, trans.localScale.y, trans.localScale.z);
        //anim = gameObject.GetComponent<Animator>();
    }

    private void Update() {
        anim.SetInteger("direction", direction);
        if (direction == 2) trans.localScale = scale;
        if (direction == 3) trans.localScale = new Vector3(scale.x*-1, scale.y, scale.z);
        anim.SetBool("isWalk", isMoving);
    }
}
