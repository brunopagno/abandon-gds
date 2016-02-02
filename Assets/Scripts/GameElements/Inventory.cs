using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Inventory {

    public List<Collectible> items;

    public Inventory() {
        items = new List<Collectible>();
    }

    public int ItemsCount {
        get {
            return items.Count;
        }
    }

    public void AddItem(Collectible item) {
        items.Add(item);
    }

    public void RemoveItem(Collectible item) {
        items.Remove(item);
    }

    public void RemoveItem(string name) {
        foreach (Collectible item in items) {
            if (item.name.Equals(name)) {
                items.Remove(item);
                break;
            }
        }
    }

    public bool ContainsItem(string identifier) {
        foreach (Collectible item in items) {
            if (item.identifier.Equals(identifier)) {
                return true;
            }
        }
        return false;
    }
}
