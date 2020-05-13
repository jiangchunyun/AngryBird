using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private bool isClick = false;
    public float maxDis = 2;
    public SpringJoint2D sp;
    private Rigidbody2D rg;

    public Transform rightPos;
    public LineRenderer rightLineRender;
    public Transform leftPos;
    public LineRenderer leftLineRender;

    public GameObject boom;

    private void Awake()
    {
        sp = GetComponent<SpringJoint2D>();
        rg = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isClick) {
            transform.position =Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position += new Vector3(0, 0, 10);
            if (Vector3.Distance(rightPos.position, transform.position) > maxDis) {
                Vector3 pos = (transform.position - rightPos.position).normalized;
                pos *= maxDis;
                transform.position = pos + rightPos.position;
            }
            RenderLine();
        }
        
    }

    private void OnMouseDown()
    {
        isClick = true;
        rg.isKinematic = true;
    }

    private void OnMouseDrag()
    {
        
    }

    private void OnMouseUp()
    {
        isClick = false;
        rg.isKinematic = false;
        Invoke("Fly", 0.1f);
        // 禁用画线组件
        rightLineRender.enabled = false;
        leftLineRender.enabled = false;
    }

    private void Fly() {
        sp.enabled = false;
        Invoke("Next", 3);
    }

    private void RenderLine() {
        // 重新启用
        rightLineRender.enabled = true;
        leftLineRender.enabled = true;

        rightLineRender.SetPosition(0, rightPos.position);
        rightLineRender.SetPosition(1, transform.position);

        leftLineRender.SetPosition(0, leftPos.position);
        leftLineRender.SetPosition(1, transform.position);
    }

    private void Next() {
        GameManager.instance.birds.Remove(this);
        Destroy(gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);
        GameManager.instance.NextBird();
    }
}
