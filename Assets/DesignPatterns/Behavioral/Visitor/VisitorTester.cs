using UnityEngine;

namespace DesignPatterns.Behavioral.Visitor
{
    public class VisitorTester : MonoBehaviour
    {
        private void Start()
        {
            var visitorA = new Visitor();
            visitorA.Visit(new House());

            var visitorC = new Visitor();
            visitorC.Visit(new Cave());
        }
    }
}