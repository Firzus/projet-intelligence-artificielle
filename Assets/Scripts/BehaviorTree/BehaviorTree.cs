using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;

[CreateAssetMenu()]
public class BehaviorTree : ScriptableObject
{
    [SerializeField] public Node rootNode;
    [SerializeField] public Node.State treeState = Node.State.Running;
    [SerializeField] public BlackBoard blackboard = new BlackBoard();
    [SerializeField] public List<Node> nodes = new List<Node>();

    public Node.State Update()
    {
        if (rootNode.state == Node.State.Running)
        {
            treeState = rootNode.Update();
        }
        return treeState;
    }

#if UNITY_EDITOR
    public Node CreateNode(System.Type type)
    {
        Node node = ScriptableObject.CreateInstance(type) as Node;
        node.name = type.Name;
        node.guid = GUID.Generate().ToString();

        Undo.RecordObject(this, "Behavior Tree (CreateNode)");
        nodes.Add(node);

        if (Application.isPlaying) 
        {
            AssetDatabase.AddObjectToAsset(node, this);
        }

        AssetDatabase.AddObjectToAsset(node, this);
        Undo.RegisterCreatedObjectUndo(node, "Behavior Tree (CreateNode");

        AssetDatabase.SaveAssets();
        return node;
    }

    public void DeleteNode(Node node)
    {
        Undo.RecordObject(this, "Behavior Tree (DeleteNode)");
        nodes.Remove(node);

        AssetDatabase.RemoveObjectFromAsset(node);
        Undo.DestroyObjectImmediate(node);

        AssetDatabase.SaveAssets();
    }

    public void AddChild(Node parent, Node child)
    {
        DecorativeNode decorator = parent as DecorativeNode;
        if (decorator)
        {
            Undo.RecordObject(decorator, "Behavior Tree (AddChild)");
            decorator.child = child;
            EditorUtility.SetDirty(decorator);
        }

        RootNode rootNode = parent as RootNode;
        if (rootNode)
        {
            Undo.RecordObject(rootNode, "Behavior Tree (AddChild)");
            rootNode.child = child;
            EditorUtility.SetDirty(rootNode);
        }

        CompositeNode composite = parent as CompositeNode;
        if (composite)
        {
            Undo.RecordObject(composite, "Behavior Tree (AddChild)");
            composite.children.Add(child);
            EditorUtility.SetDirty(composite);
        }
    }

    public void RemoveChild(Node parent, Node child) 
    {
        DecorativeNode decorator = parent as DecorativeNode;
        if (decorator)
        {
            Undo.RecordObject(decorator, "Behavior Tree (RemoveChild)");
            decorator.child = null;
            EditorUtility.SetDirty(decorator);
        }

        RootNode rootNode = parent as RootNode;
        if (rootNode)
        {
            Undo.RecordObject(rootNode, "Behavior Tree (RemoveChild)");
            rootNode.child = null;
            EditorUtility.SetDirty(rootNode);
        }

        CompositeNode composite = parent as CompositeNode;
        if (composite)
        {
            Undo.RecordObject(composite, "Behavior Tree (RemoveChild)");
            composite.children.Remove(child);
            EditorUtility.SetDirty(composite);
        }
    }
    #endif
    public List<Node> GetChildren(Node parent)
    {
        List<Node> children = new List<Node>();

        DecorativeNode decorator = parent as DecorativeNode;
        if (decorator && decorator.child != null)
        {
            children.Add(decorator.child);
        }

        RootNode rootNode = parent as RootNode;
        if (rootNode && rootNode.child != null)
        {
            children.Add(rootNode.child);
        }

        CompositeNode composite = parent as CompositeNode;
        if (composite)
        {
            return composite.children;
        }

        return children;
        
    }

    public void Traverse(Node node, System.Action<Node> visiter)
    {
        if (node)
        {
            visiter.Invoke(node);
            var children = GetChildren(node);
            children.ForEach((n) => Traverse(n, visiter));
        }
    }
    
    public BehaviorTree Clone()
    {
        BehaviorTree tree = Instantiate(this);
        tree.rootNode = tree.rootNode.Clone();
        tree.nodes = new List<Node>();

        Traverse(tree.rootNode, (n) =>
        {
            tree.nodes.Add(n);
        });

        return tree;
    }

    public void Bind(EntityState enemy)
    {
        Traverse(rootNode, node =>
        {
            node.agent = enemy;
            node.blackBoard = blackboard;
        });
    }
}
