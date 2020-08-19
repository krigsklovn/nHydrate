using nHydrate.ModelManagement;

namespace NetCoreTestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            var rootFolder = @"C:\code\nHydrateTestAug\ModelProject";
            var modelName = "Model1.nhydrate";
            var model = FileManagement.Load(rootFolder, modelName);

            var rootFolder2 = @"C:\Temp\ModelTest";
            FileManagement.Save(rootFolder2, modelName, model);
        }
    }
}
