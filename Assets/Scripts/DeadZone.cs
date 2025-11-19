using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public Transform target;
    public Vector2 deadZoneSize = new Vector2(2f, 1f);
    public float smoothSpeed = 5f;

    
    void LateUpdate()
    {
        Vector3 pos = transform.position;
        Vector3 diff = target.position - transform.position;
        //roznica pozycji gracza - kamera

        if (Mathf.Abs(diff.x) > deadZoneSize.x) 
        //Math.Abs - zmieni liczke - na +
        {
            pos.x = Mathf.Lerp(pos.x, target.position.x, Time.deltaTime * smoothSpeed);
            //kamera rusza sie gdy gracz przekroczy strefe x, jej granice
        }

        if (Mathf.Abs(diff.y) > deadZoneSize.y) 
        {
            pos.y = Mathf.Lerp(pos.y, target.position.y, Time.deltaTime * smoothSpeed);
        }

        transform.position = new Vector3(pos.x, pos.y, -10);

    }
}
