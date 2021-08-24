using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    private BoxCollider col;
    private GameObject wall_def;
    private GameObject wall_pos;
    private GameObject wall_break;
    private Material material;
    private Color defColor;

    //private float hit_cnt;

    private bool up_state;
    public bool col_state;

    //private bool but_down;
    Vector3 screenPoint;
    

    // Start is called before the first frame update
    void Start()
    {
        //hit_cnt=0;
        up_state=false;
        col_state=false;
        //but_down=false;
        wall_def=transform.Find("wall_obj").gameObject;
        wall_pos=transform.Find("wall_pos").gameObject;
        wall_break=transform.Find("break").gameObject;
        wall_break.SetActive(false);
        col= wall_def.GetComponent<BoxCollider>();
        material = wall_def.GetComponent<Renderer>().material;
        defColor = material.color;
        //Debug.Log(defColor);
    }

    // Update is called once per frame
    void Update()
    {
        //持ち上げている間はマウスの位置に追従
        if(up_state){
            this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 a = new Vector3 (Input.mousePosition.x,Input.mousePosition.y,screenPoint.z);
            //Vector3 a = new Vector3 (0,0,0);
         

            float ax=Camera.main.ScreenToWorldPoint (a).x;
            float ay=this.transform.position.y;
            float az=Camera.main.ScreenToWorldPoint (a).z;
            //transform.position = Camera.main.ScreenToWorldPoint (a);
            
            
            transform.position =  new Vector3 (ax,ay,az);

            
            if (Input.GetMouseButtonDown(0) && !col_state) {
                transform.position =  new Vector3 (transform.position.x,this.transform.position.y,transform.position.z);
                wall_def.transform.localPosition =new Vector3(0, 1, 0);
                defColor = material.color;
                material.color=new Color(defColor.r,defColor.g,defColor.b,1f);
                up_state=false;

                //but_down=true;
                //Debug.Log("置いた1:"+but_down+" up_state:"+up_state);
                
            }

            
        }else{
            if (Input.GetMouseButtonDown(0)) {
    
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit = new RaycastHit();
        
                if (Physics.Raycast(ray, out hit)){
                    //Rayがcolにヒットした場合
                    if (hit.collider == col){
                        wall_def.transform.localPosition =new Vector3(0, 10, 0);
                    
                        material.color=new Color(defColor.r,defColor.g,defColor.b,0.8f);
                        up_state=true;
                        //Debug.Log("hit!");
                    }
                    
                }
            }
        }
        
    }

    //ダメージを受けた場合
    public void change_col() {
        if(defColor.g>0){
            defColor.g-=0.2f;
        }else{
            wall_def.SetActive(false);
            wall_pos.SetActive(false);
            wall_break.SetActive(true);
        }
        material.color=new Color(defColor.r,defColor.g,defColor.b,1f);
        //material.color=new Color(1f,0f,0f,1f);
        defColor = material.color;
        
    }

    //置けない場合
    public void not_down() {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit)){
            //Rayがcolにヒットした場合
            if (hit.collider == col){
                wall_def.transform.localPosition =new Vector3(0, 10, 0);
            
                material.color=new Color(defColor.r,defColor.g,defColor.b,0.8f);
                up_state=true;
                //Debug.Log("hit!");
            }
            
        }
        
    }

}
