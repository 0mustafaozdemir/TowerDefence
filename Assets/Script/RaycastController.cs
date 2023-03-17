using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    public static int rayHitCount = 1;
    [SerializeField] private LayerMask layer;
    [SerializeField] private LayerMask TaretLayer;
    public List<GameObject> towerPrefabList = new List<GameObject>();
    public List<Vector3> touchTransform = new List<Vector3>();
    public static List<GameObject> InstantitaeTower = new List<GameObject>();
    
    public GameObject InfoObj;
    public int clickCount = 0;
    public static GameObject lastObj;
    int counts;


    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layer))
            {
                if (hit.collider != null)
                {
                    var touchPos = hit.collider.gameObject.GetComponent<Transform>().position;


                    if (!touchTransform.Contains(touchPos) && GameManager.Instance.money > 0)
                    {
                        rayHitCount++;
                        Instantiate(InfoObj, transform.position, Quaternion.identity);

                        touchTransform.Add(touchPos);
                        GameManager.Instance.money -= 200;
                        var tower = Instantiate(towerPrefabList[0], touchPos, Quaternion.identity);
                        hit.collider.gameObject.GetComponent<Block>().turret = tower;                        
                        InstantitaeTower.Add(tower);
                       
                    }
                    else
                    {
                        Debug.Log(hit.collider.gameObject);
                        lastObj = hit.collider.gameObject.GetComponent<Block>().turret;
                        clickCount++;
                        if (hit.collider.gameObject.GetComponent<Block>().turret.GetComponent<Tower>().level›nt < 2)
                            hit.collider.gameObject.GetComponent<Block>().turret.GetComponent<Tower>().level›nt++;
                    }

                }
            }

        }


    }


}
