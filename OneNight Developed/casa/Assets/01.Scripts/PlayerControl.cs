using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("Teste abertura")]
    [SerializeField] Animator gavetaUM;
    //**********************************************
    public GameObject CameraPrimeiraPessoa;
    Vector3 moveDirection = Vector3.zero;
    CharacterController controller;
    float rotacaoX = 0.0f, rotacaoY = 0.0f;
    public float speed = 5f;
    [Header("Sons")]
    [SerializeField] AudioSource passos;
    
    void Start()
    {
        transform.tag = "Player";
        CameraPrimeiraPessoa = GetComponentInChildren(typeof(Camera)).transform.gameObject;
        CameraPrimeiraPessoa.transform.localPosition = new Vector3(0, 0.64f, 0);
        CameraPrimeiraPessoa.transform.localRotation = Quaternion.identity;
        controller = GetComponent<CharacterController>();
        //gavetaUM = GetComponent<Animator>();
    }

    
    void Update()
    {
        Vector3 dirFrente = new Vector3(CameraPrimeiraPessoa.transform.forward.x, 0, CameraPrimeiraPessoa.transform.forward.z);
        Vector3 dirLado = new Vector3(CameraPrimeiraPessoa.transform.right.x, 0, CameraPrimeiraPessoa.transform.right.z);
        dirFrente.Normalize();
        dirLado.Normalize();

        dirFrente = dirFrente * Input.GetAxis("Vertical");
        dirLado = dirLado * Input.GetAxis("Horizontal");

        Vector3 dir = dirFrente + dirLado;
        if(dir.sqrMagnitude > 1)
        {
            dir.Normalize();
        }
        if(controller.isGrounded)
        {
            moveDirection = new Vector3(dir.x, 0, dir.z);
            moveDirection *= speed;
            if(Input.GetButton("Jump"))
            {
                moveDirection.y = 2f;
            }
        }
        moveDirection.y -= 20f * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        controlCamera();
        if(Input.GetKeyDown(KeyCode.E))
        {
            gavetaUM.SetTrigger("open");
        }
        if(Input.GetButton("Vertical") || Input.GetButtonDown("Horizontal"))
        {
            if(passos.isPlaying == true)
            {
                
            }
            else{
                passos.Play();
            }
        }
        else{
            passos.Pause();
        }
    }
    void controlCamera()
    {
        rotacaoX += Input.GetAxis("Mouse X") * 2f;
        rotacaoY += Input.GetAxis("Mouse Y") * 2f;
        rotacaoX = ClampAngleFP(rotacaoX, -360, 360);
        rotacaoY = ClampAngleFP(rotacaoY, -80, 80);

        Quaternion xQuat = Quaternion.AngleAxis(rotacaoX, Vector3.up);
        Quaternion yQuat = Quaternion.AngleAxis(rotacaoY, -Vector3.right);
        Quaternion rotFinal = Quaternion.identity * xQuat * yQuat;
        CameraPrimeiraPessoa.transform.localRotation = Quaternion.Lerp(CameraPrimeiraPessoa.transform.localRotation, rotFinal, Time.deltaTime * 10f);
    }

    float ClampAngleFP(float angulo, float min, float max)
    {
        if(angulo < -360)
        {
            angulo += 360;
        }
        if(angulo > 360)
        {
            angulo -= 360;
        }
        return Mathf.Clamp(angulo, min, max);
    }
}
