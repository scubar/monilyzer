using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Monilyzer.Model;
using Monilyzer.API.Data;

namespace Monilyzer.API.Services
{
    public class NodeRepository
    {
        private MonilyzerContext MonilyzerContext { get; set; }

        public NodeRepository(MonilyzerContext monilyzerContext)
        {
            MonilyzerContext = monilyzerContext;
        }

        public Node GetNode(Guid guid)
        {
            var node = MonilyzerContext.Nodes
                                       .Include(n => n.Interfaces)
                                       .Include(n => n.Volumes)
                                       .FirstOrDefault(c => c.Guid == guid);

            if (node == null) throw new NullReferenceException();

            return node;
        }

        public IEnumerable<Node> GetNodes()
        {
            return MonilyzerContext.Nodes.ToList(); 
        }

        public Node CreateNode(Node node)
        {
            MonilyzerContext.Nodes.Add(node);

            MonilyzerContext.SaveChanges();

            return node;
        }

        public Node UpdateNode(Guid guid,Node node)
        {
            var Node = GetNode(guid);

            Node.Update(node);

            MonilyzerContext.SaveChanges();

            return Node;
        }

        public void DeleteNode(Guid guid)
        {
            var Node = GetNode(guid);

            MonilyzerContext.Nodes.Remove(Node);

            MonilyzerContext.SaveChanges();
        }
    }
}
