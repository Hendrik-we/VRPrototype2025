using UnityEngine;

public enum GlassType
{
    Erlenmeyer,
    Puffer,
    Loesung
}

public class WashableGlass : MonoBehaviour
{
    public GameObject liquid;
    public GlassType glassType;
    public bool isWashed = false;
}
