using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public Transform movePoint;
    public LayerMask obstacleLayer;

    [Header("Torch")] 
    public Light2D torch;
    public float maxRadius = 3f;
    public int torchSteps = 5;
    public float decreaseTorchBy = 1f;
    public List<GameObject> flames;
    public LayerMask refillLayer;
    public AudioSource litTorchSFX;
    public AudioSource extinquishSFX;
    
    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        torch.pointLightOuterRadius = maxRadius;
        decreaseTorchBy = maxRadius / torchSteps;
        litTorchSFX.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // move towards movepoint
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        
        // reached move point
        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            CheckTorchRefill();
            CheckForInputs();
        }
    }

    void CheckForInputs()
    {
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        float inputVertical = Input.GetAxisRaw("Vertical");
        
        if (Mathf.Abs(inputHorizontal) == 1f)
        {
            // only move if there is no obstacle in front
            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(inputHorizontal, 0f, 0f), 0.2f,
                    obstacleLayer))
            {
                movePoint.position += new Vector3(inputHorizontal, 0f, 0f);
                UpdateTorch();
            }
        }

        else if (Mathf.Abs(inputVertical) == 1f)
        {
            // only move if there is no obstacle in front
            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, inputVertical, 0f), 0.2f,
                    obstacleLayer))
            {
                movePoint.position += new Vector3(0f, inputVertical, 0f);
                UpdateTorch();
            }
        }
    }

    void UpdateTorch()
    {
        float torchRadius = torch.pointLightOuterRadius - decreaseTorchBy;
        litTorchSFX.volume = torchRadius / maxRadius;
        
        // no light :(
        if (torchRadius < 0f)
        {
            // reset torch
            torch.pointLightOuterRadius = maxRadius;
            litTorchSFX.volume = 1.0f;
            
            // consume flame
            if (flames.Count <= 0)
            {
                // todo: die
            }
            else
            {
                extinquishSFX.Play();
                
                GameObject flame = flames[0];
                flames.Remove(flame);
                Destroy(flame);

                GameManager.instance.Reshuffle();
            }
        }
        else
        {
            torch.pointLightOuterRadius = torchRadius;
        }
    }

    void CheckTorchRefill()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.2f, refillLayer))
        {
            torch.pointLightOuterRadius = maxRadius;
        }
    }
}
