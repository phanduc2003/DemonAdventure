using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScripts : MonoBehaviour
{
    // Start is called before the first frame update

    //nhan vat nguoi choi
    public GameObject player;
    // diem bat dau va ket thuc cua camera
    public float start, end; 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Lay vi tri hien tai cua nhan vat
        var playerX = player.transform.position.x;


        //Lay vi tri hien tai cua camera
        var camX = transform.position.x;
        var camY = transform.position.y;
        var camZ = transform.position.z;

        if(playerX > start && playerX < end)
        {
            camX = playerX; 
        }
        else
        {
            //Khi nhan vat chay qua khoi map
            if (playerX < start)
            {
                camX = start;
            }
            if (playerX > end) 
            { 
                camX = end; 
            }
        }
        transform.position = new Vector3(camX, camY, camZ);
    }
}
