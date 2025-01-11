using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        Destroy(other.gameObject);
    }
}
