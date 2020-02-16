using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nHydrate.Generator.Common.Util;

namespace nHydrate.Dsl
{
    partial class Function : nHydrate.Dsl.IDatabaseEntity, nHydrate.Dsl.IFieldContainer, nHydrate.Generator.Common.GeneratorFramework.IDirtyable
    {
        #region Names
        public string DatabaseName => this.Name;

        public string PascalName
        {
            get
            {
                if (!string.IsNullOrEmpty(this.CodeFacade))
                    return StringHelper.DatabaseNameToPascalCase(this.CodeFacade);
                else
                    return StringHelper.DatabaseNameToPascalCase(this.Name);
            }
        }
        #endregion

        protected override void OnDeleting()
        {
            if (this.nHydrateModel != null)
                this.nHydrateModel.RemovedFunctions.Add(this.PascalName);
            base.OnDeleting();
        }

        #region IFieldContainer Members

        public IEnumerable<IField> FieldList
        {
            get { return this.Fields; }
        }

        #endregion

    }

    partial class FunctionBase
    {
        partial class NamePropertyHandler
        {
            protected override void OnValueChanged(FunctionBase element, string oldValue, string newValue)
            {
                if (element.nHydrateModel != null && !element.nHydrateModel.IsLoading)
                {
                    if (string.IsNullOrEmpty(newValue))
                        throw new Exception("The name must have a value.");

                    var count = element.nHydrateModel.Functions.Count(x => x.Name.ToLower() == newValue.ToLower() && x.Id != element.Id);
                    if (count > 0)
                        throw new Exception("There is already an object with the specified name. The change has been cancelled.");
                }
                base.OnValueChanged(element, oldValue, newValue);
            }
        }

    }
}

