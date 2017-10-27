using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TemplateProviderModule.Models;
using TemplateProviderModule.Interfaces;

namespace TemplateProviderModule.Models.Types
{
    public class WorkspaceTypeModel : TypeModel
    {
    	public WorkspaceTypeModel() : base() {
            this.Tag = "<WorkspaceType />";
        }
    }
}
