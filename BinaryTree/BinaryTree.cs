using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeProject
{
    //class Node
    //{
    //    public Node left;
    //    public Node right;
    //    public int value;

    //    public Node(int value)
    //    {
    //        this.value = value;
    //        left = null;
    //        right = null;
    //    }
    //}



    class BinaryTree
    {
        public BinaryTree left;
        public BinaryTree right;
        public int? value = null;

        public BinaryTree()
        {
            //this.value = value;
            //left = null;
            //right = null;
        }

        public void Insert(int value)
        {
            if (this.value == null)
            {
                this.value = value;
                return;
            }
            if (this.value > value)
            {
                if (left == null)
                {
                    left = new BinaryTree();
                    left.value = value;
                }
                else
                {
                    left.Insert(value);
                }
            }

            if (this.value < value)
            {
                if (right == null)
                {
                    right = new BinaryTree();
                    right.value = value;
                }
                else
                {
                    right.Insert(value);
                }
            }
        }






        public int? Delete(int? value)
        {
            if (this.value == null)
            {
                return this.value;
            }
            if (this.value > value)
            {
                left = Delete(left, value);
            }
            else if (this.value < value)
            {
                right = Delete(left, value);
            }
            else
            {
                if (this.left == null)
                {
                    return this.right.value;
                }
                else if (this.right == null)
                {
                    return this.left.value;
                }

                this.value = this.right.value;

                this.right = Delete(this.right, this.value);
            }
            return value;
        }


        public BinaryTree Delete(BinaryTree leaf, int? value)
        {
            if (leaf.value == null)
            {
                return leaf;
            }
            if (value < leaf.value)
            {
                leaf.left = Delete(leaf.left, value);
            }
            else if (value > leaf.value)
            {
                leaf.right = Delete(leaf.right, value);
            }

            else
            {
                if (leaf.left == null)
                {
                    return leaf.right;
                }
                else if (leaf.right == null)
                {
                    return leaf.left;
                }

                leaf = leaf.right;

                left.right = Delete(leaf.right, leaf.value);
            }

            return leaf;

        }




        public int? Search(int value)
        {
            if (this.value == null)
            {
                return null;
            }

            if (this.value == value)
            {
                return this.value;
            }
            else if (this.value > value)
            {
                return Search(this.left, value);//Left
            }
            else if (this.value < value)
            {
                return Search(this.right, value); //right
            }
            return this.value;


        }

        private int? Search(BinaryTree leaf, int? value)
        {
            if (leaf.value == null)
            {
                return null;
            }

            if (leaf.value == value)
            {
                return leaf.value;
            }
            else if (leaf.value > value)
            {
                return Search(leaf.left, value);//Left
            }
            else if (left.value < value)
            {
                return Search(leaf.right, value); //right
            }
            return leaf.value;
        }

        //Traversal Fuctions: Preorder, Postorder, Inorder 

        //Preorder functions
        public void TraversePreorder()
        {
            if(this.value == null)
            {
                return;
            }
            else
            {
                Console.Out.Write(this.value + " ");
            }
            if (this.left != null) {
                this.TraversePreorder(this.left);
            }
            if (this.right != null)
            {
                this.TraversePreorder(this.right);
            }
        }

        private void TraversePreorder(BinaryTree leaf)
        {
            if (leaf.value == null)
            {
                return;
            }
            else
            {
                Console.Out.Write(leaf.value + " ");
            }
            if (leaf.left != null)
            {
                leaf.TraversePreorder(leaf.left);
            }
            if (leaf.right != null)
            {
                leaf.TraversePreorder(leaf.right);
            }
        }

        //Postorder function
        public void TraversePostorder() {
            if(this.value == null)
            {
                return;
            }
            if(this.left != null) {
                this.TraversePostorder(this.left);
            }
            if(this.right != null)
            {
                this.TraversePostorder(this.right);
            }
            Console.Out.Write(this.value);
        }

        private void TraversePostorder(BinaryTree leaf)
        {
            if (leaf.value == null)
            {
                return;
            }
            if (leaf.left != null)
            {
                leaf.TraversePostorder(leaf.left);
            }
            if (leaf.right != null)
            {
                leaf.TraversePostorder(leaf.right);
            }
            Console.Out.Write(leaf.value + " ");
        }

        //Inorder functions
        public void TraverseInorder()
        {
            if(this.value == null)
            {
                return;
            }
            if(this.left != null)
            {
                this.TraverseInorder(this.left);
            }

            Console.Out.Write(this.value);

            if (this.right != null) {
                this.TraverseInorder(this.right);
            }
        }

        private void TraverseInorder(BinaryTree leaf)
        {
            if (leaf.value == null)
            {
                return;
            }
            if (leaf.left != null)
            {
                leaf.TraverseInorder(leaf.left);
            }

            Console.Out.Write(leaf.value);

            if (leaf.right != null)
            {
                leaf.TraverseInorder(leaf.right);
            }
        }
    }
}
