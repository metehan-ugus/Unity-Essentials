using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float rotationSpeed = 100.0f;
    public GameObject collectedEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,rotationSpeed * Time.deltaTime,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Instantiate(collectedEffect,transform.position,transform.rotation);
            Destroy(gameObject);
        }
    }
}
