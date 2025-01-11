using System.Runtime.CompilerServices;
using UnityEngine;

// can't instanciate in scene, have to instancite children
public abstract class Pickup : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 100f;

    const string playerString = "Player";

    void Update() {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    void OnTriggerEnter(Collider other) 
    {   
        if(other.CompareTag(playerString))
        {
            OnPickup();
            Destroy(gameObject);
        }
            
    }

    // protected means only can use in this or inherirance class
    // abstract means only implemented in child class
    protected abstract void OnPickup();
}
