using nHydrate.Generator.Common.GeneratorFramework;
using nHydrate.Generator.Common.EventArgs;

namespace nHydrate.Generator.EFCodeFirstNetCore.Generators.ContextStartup
{
    [GeneratorItem("ContextStartupExtenderGenerator", typeof(EFCodeFirstNetCoreProjectGenerator))]
    public class ContextStartupExtenderGenerator : EFCodeFirstNetCoreProjectItemGenerator
    {
        private const string RELATIVE_OUTPUT_LOCATION = @"\";

        public override int FileCount => 1;

        public override void Generate()
        {
            ContextStartupExtenderTemplate template = new ContextStartupExtenderTemplate(_model);
            string fullFileName = RELATIVE_OUTPUT_LOCATION + template.FileName;
            ProjectItemGeneratedEventArgs eventArgs = new ProjectItemGeneratedEventArgs(fullFileName, template.FileContent, ProjectName, this, false);
            OnProjectItemGenerated(this, eventArgs);
            var gcEventArgs = new ProjectItemGenerationCompleteEventArgs(this);
            OnGenerationComplete(this, gcEventArgs);
        }

    }
}
