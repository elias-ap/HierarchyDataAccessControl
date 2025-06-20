using HierarchyDataAccessControl.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.CodeDom;
using System.Xml.Linq;

namespace HierarchyDataAccessControl.Data
{
    public class HierarchyDataAccessContext : DbContext
    {
        public DbSet<HierarchyNode> Nodes { get; set; }
        public DbSet<HierarchyNodeType> Types { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<HierarchyNodePermission> Permissions { get; set; }

        public HierarchyDataAccessContext(DbContextOptions<HierarchyDataAccessContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(HierarchyDataAccessContext).Assembly);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder) { }

        public IEnumerable<HierarchyNodeType> GetAllTypes()
        {
            try
            {
                return Types
                    .AsNoTracking()
                    .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<HierarchyNode> GetAllHierarchyNodes()
        {
            try
            {
                return Nodes
                    .AsNoTracking()
                    .Include(hn => hn.ChildrenNodes)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public IEnumerable<HierarchyNode> GetAllFirstLevelHierarchyNodes()
        {
            try
            {
                return Nodes
                    .AsNoTracking()
                    .Where(hn => hn.TypeId == 1)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            try
            {
                return Users
                    .AsNoTracking()
                    .Include(u => u.Groups)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<HierarchyNode> GetAllNodesHierarchically()
        {
            try
            {
                var nodes = Nodes
                    .AsNoTracking()
                    .Where(n => n.TypeId == 1)
                    .ToList();

                Parallel.ForEach(nodes, n => LoadChildrenNodes(n));

                return nodes;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void LoadChildrenNodes(HierarchyNode node)
        {
            node.ChildrenNodes = Nodes
                .AsNoTracking()
                .Where(n => n.ParentId == node.Id)
                .ToList();

            foreach (var child in node.ChildrenNodes)
            {
                LoadChildrenNodes(child);
            }
        }

        public IEnumerable<HierarchyNode> GetNodesHierarchicallyByNodeIdAndUserAccess(Guid hierarchyNodeId, Guid userId)
        {
            try
            {
                User? user = Users
                    .AsNoTracking()
                    .Include(u => u.Groups)
                    .FirstOrDefault(u => u.Id == userId);

                if (user is null)
                {
                    throw new Exception("User not found.");
                }

                IEnumerable<Guid> groupsIds = user!
                    .Groups
                    .Select(g => g.Id);

                var userNodePermissions = Permissions
                    .AsNoTracking()
                    .Include(p => p.Accesess)
                    .Where(p => p.Accesess.Any(a => a.AccessId == user.Id || groupsIds.Contains(a.AccessId)));

                var nodes = Nodes
                    .AsNoTracking()
                    .Where(n => n.Id == hierarchyNodeId)
                    .Join(
                    userNodePermissions,
                    o => o.Id,
                    f => f.HierarchyNodeId,
                    (node, permission) => node)
                    .ToList();

                // implement global and unique access
                //Parallel.ForEach(nodes, n => LoadChildrenNodes(n));

                return nodes;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
