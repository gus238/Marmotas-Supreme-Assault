using UnityEngine;

public class MantenerPosicion : MonoBehaviour
{
    public Transform parentObject;
    public Transform[] children;

    void Start()
    {
        foreach (Transform child in children)
        {
            Vector3 globalPos = child.position;
            child.SetParent(parentObject);
            child.position = globalPos;
        }
        }
}
