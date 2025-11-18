using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript1 : MonoBehaviour
{
    //public Transform target;
    //public float smoothTime = 0.2f;
    //float LookAheadDistance = 2f;
    public Vector2 deadZoneSize = new Vector2(2f, 1f);
    public float smoothSpeed = 5f;

    //private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 pos = transform.position;
        Vector3 diff = target.position - transform.position;
        //roznica pozycji gracza - kamera

        if (Mathf.Abs(diff.x) > deadZoneSize.x) ;
        //Math.Abs - zmieni liczke - na +
        {
            pos.x = Mathf.Lerp(pos.x, target.position.x, smoothSpeed * Time.deltaTime);
            //kamera rusza sie gdy gracz przekroczy strefe x, jej granice
        }

        if (Mathf.Abs(diff.y) > deadZoneSize.y) ;
        //Math.Abs - zmieni liczke - na +
        {
            pos.y = Mathf.Lerp(pos.y, target.position.y, smoothSpeed * Time.deltaTime);
            //kamera rusza sie gdy gracz przekroczy strefe x, jej granice
        }

        transform.position = new Vector3(pos.x, pos.y, -10);



        //float direction = Input.GetAxis("Horizontal");
        // -1 = lewo, 1 = prawo, 0 = stoi

        //Vector3 targetPos = new Vector3(target.position.x, target.position.y, target.position.z);
        //Vector3 targetPos = target.position + new Vector3 (LookAheadDistance * direction, 0, -10);
        //przesumiecie kmeki w kierunku ruchu

        //transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}
