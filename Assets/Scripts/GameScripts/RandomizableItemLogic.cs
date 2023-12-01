using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QTArts.AbstractClasses;

public class RandomizableItemLogic : MonoSingleton<RandomizableItemLogic>
{
    [SerializeField]
    RandomizableItem[] _obtainableItems;
}
