using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HierarchyDataAccessControl.Data.Migrations
{
    /// <inheritdoc />
    public partial class add_large_scale_hierarchy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        -- Insert Companies (Level 1)
        INSERT INTO [dbo].[HierarchyNodes] ([Id], [ParentId], [Description], [TypeId]) VALUES
        ('8A86A8F7-C9B7-45EB-A6A8-8F1F5400B8B3', NULL, 'TechCorp', 1),
        ('F0E42E96-7106-4C12-B4A3-5A8D5083DF91', NULL, 'HealthSys', 1),
        ('A439C85D-B2F5-40A5-9F4B-F145841D5571', NULL, 'EduLearn', 1);

        -- Insert Departments (Level 2)
        INSERT INTO [dbo].[HierarchyNodes] ([Id], [ParentId], [Description], [TypeId]) VALUES
        ('5D6E2B16-11D6-4E45-9A41-EB94827F690D', '8A86A8F7-C9B7-45EB-A6A8-8F1F5400B8B3', 'HR', 2),
        ('9B5F43D9-1E8D-4B87-815C-A9E2F8DA345A', '8A86A8F7-C9B7-45EB-A6A8-8F1F5400B8B3', 'IT', 2),
        ('C41E1045-826F-4049-AD48-F6C0B7D44E94', 'F0E42E96-7106-4C12-B4A3-5A8D5083DF91', 'Finance', 2),
        ('FDB97831-AF16-4359-A983-C8A531FEF24D', 'F0E42E96-7106-4C12-B4A3-5A8D5083DF91', 'Operations', 2),
        ('8D6547D9-8DA3-49D5-B389-1C9F3C5B4087', 'A439C85D-B2F5-40A5-9F4B-F145841D5571', 'R&D', 2),
        ('E9B13EB2-C1EB-4C34-947D-FABE54C875ED', 'A439C85D-B2F5-40A5-9F4B-F145841D5571', 'Support', 2);

        -- Insert Teams (Level 3)
        INSERT INTO [dbo].[HierarchyNodes] ([Id], [ParentId], [Description], [TypeId]) VALUES
        ('6D874C51-A0A2-4A95-9134-6C7AFC161F94', '5D6E2B16-11D6-4E45-9A41-EB94827F690D', 'Recruitment', 3),
        ('D3F1A34C-1A94-44B8-AB7A-5E875BF758CB', '5D6E2B16-11D6-4E45-9A41-EB94827F690D', 'Employee Relations', 3),
        ('68C98C4C-FC4A-426E-9C91-759A6D3BEB25', '9B5F43D9-1E8D-4B87-815C-A9E2F8DA345A', 'Infrastructure', 3),
        ('C3B4549A-4E2F-463A-870A-7FDC1623A4DF', '9B5F43D9-1E8D-4B87-815C-A9E2F8DA345A', 'Development', 3),
        ('B7B92AE9-DA14-482D-A91B-FADC89D81E98', 'C41E1045-826F-4049-AD48-F6C0B7D44E94', 'Payroll', 3),
        ('F48AD6E7-244A-4AB6-8F68-BFD61622A5A3', 'C41E1045-826F-4049-AD48-F6C0B7D44E94', 'Budgeting', 3),
        ('39ABEC7E-4FA4-4015-A86E-B454BE3AEEFD', 'FDB97831-AF16-4359-A983-C8A531FEF24D', 'Procurement', 3),
        ('D7C0B18A-77A1-4EF2-8705-A6E526B3835A', 'FDB97831-AF16-4359-A983-C8A531FEF24D', 'Logistics', 3),
        ('E64362E9-CF7F-4384-90DC-82D6E7BA3D25', '8D6547D9-8DA3-49D5-B389-1C9F3C5B4087', 'Innovations', 3),
        ('4C9204E7-C4A4-4636-B233-85C8F25E37F3', '8D6547D9-8DA3-49D5-B389-1C9F3C5B4087', 'Testing', 3),
        ('AE0CE0BB-4601-4BFA-A7BC-8DFD9E3A8401', 'E9B13EB2-C1EB-4C34-947D-FABE54C875ED', 'Technical Support', 3),
        ('FAC5D44E-7B6E-4C74-A451-AC9678C1EE56', 'E9B13EB2-C1EB-4C34-947D-FABE54C875ED', 'Customer Support', 3);
        ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
        DELETE FROM [dbo].[HierarchyNodes]
        WHERE [Id] IN (
            '8A86A8F7-C9B7-45EB-A6A8-8F1F5400B8B3',
            'F0E42E96-7106-4C12-B4A3-5A8D5083DF91',
            'A439C85D-B2F5-40A5-9F4B-F145841D5571',
            '5D6E2B16-11D6-4E45-9A41-EB94827F690D',
            '9B5F43D9-1E8D-4B87-815C-A9E2F8DA345A',
            'C41E1045-826F-4049-AD48-F6C0B7D44E94',
            'FDB97831-AF16-4359-A983-C8A531FEF24D',
            '8D6547D9-8DA3-49D5-B389-1C9F3C5B4087',
            'E9B13EB2-C1EB-4C34-947D-FABE54C875ED',
            '6D874C51-A0A2-4A95-9134-6C7AFC161F94',
            'D3F1A34C-1A94-44B8-AB7A-5E875BF758CB',
            '68C98C4C-FC4A-426E-9C91-759A6D3BEB25',
            'C3B4549A-4E2F-463A-870A-7FDC1623A4DF',
            'B7B92AE9-DA14-482D-A91B-FADC89D81E98',
            'F48AD6E7-244A-4AB6-8F68-BFD61622A5A3',
            '39ABEC7E-4FA4-4015-A86E-B454BE3AEEFD',
            'D7C0B18A-77A1-4EF2-8705-A6E526B3835A',
            'E64362E9-CF7F-4384-90DC-82D6E7BA3D25',
            '4C9204E7-C4A4-4636-B233-85C8F25E37F3',
            'AE0CE0BB-4601-4BFA-A7BC-8DFD9E3A8401',
            'FAC5D44E-7B6E-4C74-A451-AC9678C1EE56'
        );
        ");
        }
    }
}
