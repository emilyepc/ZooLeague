    using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SliderReset1 : MonoBehaviour
{
    public Scrollbar scrollbar;
    void Start()
    {
        scrollbar.value = 0;
    }
}
