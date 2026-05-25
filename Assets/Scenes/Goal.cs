using UnityEngine;

public class Goal : MonoBehaviour
{
    public Timer gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.Win();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
