using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Toolkit.DataStructures
{
    public class RedBlackTree<Key, Value> where Key : IComparable
    {
        private enum NodeColor { Red, Black }

        private Node root;     // root of the BST

        // BST helper node data type
        private class Node
        {
            public Key Key;           // key
            public Value Val;         // associated data
            public Node Left, Right;  // links to left and right subtrees
            public NodeColor ParentLinkColor;     // color of parent link


            public Node(Key key, Value val, NodeColor parentLinkColor)
            {
                this.Key = key;
                this.Val = val;
                this.ParentLinkColor = parentLinkColor;
            }
        }

        /***************************************************************************
         *  Red-black tree helper functions.
         ***************************************************************************/

        // is node x red (and non-null) ?
        private bool isRed(Node x)
        {
            if (x == null) return false;
            return x.ParentLinkColor == NodeColor.Red;
        }

        // rotate right
        private Node RotateRight(Node h)
        {
            Debug.Assert(h != null && isRed(h.Left));
            Node x = h.Left;
            h.Left = x.Right;
            x.Right = h;
            x.ParentLinkColor = h.ParentLinkColor;
            h.ParentLinkColor = NodeColor.Red;
            return x;
        }

        // rotate left
        private Node RotateLeft(Node h)
        {
            Debug.Assert(h != null && isRed(h.Right));
            Node x = h.Right;
            h.Right = x.Left;
            x.Left = h;
            x.ParentLinkColor = h.ParentLinkColor;
            h.ParentLinkColor = NodeColor.Red;
            return x;
        }

        // precondition: two children are red, node is black
        // postcondition: two children are black, node is red
        private void flipColors(Node h)
        {
            Debug.Assert(!isRed(h) && isRed(h.Left) && isRed(h.Right));
            h.ParentLinkColor = NodeColor.Red;
            h.Left.ParentLinkColor = NodeColor.Black;
            h.Right.ParentLinkColor = NodeColor.Black;
        }
    }
}
