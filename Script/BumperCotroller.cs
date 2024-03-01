using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public Collider bola;
    public float multiplier;
    public Color color;
    public ScoreManager scoreManager;
    public float score;

    private Renderer renderer;
    private Animator animator;

    [SerializeField] 
    private AudioManager audioManager; 

    [SerializeField] 
    private VFXManager vfxManager;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        animator = GetComponent<Animator>();

        renderer.material.color = color;

        if (audioManager == null)
        {
            Debug.LogError("No AudioManager assigned to BumperController!");
        }

        if (vfxManager == null)
        {
            Debug.LogError("No VFXManager assigned to BumperController!");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == bola)
        {
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();
            bolaRig.velocity *= multiplier;

            // Trigger animation
            animator.SetTrigger("Hit");

            // Play SFX if AudioManager is available
            if (audioManager != null)
            {
                audioManager.PlaySFX(transform.position);
            }
            else
            {
                Debug.LogError("AudioManager reference is null!");
            }

            // Play VFX if VFXManager is available
            if (vfxManager != null)
            {
                vfxManager.PlayVFX(transform.position);
            }
            else
            {
                Debug.LogError("VFXManager reference is null!");
            }

            //score add
            scoreManager.AddScore(score);
        }
    }
}
