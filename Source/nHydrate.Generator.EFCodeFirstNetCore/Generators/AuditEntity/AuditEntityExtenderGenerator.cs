using System.Linq;
using nHydrate.Generator.Common.GeneratorFramework;
using nHydrate.Generator.Common.EventArgs;
using nHydrate.Generator.Models;

namespace nHydrate.Generator.EFCodeFirstNetCore.Generators.AuditEntity
{
    [GeneratorItem("AuditEntityExtenderGenerator", typeof(EFCodeFirstNetCoreProjectGenerator))]
    public class AuditEntityExtenderGenerator : EFCodeFirstNetCoreProjectItemGenerator
    {
        private const string RELATIVE_OUTPUT_LOCATION = @"\Audit\";

        public override int FileCount => 1;

        public override void Generate()
        {
            foreach (Table table in _model.Database.Tables.Where(x => !x.AssociativeTable && (x.TypedTable != TypedTableConstants.EnumOnly) && x.AllowAuditTracking).OrderBy(x => x.Name))
            {
                var template = new AuditEntityExtenderTemplate(_model, table);
                var fullFileName = RELATIVE_OUTPUT_LOCATION + template.FileName;
                var eventArgs = new ProjectItemGeneratedEventArgs(fullFileName, template.FileContent, ProjectName, this, false);
                OnProjectItemGenerated(this, eventArgs);
            }
            var gcEventArgs = new ProjectItemGenerationCompleteEventArgs(this);
            OnGenerationComplete(this, gcEventArgs);
        }

    }
}
