using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float left, right;
    public bool isRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var npcX = transform.position.x;

        if(npcX < left)
        {
            isRight = true;
        }
        if(npcX > right)
        {
            isRight = false;
        }
        if (isRight)
        {
            transform.Translate(new Vector3(Time.deltaTime * 3, 0, 0));
            Vector2 scale = transform.localScale;
            scale.x *= scale.x > 0 ? 1 : -1;
            transform.localScale = scale;
        }
        else
        {
            transform.Translate(new Vector3(-Time.deltaTime * 3, 0, 0));
            Vector2 scale = transform.localScale;
            scale.x *= scale.x > 0 ? -1 : 1;
            transform.localScale = scale;
        }
       
    }
}
