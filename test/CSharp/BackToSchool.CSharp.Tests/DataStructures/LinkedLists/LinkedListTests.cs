
using NUnit.Framework;

namespace BackToSchool.CSharp.Tests.DataStructures.LinkedLists
{
    [TestFixture]
    public class LinkedListTests
    {
        [Test]
        public void LinkedList_NoNodes()
        {
            // Arrange
            var ll = new BackToSchool.CSharp.DataStructures.LinkedLists.LinkedList();
            ll.Add(9);
            ll.Add(8);

            // Act
            var result = ll.PrintAllNodes();

            // Assert
            Assert.AreEqual("9 8", result);
        }
    }
}
