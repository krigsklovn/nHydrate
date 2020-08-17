using nHydrate.Generator.Common;
using nHydrate.Generator.Common.GeneratorFramework;
using nHydrate.Generator.Common.ProjectItemGenerators;

namespace nHydrate.Generator.SQLInstaller
{
    [GeneratorProjectAttribute(
        "SQL Database Installer",
        "Creates a project to maintain a SQL Server database, used in conjunction with the generated Entity Framework data access layer.",
        "b8bd6b27-b9f2-4291-82e8-88e1295eef09",
        typeof(nHydrateGeneratorProject),
        typeof(DatabaseProjectGenerator),
        true,
        new string[] { }
        )]
    public class DatabaseProjectGenerator : BaseProjectGenerator
    {
        public override string ProjectTemplate => "database.vstemplate";

        public override string LocalNamespaceExtension => DatabaseProjectGenerator.NamespaceExtension;

        public static string NamespaceExtension => "Install";

        protected override void OnInitialize(IModelObject model)
        {
            //nHydrateGeneratorProject.AddICSharpDllToBinFolder();
        }

        public override IModelConfiguration ModelConfiguration { get; set; }
    }
}
