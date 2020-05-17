using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class object_transformation : MonoBehaviour
{
    public GameObject selectedmodel;
    private int selectedmodelno = 0;
    bool rotatedown = false;
    bool rotateup = false;
    bool rotateleft = false;
    bool rotateright = false;
    bool mousepressed = false;
    bool swapmodels = false;

    bool updating = false;
    public float turnSpeed = .005f;
    public Material ObjectMaterialNotDone;
    public Material ObjectMaterialNearDone;
    public Material ObjectMaterialDone;
    public Material ObjectMaterialNotSelected;

    public float angleX;
    public float angleY;
    public float angleZ;

    private int mode = 0;
    private bool game = true;
    public float min_x;
    public float max_x;
    public float min_y;
    public float max_y;
    public int movements;

    private GameObject child1;
    private GameObject child2;
    void Start()
    {

    }

    void Awake() {
        updating = true;

        child1 = gameObject.transform.GetChild(0).gameObject;
        child1 = child1.transform.GetChild(0).gameObject; ;

        if (transform.childCount == 2) {
            child2 = gameObject.transform.GetChild(1).gameObject;
            child2 = child2.transform.GetChild(0).gameObject; ;
        }

        // get the solve conditions asap
        max_x = selectedmodel.transform.GetComponent<rotation_values>().max_x;
        min_x = selectedmodel.transform.GetComponent<rotation_values>().min_x;
        max_y = selectedmodel.transform.GetComponent<rotation_values>().max_y;
        min_y = selectedmodel.transform.GetComponent<rotation_values>().min_y;
        movements = selectedmodel.transform.GetComponent<rotation_values>().movements;

        if (movements == 1 || movements == 3)
            mode = 1;
        else
            mode = 2;

        angleX = selectedmodel.transform.localEulerAngles.x;
        angleY = selectedmodel.transform.localEulerAngles.y;
        angleZ = selectedmodel.transform.localEulerAngles.z;
        
        updating = false;

    }

    // Update is called once per frame
    void FixedUpdate(){

        // KEYBOARD INPUT

        if(rotateleft)
            selectedmodel.transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        
        if(rotateright)
            selectedmodel.transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);

        if(rotateup)
            selectedmodel.transform.Rotate(Vector3.left, -turnSpeed * Time.deltaTime);
        
        if(rotatedown)
            selectedmodel.transform.Rotate(Vector3.left, turnSpeed * Time.deltaTime);
        
        if (swapmodels && transform.childCount >= 2){
            updating = true;
            selectedmodelno++;
            if (selectedmodelno >= transform.childCount){
                selectedmodelno = 0;
            }

            if (selectedmodel.transform.GetComponent<rotation_values>().solved != true){
                selectedmodel.GetComponent<MeshRenderer>().material = ObjectMaterialNotSelected;
            }

            // get the child with the shape inside
            // get the shape which is the child's child

            selectedmodel = gameObject.transform.GetChild(selectedmodelno).gameObject;
            selectedmodel = selectedmodel.transform.GetChild(0).gameObject;
            
            max_x = selectedmodel.transform.GetComponent<rotation_values>().max_x;
            min_x = selectedmodel.transform.GetComponent<rotation_values>().min_x;
            max_y = selectedmodel.transform.GetComponent<rotation_values>().max_y;
            min_y = selectedmodel.transform.GetComponent<rotation_values>().min_y;

            movements = selectedmodel.transform.GetComponent<rotation_values>().movements;

            if (movements == 1 || movements == 3)
                mode = 1;
            else
                mode = 2;

            updating = false;
            swapmodels = false;
        } else { 
            
            if(mousepressed && game){
                Vector3 position = selectedmodel.transform.position;
                if (mode == 0)
                {
                    selectedmodel.transform.Rotate(-Input.GetAxis("Mouse Y") * turnSpeed, 0, 0, Space.Self);
                    selectedmodel.transform.Rotate(0, -Input.GetAxis("Mouse X") * turnSpeed, 0, Space.World);
                }
                else if (mode == 1)
                {
                    selectedmodel.transform.Rotate(-Input.GetAxis("Mouse Y") * turnSpeed, 0, 0, Space.Self);
                }
                else if (mode == 2)
                {
                    selectedmodel.transform.Rotate(0, -Input.GetAxis("Mouse X") * turnSpeed, 0, Space.World);
                }
            }


            if (!updating)
            {
                if (angleX > min_x && angleX < max_x && angleY > min_y && angleY < max_y)
                {
                    selectedmodel.GetComponent<MeshRenderer>().material = ObjectMaterialDone;
                    selectedmodel.transform.GetComponent<rotation_values>().solved = true;
                }
                else if ((angleY > min_y && angleY < max_y) || (angleX > min_x && angleX < max_x))
                {
                    selectedmodel.GetComponent<MeshRenderer>().material = ObjectMaterialNearDone;
                    selectedmodel.transform.GetComponent<rotation_values>().solved = false;
                }
                else
                {
                    selectedmodel.GetComponent<MeshRenderer>().material = ObjectMaterialNotDone;
                    selectedmodel.transform.GetComponent<rotation_values>().solved = false;
                }

                //check if all child component are satisfied then win (works only if there are two child gameobject)
                if (game)
                {
                    if (transform.childCount == 2 &&
                    child1.GetComponent<rotation_values>().solved &&
                    child2.GetComponent<rotation_values>().solved)
                    {
                        game = false;
                        FindObjectOfType<GameMaster>().LevelComplete();
                    }
                    else if (transform.childCount == 1 &&
                  child1.GetComponent<rotation_values>().solved)
                    {
                        game = false;
                        FindObjectOfType<GameMaster>().LevelComplete();
                    }
                }
            }
        }
    }
    void Update()
    {
        
        angleX = selectedmodel.transform.localEulerAngles.x;
        if (angleX > 180)
            angleX -= 360;
        
        angleY = selectedmodel.transform.localEulerAngles.y;
        if (angleY > 180)
            angleY -= 360;

        angleZ = selectedmodel.transform.localEulerAngles.z;
        if (angleZ > 180)
            angleZ -= 360;
        
        if (Input.GetMouseButtonDown(0)){
            mousepressed = true;
        } 
        if (Input.GetMouseButtonUp(0)){
            mousepressed = false;
        }

        // MOVEMENT

        // new one axis rotation
        if (Input.GetKey(KeyCode.LeftControl))
        {
            // movement 1 = all movement
            // movement 2 = horizontal
            // movement 3 = vertiacal
            if (movements == 1 || movements == 3)
                mode = 1;
            else
                mode = 2;
        }
        else
        {
            if (movements == 1 || movements == 2)
                mode = 2;
        }

        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown("c") && swapmodels == false){
                swapmodels = true;
        } 

        // Smoothly tilts a transform towards a target rotation.
        if (Input.GetKey("w")) {
            rotateup = true;
        } else {
            rotateup = false;
        }
        
        if (Input.GetKey("a")) {
            rotateleft = true;
        } else {
            rotateleft = false;
        }
        
        if (Input.GetKey("s")) {
            rotatedown = true;
        } else {
            rotatedown = false;
        }

        if (Input.GetKey("d")) {
            rotateright = true;
        } else {
            rotateright = false;
        }
    }
}
