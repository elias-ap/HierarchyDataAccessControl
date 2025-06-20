using HierarchyDataAccessControl.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.CodeDom;
using System.Data.Entity.Core;
using System.Xml.Linq;

namespace HierarchyDataAccessControl.Data
{
    public class HierarchyDataAccessContext : DbContext
    {
        private DbSet<HierarchyNode> Nodes { get; set; }
        private DbSet<HierarchyNodeType> NodeTypes { get; set; }
        private DbSet<User> Users { get; set; }
        private DbSet<HierarchyNodePermission> Permissions { get; set; }
        private DbSet<AccessPermission> Accesses { get; set; }
        private DbSet<Request> Requests { get; set; }
        private DbSet<Employee> Employees { get; set; }

        public HierarchyDataAccessContext(DbContextOptions<HierarchyDataAccessContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(HierarchyDataAccessContext).Assembly);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder) { }

        public IEnumerable<HierarchyNodeType> GetAllNodeTypes()
        {
            try
            {
                return NodeTypes
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

        public async Task<IEnumerable<HierarchyNode>> GetAllNodesHierarchicallyAsync()
        {
            try
            {
                var allCurrentNodes = await Nodes
                    .AsNoTracking()
                    .Include(n => n.Permissions)
                    .ToListAsync();

                var rootNodes = allCurrentNodes
                    .Where(n => n.TypeId == 1)
                    .ToList();

                await Parallel.ForEachAsync(rootNodes, async (node, ct) => await LoadChildrenNodesRecursivelyAsync(node, allCurrentNodes));

                return rootNodes;

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

                foreach (var item in nodes)
                {
                    LoadChildrenNodesRecursively(item);
                }

                return nodes;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task LoadChildrenNodesRecursivelyAsync(HierarchyNode node, List<HierarchyNode> allCurrentNodes)
        {
            node.ChildrenNodes = allCurrentNodes
                .Where(n => n.ParentId == node.Id)
                .ToList();

            await Parallel.ForEachAsync(node.ChildrenNodes, async (n, ct) => await LoadChildrenNodesRecursivelyAsync(n, allCurrentNodes));
        }

        private void LoadChildrenNodesRecursively(HierarchyNode node)
        {
            node.ChildrenNodes = Nodes
                .AsNoTracking()
                .Include(n => n.Permissions)
                .Where(n => n.ParentId == node.Id)
                .ToList();

            foreach (var item in node.ChildrenNodes)
            {
                LoadChildrenNodesRecursively(item);
            }
        }

        public HierarchyNode GetNodesHierarchicallyByNodeIdAndUserAccess(Guid hierarchyNodeId, Guid userId)
        {
            try
            {
                User? user = Users
                    .AsNoTracking()
                    .Include(u => u.Groups)
                    .FirstOrDefault(u => u.Id == userId);

                if (user is null)
                {
                    throw new ObjectNotFoundException("Not found the user.");
                }

                HierarchyNode? node = Nodes
                    .AsNoTracking()
                    .FirstOrDefault(n => n.Id == hierarchyNodeId);

                if (node is null)
                {
                    throw new ObjectNotFoundException("Not found the node.");
                }

                IEnumerable<Guid> groupsIds = user!
                    .Groups
                    .Select(g => g.Id);

                var userNodePermissions = Permissions
                    .AsNoTracking()
                    .Include(p => p.Accesess)
                    .Where(p => p.HierarchyNodeId == node.Id && p.Accesess.Any(a => a.AccessId == user.Id || groupsIds.Contains(a.AccessId)))
                    .ToList();

                node.Permissions = userNodePermissions;

                var globalPermission = userNodePermissions
                    .Where(p => p.Accesess.Where(a => a.TypeId == AccessPermissionType.Global).Any());

                if (globalPermission.Any())
                {
                    LoadChildrenNodesRecursively(node);
                }

                return node;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public HierarchyNode AddNode(HierarchyNode node)
        {
            try
            {
                node = Nodes.Add(node).Entity;

                SaveChanges();

                return node;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public HierarchyNodePermission AddPermission(HierarchyNodePermission permission)
        {
            try
            {
                permission = Permissions
                    .Add(permission)
                    .Entity;

                SaveChanges();

                return permission;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public AccessPermission AddAccess(AccessPermission access)
        {
            try
            {
                access = Accesses
                    .Add(access)
                    .Entity;

                SaveChanges();

                return access;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<Employee> GetEmployeesByFilter(Func<Employee, bool> filter)
        {
            return Employees
                .AsNoTracking()
                .Where(filter)
                .ToList();
        }
    }
}
