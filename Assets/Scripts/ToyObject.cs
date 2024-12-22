using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewToy", menuName = "Toy Object", order = 1)]
public class ToyObject : ScriptableObject
{
    public string toyName;
    public Sprite sprite;
    public float mass;
    public bool isGoodToy; // True for good toys, false for bad toys
    public int point; // Oyuncak puanı
}