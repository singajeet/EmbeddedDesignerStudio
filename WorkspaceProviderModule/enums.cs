using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkspaceProviderModule
{
    public enum IconsImageIndex { 
        File = 0,
        File_Upload = 1,
        Files = 2,
        File_Save = 3,
        Folder = 4,
        Folder_Save = 5
    };


    public enum BuildType { 
        Debug = 1,
        Release = 2,
        Custom = 3
    };

    public enum Platform { 
        x86 = 1,
        x64 = 2,
        Both = 3,
        AnyCPU = 4,
        Custom = 5
    };

    public enum WorkspaceType { 
        Standard = 1,
        Custom = 2
    };

    public enum ProjectType
    {
        Font = 1,
        GUI = 2,
        Arduino = 4,
        Standard_C = 8,
        Standard_Cpp = 16,
        Custom = 32
    };

}
