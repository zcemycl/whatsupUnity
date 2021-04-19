using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectiles : MonoBehaviour
{
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();
    // public RotateToMouse rotateToMouse;
    private GameObject effectToSpawn;
    public float fireRate;
    public Camera cam;
    public float maximumLength;
    private Ray rayMouse;
    private Vector3 pos;
    private Vector3 direction;
    private Quaternion rotation;
    private float timeToFire = 0;
    // Start is called before the first frame update
    void Start()
    {
        effectToSpawn = vfx [0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= timeToFire){
            timeToFire = Time.time + 1/fireRate;
            // timeToFire = Time.time+ 1/4f;
            SpawnVFX ();
        }
        if (cam!=null){
            RaycastHit hit;
            var mousePos = Input.mousePosition;
            rayMouse = cam.ScreenPointToRay(mousePos);
            if (Physics.Raycast(rayMouse.origin,rayMouse.direction,out hit,maximumLength)){
                RotationToMouseDirection(gameObject,hit.point);
            } else {
                var pos = rayMouse.GetPoint(maximumLength);
                RotationToMouseDirection(gameObject,pos);
            }
        } else {
            Debug.Log("No Camera");
        }
        
    }

    void SpawnVFX(){
        GameObject vfx;
        if (firePoint != null){
            vfx = Instantiate (effectToSpawn, firePoint.transform.position,Quaternion.identity);
            if (rotation != null){
                vfx.transform.localRotation = rotation;
            }
        } else {
            Debug.Log("No Fire Point");
        }
    }

    void RotationToMouseDirection(GameObject obj, Vector3 destination){
        direction = destination-obj.transform.position;
        rotation = Quaternion.LookRotation(direction);
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation,rotation,1);

    }

}
