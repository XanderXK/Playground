using UnityEngine;

namespace DesignPatterns.Behavioral.Visitor
{
    public class Visitor : IVisitor
    {
        public void Visit(House house)
        {
            Debug.Log("Visit House");
        }

        public void Visit(Cave cave)
        {
            Debug.Log("Visit Cave");
        }
    }
}